using ConsoleTextMenu.Menus;

namespace ConsoleTextMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicTextMenu bT = new BasicTextMenu("BRUH\n", new string[] { "hello?", "goodbye?", "who goigs gon=??", "yes" });
            Console.Write(bT.show());


            //ScrollingTextMenu sT = new ScrollingTextMenu(new string[] { "hello?", "goodbye?", "who goigs gon=??", "yes" });
            //sT.inicialize();
        }
    }
}