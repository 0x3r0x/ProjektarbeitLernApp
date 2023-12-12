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
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel.DataAnnotations;


namespace ProjektarbeitLernAppGUI
{
    public partial class StudentForm : Form
    {
        private DatabasePLAContext dbContext;
        private MultipleChoiceSetService multipleChoiceSetService;
        private StatisticService statisticService;
        private LearnProgressService learnProgressService;
        private RoutineService routineService;
        private User user;
        private List<Answers> answerList;
        private List<Answers> examAnswerList;
        private MultipleChoiceSet question;
        private List<MultipleChoiceSet> examList;
        private MultipleChoiceSet examQuestion;
        private ExamSimulationService examService;
        private Dictionary<TabPage, bool> tabPageValidationResults = new Dictionary<TabPage, bool>();
        private TimeSpan examTime = TimeSpan.FromMinutes(30);

        private bool isValidationPerformed;

        public StudentForm(DatabasePLAContext dbContext, User user)
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

            if (allKnown > 0 || allNotKnown > 0)
                panel3.Visible = false;
            else
                panel3.Visible = true;

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
                    column.Visible = true;
                else
                    column.Visible = false;
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
                row.Height = rowHeight;

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

            ValidateExamGridView(dataGridView2);

            //foreach (DataGridViewRow row in dataGridView2.Rows)
            //{
            //}
        }

        private bool ValidateExamGridView(DataGridView dataGridView)
        {
            var isValid = false;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var givenAnswer = Convert.ToBoolean(row.Cells["GivenAnswer"].Value);
                    var correctAnswer = Convert.ToBoolean(row.Cells["CorrectAnswer"].Value);

                    if (givenAnswer != null && correctAnswer != null)
                    {
                        if (givenAnswer.Equals(true) && givenAnswer.Equals(correctAnswer))
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            row.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                            isValid = true;
                        }
                        else if (givenAnswer.Equals(true))
                        {
                            row.DefaultCellStyle.SelectionBackColor = Color.LightCoral;
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                        }
                        else if (givenAnswer.Equals(false) && correctAnswer.Equals(true))
                        {
                            row.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                            row.DefaultCellStyle.BackColor = Color.LightBlue;
                        }
                    }
                }
            }

            return isValid;
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

        private void InitializeExamSimulation()
        {
            panel4.Visible = true;
            label4.Text = "00:30:00";
            button9.Enabled = true;

            examList = new List<MultipleChoiceSet>();
            examService = new ExamSimulationService(learnProgressService, multipleChoiceSetService);

            examService.CreateExamList(15);
            examList = examService.GetExamList();

            var totalSeconds = (int)TimeSpan.FromMinutes(30).TotalSeconds;
            progressBar2.Maximum = totalSeconds;
            progressBar2.Value = totalSeconds;

            tabControl2.TabPages.Clear();
            tabControl2.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl2.DrawItem += TabControl2_DrawItem;

            var i = 1;
            foreach (var set in examList)
            {

                TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                tableLayoutPanel.Dock = DockStyle.Fill;
                tableLayoutPanel.RowCount = 2;
                tableLayoutPanel.ColumnCount = 1;
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

                TabPage tabPage = new TabPage(i++.ToString()); // set.Id.ToString()

                Label label = new Label();
                label.Text = multipleChoiceSetService.GetSpecificQuestion(set.Id).Question;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.AutoSize = false;
                label.Height = 67;
                label.Width = 1083;
                label.Font = new Font("Segoe UI", 11.25f);
                tableLayoutPanel.Controls.Add(label, 0, 0);

                DataGridView dataGridView = new DataGridView();
                dataGridView.Dock = DockStyle.Fill;
                dataGridView.DataSource = multipleChoiceSetService.GetAnswers(set.Id);
                tableLayoutPanel.Controls.Add(dataGridView, 0, 1);

                tabPage.Controls.Add(tableLayoutPanel);
                tabControl2.TabPages.Add(tabPage);

                //datagirdviewstyling

                int rowHeight = dataGridView.Height / dataGridView.Rows.Count;

                foreach (DataGridViewRow row in dataGridView.Rows)
                    row.Height = rowHeight;

                foreach (DataGridViewColumn col in dataGridView.Columns)
                {
                    col.DefaultCellStyle.SelectionBackColor = Color.White;
                    col.DefaultCellStyle.SelectionForeColor = Color.Black;
                }

                dataGridView.Columns["CorrectAnswer"].Visible = false;
                dataGridView.Columns["Id"].Visible = false;

                dataGridView.Columns["Answer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns["Answer"].ReadOnly = true;
                dataGridView.Columns["Answer"].DisplayIndex = 1;

                dataGridView.Columns["GivenAnswer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns["GivenAnswer"].DisplayIndex = 0;

                dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dataGridView.AllowUserToAddRows = false;
                dataGridView.ScrollBars = ScrollBars.None;
                dataGridView.AllowUserToResizeRows = false;
                dataGridView.AllowUserToResizeColumns = false;
                dataGridView.RowHeadersVisible = false;
                dataGridView.ColumnHeadersVisible = false;
                dataGridView.Tag = set.Id;
                dataGridView.CellValueChanged += DataGridView_CellValueChanged;

                dataGridView.Refresh();
            }

        }

        private void TabControl2_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl2.TabPages[e.Index];
            bool isValid = false;

            if (isValidationPerformed && tabPageValidationResults.TryGetValue(page, out isValid))
            {
                Color tabColor = isValid ? Color.LightGreen : Color.LightCoral;

                using (Brush br = new SolidBrush(tabColor))
                {
                    e.Graphics.FillRectangle(br, e.Bounds);
                    SizeF sz = e.Graphics.MeasureString(page.Text, e.Font);
                    e.Graphics.DrawString(page.Text, e.Font, Brushes.Black, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2);
                }
            }
            else
            {
                using (Brush textBrush = new SolidBrush(page.ForeColor))
                {
                    SizeF sz = e.Graphics.MeasureString(page.Text, e.Font);
                    e.Graphics.DrawString(page.Text, e.Font, Brushes.Black, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2);
                }
            }
        }


        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DataGridView dataGridView = sender as DataGridView;
                if (dataGridView != null)
                {
                    var multipleChoiceSetId = (int)dataGridView.Tag;
                    var answerId = (int)dataGridView.Rows[e.RowIndex].Cells["Id"].Value;

                    bool isChecked = Convert.ToBoolean(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                    UpdateAnswerInMultipleChoiceSet(multipleChoiceSetId, answerId, isChecked);
                }
            }
        }

        private void UpdateAnswerInMultipleChoiceSet(int multipleChoiceSetId, int answerId, bool isChecked)
        {
            var multipleChoiceSet = examList.Find(set => set.Id == multipleChoiceSetId);
            if (multipleChoiceSet != null)
            {
                var answers = JsonSerializer.Deserialize<List<Answers>>(multipleChoiceSet.Answers);

                var answer = answers.Find(a => a.Id == answerId);
                if (answer != null)
                {
                    answer.GivenAnswer = isChecked;
                    multipleChoiceSet.Answers = JsonSerializer.Serialize(answers);
                    //examService.UpdateExamList(examList);
                }
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            examList = new List<MultipleChoiceSet>();

            switch (tabControl1.SelectedIndex)
            {
                case 1:
                    isValidationPerformed = false;
                    InitializeExamSimulation();
                    break;
                case 3:
                    InitializeStats();
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex < tabControl2.TabCount - 1)
            {
                tabControl2.SelectedIndex++;
                button8.Enabled = true;
                if (tabControl2.SelectedIndex == tabControl2.TabCount - 1)
                {
                    button4.Enabled = false;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex > 0)
            {
                tabControl2.SelectedIndex--;
                button4.Enabled = true;
                if (tabControl2.SelectedIndex == 0)
                {
                    button8.Enabled = false;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ValidateExam();
        }

        private void ValidateExam()
        {
            foreach (TabPage tabPage in tabControl2.TabPages)
            {
                foreach (Control container in tabPage.Controls)
                {
                    foreach (Control control in container.Controls)
                    {
                        if (control is DataGridView dataGridView)
                        {
                            bool isValid = ValidateExamGridView(dataGridView);
                            if (!tabPageValidationResults.ContainsKey(tabPage))
                                tabPageValidationResults.Add(tabPage, isValid);
                            else
                                tabPageValidationResults[tabPage] = isValid;

                            control.Enabled = false;
                        }
                    }
                }
            }

            button9.Enabled = false;
            timer1.Stop();
            label4.Text = "Zeit ist um!";
            progressBar2.Value = 0;
            isValidationPerformed = true;
            tabControl2.Invalidate();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            examTime = examTime.Subtract(TimeSpan.FromSeconds(1));

            label4.Text = examTime.ToString("hh\\:mm\\:ss");

            int newProgressValue = (int)examTime.TotalSeconds;
            if (newProgressValue < progressBar2.Maximum)
            {
                progressBar2.Value = progressBar2.Maximum;
                progressBar2.Value = newProgressValue;
            }

            if (examTime.TotalSeconds <= 0)
            {
                ValidateExam();
            }
        }

    }
}
