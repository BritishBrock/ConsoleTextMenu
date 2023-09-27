using ConsoleTextMenu.Menus;

namespace ConsoleTextMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicTextMenu bT = new BasicTextMenu("BRUH!",new string[] {"hello?","goodbye?", "whot is is  is gois is  is gon=??" });
            bT.show();
        }
    }
}