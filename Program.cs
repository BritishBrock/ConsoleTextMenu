using ConsoleTextMenu.Menus;
using System.Diagnostics;

namespace ConsoleTextMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BasicTextMenu bT = new BasicTextMenu("Que tal tu dia? \n", new string[] { "bien", "no muy bien", "fatalfatalfatalfatalfatalfatalf fatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalvfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalvfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalvfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalvfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalvatalfatalfatalfatalfatalfatalv" });
            //Console.Write(bT.show());
            //ScrollingTextMenu sT = new ScrollingTextMenu(new string[] { "hello?", "goodbye?", "who goigs goigs gon=??who goigs on=??who goigon=??who goigs on=??who goigon=??who goigs on=??who goigon=??who goigs on=??who goigon=??who goigs on=??who goigon=??who goigs on=??who goigs gon=??who goigs gon=??who goigs gon=??who goigs gon=??who goigs gon=??who goigs gon=??who goigs gon=??who goigs gon=??", "yes" });
            //sT.inicialize();
            BoxTextMenu bxT = new BoxTextMenu("Que tal tu dia? \n", new string[] { "bien", "no muy bien", "fatalfatalfatalfatalfatalfatalf fatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalvfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalvfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalvfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalvfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalfatalvatalfatalfatalfatalfatalfatalv" });
            Console.Write(bxT.show());
        }
    }
}