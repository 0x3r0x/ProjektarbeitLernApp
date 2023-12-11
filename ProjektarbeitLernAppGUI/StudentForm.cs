using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Windows.Forms;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.SKCharts;
using SkiaSharp;
using ProjektarbeitLernApp.PLAContext;
using ProjektarbeitLernApp.Service;
using ProjektarbeitLernApp.Model.LearnApp;
using ProjektarbeitLernApp.Model.Auth;


namespace ProjektarbeitLernAppGUI
{
    public partial class Form1 : Form
    {
        private DatabasePLAContext dbContext;
        private MultipleChoiceSetService multipleChoiceSetService;
        private StatisticService statisticService;
        private LearnProgressService learnProgressService;
        private RoutineService routineService;
        private User user;
        private List<Answers> answerList;
        private MultipleChoiceSet question;

        public Form1(DatabasePLAContext dbContext, User user)
        {
            this.dbContext = dbContext;

            multipleChoiceSetService = new MultipleChoiceSetService(dbContext);
            statisticService = new StatisticService(dbContext);
            learnProgressService = new LearnProgressService(dbContext, statisticService);
            routineService = new RoutineService();
            this.user = user;

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            button1.Enabled = false;


            #region profile
            var userService = new UserService(dbContext);
            var dbUser = userService.GetUser(user);
            textBox2.Text = dbUser.Name;
            textBox3.Text = dbUser.LastName;
            textBox5.Text = dbUser.Email;
            #endregion

            #region stats
            InitializeStats();

            #endregion


        }

        private void InitializeStats()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
                            string.Format("{0} ({1:P})", chartPoint.PrimaryValue, chartPoint.AsDataLabel);

            pieChart1.Series = new ISeries[]
            {
                new PieSeries<double>
                {
                    Name = "richtig beantwortet",
                    Values = new double[] { statisticService.GetAllKnown(user) },
                    DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                    DataLabelsPosition = PolarLabelsPosition.Middle,
                    Fill = new SolidColorPaint(SKColors.LightGreen)
                },
                new PieSeries<double>
                {
                    Name = "falsch beantwortet",
                    Values = new double[] { statisticService.GetAllNotKnown(user) },
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
                    Values = statisticService.GetLearnedPerDay(user),
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

        private void Form1_Load(object sender, EventArgs e)
        {
            GetNewQuestion();
            GetRoutines();
        }

        private void GetRoutines()
        {
            dataGridView1.DataSource = routineService.GetAll();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name == "LastRunTime" || column.Name == "NextRunTime" || column.Name == "Name")
                {
                    column.Visible = true;
                }
                else
                {
                    column.Visible = false;
                }
            }

            dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Name"].DisplayIndex = 0;

            dataGridView1.Columns["LastRunTime"].DisplayIndex = 1;
            dataGridView1.Columns["NextRunTime"].DisplayIndex = 2;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void GetNewQuestion()
        {
            var newId = learnProgressService.GetNextMultipleChoiceSetIDToLearn(user);

            question = multipleChoiceSetService.GetSpecificQuestion(newId);

            answerList = multipleChoiceSetService.GetAnswers(question.Id);

            lblQuestion.Text = question.Question;

            dataGridView2.DataSource = answerList;

            int rowHeight = dataGridView2.Height / dataGridView2.Rows.Count;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Height = rowHeight;
            }

            foreach (DataGridViewColumn col in dataGridView2.Columns)
            {
                col.DefaultCellStyle.SelectionBackColor = Color.White;
                col.DefaultCellStyle.SelectionForeColor = Color.Black;
            }

            dataGridView2.Columns["CorrectAnswer"].Visible = false;
            dataGridView2.Columns["Id"].Visible = false;

            dataGridView2.Columns["Answer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns["Answer"].ReadOnly = true;
            dataGridView2.Columns["Answer"].DisplayIndex = 1;

            dataGridView2.Columns["GivenAnswer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView2.Columns["GivenAnswer"].DisplayIndex = 0;

            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ScrollBars = ScrollBars.None;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToResizeColumns = false;

            dataGridView2.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var validateAnswer = learnProgressService.ValidateAnswer(answerList);
            button1.Enabled = true;
            button2.Enabled = false;

            var learnProgress = new LearnProgress()
            {
                MultipleChoiceSet_Id = question.Id,
                Student_Id = user.Id,
            };

            var statistic = new Statistic()
            {
                Student_Id = user.Id,
                MultipleChoiceSet_Id = question.Id,
                DateTime = DateTime.Now,
                WasKnown = validateAnswer
            };

            learnProgressService.UpdateLearnProgress(learnProgress, statistic);

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow)
                {
                    var givenAnswer = row.Cells["GivenAnswer"].Value;
                    var correctAnswer = row.Cells["CorrectAnswer"].Value;

                    if (givenAnswer != null && correctAnswer != null)
                    {
                        if ((givenAnswer.Equals(true) && givenAnswer.Equals(correctAnswer)) || givenAnswer.Equals(false) && correctAnswer.Equals(true))
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            row.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                        }
                        else if (givenAnswer.Equals(true))
                        {
                            row.DefaultCellStyle.SelectionBackColor = Color.LightCoral;
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                        }
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetNewQuestion();
            btnNotKnown.Visible = false;
            btnKnown.Visible = false;
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime datePart = dateTimePicker1.Value.Date;
            DateTime timePart = dateTimePicker2.Value;

            DateTime combinedDateTime = new DateTime(datePart.Year, datePart.Month, datePart.Day, timePart.Hour, timePart.Minute, timePart.Second);
            routineService.Create(textBox1.Text, combinedDateTime);
            GetRoutines();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            routineService.DeleteAll();
            GetRoutines();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3)
                InitializeStats();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                try
                {
                    string name = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                    routineService.Delete(name);
                    GetRoutines();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
