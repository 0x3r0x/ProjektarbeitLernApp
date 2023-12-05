using ProjektarbeitLernApp.Service;
using ProjektarbeitLernApp.PLAContext;
using ProjektarbeitLernApp.Model.Auth;
internal class Program
{
    private static void Main(string[] args)
    {
        var userService = new UserService(new DatabasePLAContext());

        var newUser = new User();
        newUser.Name = "Andreas";
        newUser.LastName = "Hülsmann";
        newUser.Email = "mail@huelsmann-andreas.de";
        newUser.Password = "12345678";
        newUser.Role = 1;

        //var registered = userService.Register(newUser);
        //Console.WriteLine(registered);

        var loggedIn = userService.Login(newUser);
        Console.WriteLine("logged in:" + loggedIn);
    }
}