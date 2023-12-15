using ProjektarbeitLernApp.Service;
using ProjektarbeitLernApp.PLAContext;
using ProjektarbeitLernApp.Model.Auth;
using ProjektarbeitLernApp.Model.LearnApp;
using System.Text.Json.Nodes;
using System.Text.Json;
internal class Program
{
    private static void Main(string[] args)
    {
        //var routine = new RoutineService();
        ////routine.Create("Lernapp 2", new DateTime(2023, 12, 8, 9, 57, 00));
        //foreach(var r in routine.GetAll())
        //{
        //    Console.WriteLine(r.Name);
        //    Console.WriteLine(r.NextRunTime);
        //}

        //routine.DeleteAll();

        //var dbContext = new DatabasePLAContext();

        //var userService = new UserService(dbContext);
        //var multipleChoiceSetService = new MultipleChoiceSetService(dbContext);
        //var statisticService = new StatisticService(dbContext);
        //var learnProgressService = new LearnProgressService(dbContext, statisticService);

        ////var n = multipleChoiceSetService.GetNewQuestion();
        ////Console.WriteLine("Frage: " + n.Question);
        ////var answers = multipleChoiceSetService.GetAnswers(n.Id);

        ////foreach (var answer in answers)
        ////{
        ////    Console.WriteLine("Id: " + answer.Id);
        ////    Console.WriteLine("Antwort: " + answer.Answer);
        ////    Console.WriteLine("Korrekte Antwort: " + answer.CorrectAnswer);
        ////}

        //while (true)
        //{
        //    var user = new User()
        //    {
        //        Id = 3
        //    };

        //    var newId = learnProgressService.GetNextMultipleChoiceSetIDToLearn(user);

        //    var question = multipleChoiceSetService.GetSpecificQuestion(newId);

        //    Console.WriteLine($"ID: {question.Id}, Question: {question.Question}");
        //    var answers = multipleChoiceSetService.GetAnswers(question.Id);

        //    foreach (var answer in answers)
        //    {
        //        Console.WriteLine($"{answer.Id}) {answer.Answer}");
        //        Console.WriteLine("Ist diese Antwort richtig? J / N");
        //        var choice = Console.ReadLine();
        //        if (choice.ToUpper().Equals("J"))
        //            answer.GivenAnswer = true;
        //    }

        //    var validateAnswer = learnProgressService.ValidateAnswer(answers);
        //    Console.WriteLine(validateAnswer);
        //    //var wasKnown = 0;
        //    //var wasNotKnown = 0;

        //    //if (validateAnswer == false)
        //    //    wasNotKnown++;
        //    //else
        //    //    wasKnown++;

        //    var learnProgress = new LearnProgress()
        //    {
        //        MultipleChoiceSet_Id = question.Id,
        //        Student_Id = user.Id,
        //    };

        //    var statistic = new Statistic()
        //    {
        //        Student_Id = user.Id,
        //        MultipleChoiceSet_Id = question.Id,
        //        DateTime = DateTime.Now,
        //        WasKnown = validateAnswer
        //    };

        //    learnProgressService.UpdateLearnProgress(learnProgress, statistic);
        //}



        //var n = multipleChoiceSetService.GetMultipleChoiceSets(3);
        //foreach ( var choiceSet in n )
        //{
        //    Console.WriteLine($"ID: {choiceSet.Id}, Question: {choiceSet.Question}");
        //    var answers = multipleChoiceSetService.GetAnswers(choiceSet.Id);
        //    foreach(var answer in answers)
        //    {
        //        Console.WriteLine($"{answer.Id}) {answer.Answer}");
        //        Console.WriteLine("Ist diese Antwort richtig? J / N");
        //        var choice = Console.ReadLine();
        //        if (choice.ToUpper().Equals("J"))
        //            answer.GivenAnswer = true;
        //    }
        //    var validateAnswer = learnProgressService.ValidateAnswer(answers);
        //    Console.WriteLine(validateAnswer);
        //    var wasKnown = 0;
        //    var wasNotKnown = 0;

        //    if (validateAnswer == false)
        //        wasNotKnown++;
        //    else
        //        wasKnown++;

        //    var learnProgress = new LearnProgress()
        //    {
        //        MultipleChoiceSet_Id = choiceSet.Id,
        //        Student_Id = 1,
        //        WasKnown = wasKnown,
        //        WasNotKnown = wasNotKnown
        //    };

        //    learnProgressService.SaveLearnProgress(learnProgress);
        //}



        //var newUser = new User();
        //newUser.Name = "Andreas";
        //newUser.LastName = "Hülsmann";
        //newUser.Email = "mail@huelsmann-andreas.de";
        //newUser.Password = "12345678";
        //newUser.Role = 1;

        //var registered = userService.Register(newUser);
        //var questions = multipleChoiceSetService.GetAllQuestions();
        //learnProgressService.InitiateLearnProgress(questions, newUser);

        //Console.WriteLine(registered);

        //var loggedIn = userService.Login(newUser);
        //Console.WriteLine("logged in:" + loggedIn);

        //var answer = new Answers()
        //{
        //    Id = 1,
        //    Answer = "Alma",
        //    CorrectAnswer = true,
        //    GivenAnswer = false
        //};

        //var answer2 = new Answers()
        //{
        //    Id = 2,
        //    Answer = "Abby",
        //    CorrectAnswer = false,
        //    GivenAnswer = false
        //};

        //var answer3 = new Answers()
        //{
        //    Id = 3,
        //    Answer = "Alice",
        //    CorrectAnswer = false,
        //    GivenAnswer = false
        //};

        //var answer4 = new Answers()
        //{
        //    Id = 4,
        //    Answer = "Ava",
        //    CorrectAnswer = false,
        //    GivenAnswer = false
        //};

        //var answers = new List<Answers>();
        //answers.Add(answer);
        //answers.Add(answer2);
        //answers.Add(answer3);
        //answers.Add(answer4);

        //Console.WriteLine(JsonSerializer.Serialize(answers));

    }
}