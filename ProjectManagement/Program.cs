using ProjectManagement.UI;

namespace ProjectManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            UserInterface userInterface = new UserInterface(context);

            userInterface.Run();
        }
    }
}
