using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextMenu.Menus
{
    internal class BoxTextMenu : TextMenu
    {

        public struct Spacing {
            public int _x { get; set; }
            public int _y { get; set; }
            public Spacing(int x, int y) {
                _x = x;
                _y = y;
            }
        }
        public struct Size
        {
            public int _width { get; set; }
            public int _height { get; set; }
            public Size(int width, int height)
            {
                _width = width;
                _height = height;
            }
        }

        private string[] _Options;
        private string _TextHeader;
        private int _RowsAmount = 3;
        private Size _Size = new Size(4,2);
        private Spacing _Spacing = new Spacing(6, 3);
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



            int currentMaxHeight = _Maxheight;
            for (int i = 0,x = 0,y = 0; i < _Options.Length; i++,x++) {
                if (x >= _RowsAmount) {
                    x = 0;
                    y++;
                }
                createBox((x * _Spacing._x) +10, (y* _Spacing._y) + currentMaxHeight, _Options[i], _Size._width, _Size._height);
            }

            createBorder();
            return chooseOption();
        }

        private void createBox(int posx, int posy, string item,int auxX, int auxY) {
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
            _OptionsPositions.Add(new int[]{ posx, posy + auxY / 2 });
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
                    case "D":
                        optionPicked++;
                        break;

                    case "A":
                        optionPicked--;
                        break;
                    case "S":
                        optionPicked+= _RowsAmount;
                        break;
                    case "W":
                        optionPicked-= _RowsAmount;
                        break;
                }

                if (optionPicked < 0) optionPicked = _OptionsPositions.Count - 1;
                if (optionPicked >= _OptionsPositions.Count) optionPicked = 0;
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
