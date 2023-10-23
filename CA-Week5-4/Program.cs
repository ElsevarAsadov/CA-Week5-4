using CA_Week5_4.clss;
using CA_Week5_4.ConsoleApp;

namespace CA_Week5_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Department dep = new("AMD", 2);

            App app = new();

            app.Start(dep);
        }
    }
}