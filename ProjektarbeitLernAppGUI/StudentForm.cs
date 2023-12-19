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
    /// <summary>
    /// Das Hauptformular für Studierende, das verschiedene Funktionen wie das Lernen, die Prüfungsvorbereitung und die Statistikverwaltung bereitstellt.
    /// </summary>
    public partial class StudentForm : Form
    {
        private DatabasePLAContext dbContext;
        private MultipleChoiceSetService multipleChoiceSetService;
        private StatisticService statisticService;
        private LearnProgressService learnProgressService;
        private RoutineService routineService;
        private UserService userService;
        private User user;
        private List<Answers> answerList;
        private List<Answers> examAnswerList;
        private MultipleChoiceSet question;
        private List<MultipleChoiceSet> examList;
        private MultipleChoiceSet examQuestion;
        private ExamSimulationService examService;
        private Dictionary<TabPage, bool> tabPageValidationResults = new Dictionary<TabPage, bool>();
        private TimeSpan examTime;

        private bool isValidationPerformed;

        /// <summary>
        /// Dieser Konstruktor initialisiert eine Instanz des StudentForm-Formulars.
        /// Er nimmt eine Instanz von DatabasePLAContext und einen Benutzer (User) als Parameter entgegen.
        /// Die Methode initialisiert verschiedene Dienste und Daten für das Formular, setzt die Position des Formulars,
        /// und deaktiviert vorübergehend die Schaltfläche "Nächste Frage", bis eine Frage geladen wurde.
        /// </summary>
        /// <param name="dbContext">Die Datenbankkontextinstanz (DatabasePLAContext).</param>
        /// <param name="user">Der Benutzer (User), der sich im Formular anmeldet.</param>
        public StudentForm(DatabasePLAContext dbContext, User user)
        {
            this.dbContext = dbContext;

            multipleChoiceSetService = new MultipleChoiceSetService(dbContext);
            statisticService = new StatisticService(dbContext);
            learnProgressService = new LearnProgressService(dbContext, statisticService);
            routineService = new RoutineService();
            this.user = user;

            InitializeComponent();
            InitializeProfile();
            InitializeStats();

            this.StartPosition = FormStartPosition.CenterScreen;
            btnNextQuestion.Enabled = false;
        }

        /// <summary>
        /// Initialisiert das Benutzerprofil mit persönlichen Daten.
        /// </summary>
        private void InitializeProfile()
        {
            userService = new UserService(dbContext);
            var dbUser = userService.GetUserById(user.Id);
            txtName.Text = dbUser.Name;
            txtLastName.Text = dbUser.LastName;
            txtEmail.Text = dbUser.Email;
        }

        /// <summary>
        /// Initialisiert die statistischen Grafiken und Fortschrittsanzeigen für den Benutzer.
        /// </summary>
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

        /// <summary>
        /// Diese Methode wird beim Laden des Formulars ausgeführt und initialisiert die Anzeige.
        /// Sie ruft die Methode GetNewQuestion auf, um eine neue Frage zu laden, und die Methode GetRoutines, um Routinedaten abzurufen und im DataGridView anzuzeigen.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Ereignisargument.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            GetNewQuestion();
            GetRoutines();
        }

        /// <summary>
        /// Diese Methode lädt Routinedaten und zeigt sie im DataGridView-Steuerelement an.
        /// Sie ruft die Methode routineService.GetAll() auf, um Routinedaten abzurufen und im DataGridView anzuzeigen.
        /// Anschließend werden die sichtbaren Spalten und deren Anzeigereihenfolge konfiguriert.
        /// Die Methode passt die Spaltenbreite für die "Name"-Spalte an und blendet den Zeilenheader aus.
        /// </summary>
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

        /// <summary>
        /// Lädt eine neue Frage für den Benutzer und bereitet die Antwortmöglichkeiten vor.
        /// </summary>
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

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn die Schaltfläche "Frage bewerten" geklickt wird.
        /// Sie validiert die gegebenen Antworten und aktualisiert den Lernfortschritt und die Statistik des Benutzers.
        /// Nach der Validierung wird die Schaltfläche "Nächste Frage" aktiviert.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Event-Argument.</param>
        private void btnEvaluateQuestion_Click(object sender, EventArgs e)
        {
            var validateAnswer = learnProgressService.ValidateAnswer(answerList);
            btnNextQuestion.Enabled = true;
            btnEvaluateQuestion.Enabled = false;

            var learnProgress = new LearnProgress()
            {
                MultipleChoiceSet_Id = question.Id,
                User_Id = user.Id,
            };

            var statistic = new Statistic()
            {
                User_Id = user.Id,
                MultipleChoiceSet_Id = question.Id,
                DateTime = DateTime.Now,
                WasKnown = validateAnswer
            };

            learnProgressService.UpdateLearnProgress(learnProgress, statistic);

            ValidateGridView(dataGridView2);

        }

        /// <summary>
        /// Diese Methode validiert die Antworten in einer DataGridView.
        /// Sie vergleicht die gegebenen Antworten mit den richtigen Antworten und markiert die Zeilen entsprechend.
        /// Wenn mindestens eine falsche Antwort gegeben wurde, wird 'isValid' auf 'false' gesetzt.
        /// </summary>
        /// <param name="dataGridView">Die DataGridView, die die Antworten enthält.</param>
        /// <returns>'true', wenn alle Antworten korrekt sind, andernfalls 'false'.</returns>
        private bool ValidateGridView(DataGridView dataGridView)
        {
            var isValid = true;

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
                        }
                        else if (givenAnswer.Equals(true) && correctAnswer.Equals(false))
                        {
                            row.DefaultCellStyle.SelectionBackColor = Color.LightCoral;
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            isValid = false;
                        }
                        else if (givenAnswer.Equals(false) && correctAnswer.Equals(true))
                        {
                            row.DefaultCellStyle.SelectionBackColor = Color.LightGreen; //LightBlue
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            isValid = false;
                        }
                    }
                }
            }

            return isValid;
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn die Schaltfläche "Nächste Frage" geklickt wird.
        /// Sie ruft die Methode "GetNewQuestion" auf, um eine neue Frage zu erhalten.
        /// Nachdem eine neue Frage geladen wurde, wird die Schaltfläche "Nächste Frage" deaktiviert
        /// und die Schaltfläche "Frage bewerten" aktiviert.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Event-Argument.</param>
        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            GetNewQuestion();
            btnNextQuestion.Enabled = false;
            btnEvaluateQuestion.Enabled = true;
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn die Schaltfläche "Erstellen" (button3) geklickt wird.
        /// Sie erstellt eine Routine mit dem angegebenen Namen und Datum/Uhrzeit-Kombination
        /// aus den Werten der DateTimePicker-Elemente.
        /// Nach dem Erstellen der Routine wird die Methode "GetRoutines" aufgerufen, um die Daten in der DataGridView zu aktualisieren.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Event-Argument.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime datePart = dateTimePicker1.Value.Date;
            DateTime timePart = dateTimePicker2.Value;

            DateTime combinedDateTime = new DateTime(datePart.Year, datePart.Month, datePart.Day, timePart.Hour, timePart.Minute, timePart.Second);
            routineService.Create(textBox1.Text, combinedDateTime);
            GetRoutines();
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn die Schaltfläche "Alle löschen" (button7) geklickt wird.
        /// Sie löscht alle vorhandenen Routinen mithilfe des RoutineService.
        /// Nach dem Löschen der Routinen wird die Methode "GetRoutines" aufgerufen, um die DataGridView zu aktualisieren.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Event-Argument.</param>
        private void button7_Click(object sender, EventArgs e)
        {
            routineService.DeleteAll();
            GetRoutines();
        }

        /// <summary>
        /// Diese Methode initialisiert die Prüfungssimulation. Sie richtet die Benutzeroberfläche ein, erstellt eine Liste von Prüfungsfragen
        /// und füllt die Registerkarten im TabControl mit den Fragen und Antwortmöglichkeiten.
        /// </summary>
        private void InitializeExamSimulation()
        {
            panel4.Visible = true;
            label4.Text = "00:30:00";
            button9.Enabled = true;
            examTime = TimeSpan.FromMinutes(30);

            examList = new List<MultipleChoiceSet>();
            examService = new ExamSimulationService(dbContext, multipleChoiceSetService);

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

                TabPage tabPage = new TabPage(i++.ToString()); 

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

        /// <summary>
        /// Diese Methode wird aufgerufen, um das Zeichnen eines TabPage-Tabs im TabControl2 zu steuern.
        /// Sie ermöglicht die Anpassung der TabPage-Farbe basierend auf der Validierung und die Ausrichtung des Texts.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Event-Argument.</param>
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

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn sich der Wert einer Zelle in der DataGridView ändert.
        /// Sie überwacht Änderungen an den gegebenen Antworten und aktualisiert die Prüfungsergebnisse entsprechend.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Event-Argument.</param>
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

        /// <summary>
        /// Aktualisiert die gegebene Antwort in einem MultipleChoiceSet basierend auf den übergebenen Parametern.
        /// </summary>
        /// <param name="multipleChoiceSetId">Die ID des MultipleChoiceSets.</param>
        /// <param name="answerId">Die ID der Antwort.</param>
        /// <param name="isChecked">Gibt an, ob die Antwort ausgewählt wurde.</param>
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
                }
            }
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn der Index im tabControl1 geändert wird.
        /// Sie aktualisiert die Benutzeroberfläche basierend auf dem ausgewählten Tab.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Event-Argument.</param>
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

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn der "Löschen"-Button (button5) geklickt wird.
        /// Sie löscht eine Routine basierend auf der ausgewählten Zeile in der dataGridView1.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Event-Argument.</param>
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

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn der "Nächste" Button (button4) in der TabControl2 geklickt wird.
        /// Sie wechselt zur nächsten Registerkarte, sofern verfügbar.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Event-Argument.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex < tabControl2.TabCount - 1)
                tabControl2.SelectedIndex++;
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn der "Vorherige" Button (button8) in der TabControl2 geklickt wird.
        /// Sie wechselt zur vorherigen Registerkarte, sofern verfügbar.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Event-Argument.</param>
        private void button8_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex > 0)
                tabControl2.SelectedIndex--;
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn der "Validieren" Button (button9) geklickt wird.
        /// Sie führt die Validierung der Prüfung durch.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Event-Argument.</param>
        private void button9_Click(object sender, EventArgs e)
        {
            ValidateExam();
        }

        /// <summary>
        /// Validiert die Prüfungsergebnisse und speichert die Ergebnisse.
        /// </summary>
        private void ValidateExam()
        {
            List<MultipleChoiceSet> multipleChoiceSetList = new List<MultipleChoiceSet>();

            var correctAnswers = 0;
            var totalAnswers = 0;
            foreach (TabPage tabPage in tabControl2.TabPages)
            {
                foreach (Control container in tabPage.Controls)
                {
                    foreach (Control control in container.Controls)
                    {
                        if (control is DataGridView dataGridView)
                        {
                            var multipleChoiceSet = multipleChoiceSetService.GetSpecificQuestion((int)control.Tag);
                            multipleChoiceSet.Answers = JsonSerializer.Serialize(dataGridView.DataSource as List<Answers>);
                            multipleChoiceSetList.Add(multipleChoiceSet);

                            bool isValid = ValidateGridView(dataGridView);
                            if (!tabPageValidationResults.ContainsKey(tabPage))
                                tabPageValidationResults.Add(tabPage, isValid);
                            else
                                tabPageValidationResults[tabPage] = isValid;

                            if (isValid)
                                correctAnswers++;
                            totalAnswers++;
                            control.Enabled = false;
                        }
                    }
                }
            }

            var hasPassed = false;
            if (totalAnswers / 2 < correctAnswers)
                hasPassed = true;


            examService.SaveExamSimulation(new ExamSimulation()
            {
                MultipleChoiceList = JsonSerializer.Serialize(multipleChoiceSetList),
                HasPassed = hasPassed,
                User_Id = user.Id
            });

            button9.Enabled = false;
            timer1.Stop();
            label4.Text = "Zeit ist um! Du hast " + (hasPassed ? "bestanden!" : "nicht bestanden!");
            progressBar2.Value = 0;
            isValidationPerformed = true;
            tabControl2.Invalidate();
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn der "Schließen" Button (button10) in der Prüfungssimulation geklickt wird.
        /// Sie blendet das Panel zur Prüfungssimulation aus und startet den Timer für die Prüfungszeit.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Event-Argument.</param>
        private void button10_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            timer1.Enabled = true;
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn der Timer für die Prüfungszeit (timer1) tickt.
        /// Sie aktualisiert die verbleibende Prüfungszeit und überprüft, ob die Zeit abgelaufen ist, um die Prüfung zu validieren.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Event-Argument.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            examTime = examTime.Subtract(TimeSpan.FromSeconds(1));
            label4.Text = examTime.ToString("hh\\:mm\\:ss");
            progressBar2.Value = (int)examTime.TotalSeconds;

            if (examTime.TotalSeconds <= 0)
                ValidateExam();
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn der "E-Mail ändern" Button (button6) geklickt wird.
        /// Sie aktualisiert die E-Mail-Adresse des Benutzers und zeigt eine Erfolgsmeldung an.
        /// </summary>
        /// <param name="sender">Das auslösende Objekt.</param>
        /// <param name="e">Das Event-Argument.</param>
        private void button6_Click(object sender, EventArgs e)
        {
            user.Email = txtEmail.Text;
            user = userService.EditMail(user);
            MessageBox.Show("E-Mail erfolgreich geändert.");
        }
    }
}
