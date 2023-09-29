using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextMenu.Menus
{
    internal class BoxTextMenu : TextMenu
    {
        private string[] _Options;
        private string _TextHeader;


        private List<int[]> _OptionsPositions = new List<int[]>();
        public BoxTextMenu(string textHeader, string[] options)
        {

            _Options = options;
            _TextHeader = textHeader;
        }

        public int show()
        {

            updateCursorPostion(4, _BufferY);
            write(_TextHeader + "\n");
            int extraSpacing = 10;
            int space = (_MaxLength - _BufferY) - extraSpacing;
            createBox(20,20,"i");
            for (int i = 0; i < _Options.Length; i++) {
                
            }

            createBorder();
            return 1;
        }

        private void createBox(int posx, int posy, string item) {
            int auxX = 4;
            int auxY = 2;
            for (int i = 0; i < auxY; i++)
            {
                updateCursorPostion(posx + 0, posy + i);
                Console.Write(_Walls[0]);
                updateCursorPostion(posx + auxX, posy + i);
                Console.Write(_Walls[3]);
                
            }
            for(int i = 0; i < auxX; i++)
            {
                updateCursorPostion(posx + i, posy + 0);
                Console.Write(_Walls[1]);
                updateCursorPostion(posx + i, posy + auxY);
                Console.Write(_Walls[2]);
            }
            updateCursorPostion(posx + 0, posy + 0);
            Console.Write(_Corners[0]);
            updateCursorPostion(posx + 0, posy + auxY);
            Console.Write(_Corners[1]);
            updateCursorPostion(posx + auxX, posy + auxY);
            Console.Write(_Corners[2]);
            updateCursorPostion(posx + auxX, posy + 0);
            Console.Write(_Corners[3]);
            updateCursorPostion(posx + auxX / 2, posy + auxY / 2);
            Console.Write(item);
            updateCursorPostion(0, posy + auxY + 1);

        }


        private int chooseOption()
        {
            ValueTuple<Int32, Int32> pos = Console.GetCursorPosition();
            int optionPicked = 0;
            updateCursorPostion(_OptionsPositions[optionPicked][0], _OptionsPositions[optionPicked][1]);
            write(">>>", _OptionsPositions[optionPicked][0] - 3, _OptionsPositions[optionPicked][1]);
            String input = Console.ReadKey(true).Key.ToString();

            while (!(input == "Enter"))
            {
                int prev = optionPicked;
                switch (input)
                {
                    case "S":
                        optionPicked++;
                        break;

                    case "W":
                        optionPicked--;
                        break;
                }

                if (optionPicked < 0) optionPicked = _OptionsPositions.Count - 1;
                if (optionPicked == _OptionsPositions.Count) optionPicked = 0;
                write("   ", _OptionsPositions[prev][0] - 3, _OptionsPositions[prev][1]);
                updateCursorPostion(_OptionsPositions[optionPicked][0], _OptionsPositions[optionPicked][1]);
                write(">>>", _OptionsPositions[optionPicked][0] - 3, _OptionsPositions[optionPicked][1]);
                input = Console.ReadKey(true).Key.ToString();

            }
            updateCursorPostion(pos.Item1, pos.Item2);
            Console.Clear();
            return optionPicked;
        }

    }
}
