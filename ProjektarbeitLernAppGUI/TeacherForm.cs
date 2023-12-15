using LiveChartsCore.Kernel;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using ProjektarbeitLernApp.Model.Auth;
using ProjektarbeitLernApp.PLAContext;
using ProjektarbeitLernApp.Service;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjektarbeitLernApp.Model.LearnApp;

namespace ProjektarbeitLernAppGUI
{
    public partial class TeacherForm : Form
    {
        private DatabasePLAContext dbContext;
        private User user;
        private UserService userService;
        private StatisticService statisticService;
        private LearnProgressService learnProgressService;

        public TeacherForm(DatabasePLAContext dbContext, User user)
        {
            this.dbContext = dbContext;
            this.user = user;
            userService = new UserService(dbContext);
            statisticService = new StatisticService(dbContext);
            learnProgressService = new LearnProgressService(dbContext, statisticService);

            InitializeComponent();
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
            DataGridViewStyling();
        }

        private void InitializeDataGridView()
        {
            var students = userService.GetAllStudents();
            if (students.Count == 0)
            {
                panel1.Visible = true;
                return;
            }

            var studentDataSource = students.Select(student => new Student
            {
                Id = student.Id,
                Ripeness = learnProgressService.GetExamRipeness(student),
                Name = student.Name,
                LastName = student.LastName
            }).ToList();

            studentDataSource.Sort((a, b) => b.Ripeness.CompareTo(a.Ripeness));

            for (int i = 0; i < studentDataSource.Count; i++)
            {
                studentDataSource[i].Ranking = i + 1;
            }

            dataGridView1.DataSource = studentDataSource;
        }

        private void DataGridViewStyling()
        {
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "Vorname";
            dataGridView1.Columns["LastName"].HeaderText = "Nachname";
            dataGridView1.Columns["Ripeness"].HeaderText = "Prüfungsreife";
            dataGridView1.Columns["Ranking"].HeaderText = "Rang";

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1];
        }

        private void InitializeStats(User user)
        {
            var allKnown = statisticService.GetAllKnown(user);
            var allNotKnown = statisticService.GetAllNotKnown(user);
            var learnedPerDay = statisticService.GetLearnedPerDay(user);


            Func<ChartPoint, string> labelPoint = chartPoint =>
                            string.Format("{0} ({1:P})", chartPoint.PrimaryValue, chartPoint.AsDataLabel);

            pieChart1.Series = new ISeries[]
            {
                new PieSeries<double>
                {
                    Name = "richtig beantwortet",
                    Values = new double[] { allKnown },
                    DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                    DataLabelsPosition = PolarLabelsPosition.Middle,
                    Fill = new SolidColorPaint(SKColors.LightGreen)
                },
                new PieSeries<double>
                {
                    Name = "falsch beantwortet",
                    Values = new double[] { allNotKnown },
                    DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                    DataLabelsPosition = PolarLabelsPosition.Middle,
                    Fill = new SolidColorPaint(SKColors.LightCoral)
                },
            };
            pieChart1.LegendPosition = LegendPosition.Left;


            cartesianChart1.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = learnedPerDay,
                    Name = "gelernte Fragen",
                    Fill = new SolidColorPaint(SKColors.LightBlue),
                    Stroke = new SolidColorPaint(SKColors.LightBlue),
                    GeometryFill = new SolidColorPaint(SKColors.Blue),
                    GeometryStroke = new SolidColorPaint(SKColors.LightBlue),
                    GeometrySize = 10
                }
            };

            cartesianChart1.XAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Tag",
                    Labels = statisticService.GetDays(user)
                }
            };

            cartesianChart1.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Gerlernt",
                    Labeler = value => value.ToString()
                }
            };

            progressBar1.Value = learnProgressService.GetExamRipeness(user);
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var userId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
                if (userId > 0)
                {
                    var user = userService.GetUserById(userId);
                    InitializeStats(user);
                }
            }
        }

    }
}
