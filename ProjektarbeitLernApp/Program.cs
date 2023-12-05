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
        var dbContext = new DatabasePLAContext();

        var userService = new UserService(dbContext);
        var multipleChoiceSetService = new MultipleChoiceSetService(dbContext);


        //var n = multipleChoiceSetService.GetNewQuestion();
        //Console.WriteLine("Frage: " + n.Question);
        //var answers = multipleChoiceSetService.GetAnswers(n.Id);

        //foreach (var answer in answers)
        //{
        //    Console.WriteLine("Id: " + answer.Id);
        //    Console.WriteLine("Antwort: " + answer.Answer);
        //    Console.WriteLine("Korrekte Antwort: " + answer.CorrectAnswer);
        //}

        var n = multipleChoiceSetService.GetMultipleChoiceSets(5);

        foreach( var choiceSet in n )
        {
            Console.WriteLine($"ID: {choiceSet.Id}, Question: {choiceSet.Question}");
        }

        //var newUser = new User();
        //newUser.Name = "Andreas";
        //newUser.LastName = "Hülsmann";
        //newUser.Email = "mail@huelsmann-andreas.de";
        //newUser.Password = "12345678";
        //newUser.Role = 1;

        //var registered = userService.Register(newUser);
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