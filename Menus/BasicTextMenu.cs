using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextMenu.Menus
{
     class BasicTextMenu
    {


        private char[] _Corners = { '╔', '╚', '╝', '╗' };
        private char[] _Walls = { '║', '═', '═', '║' };
        private string[] _Options;
        private string _TextHeader;
        private int _BufferX = 5;
        private int _BufferY = 2;
        private int _CurrentCursorPosX = 0;
        private int _CurrentCursorPosY = 0;
        private int _MaxLength = 100;
        private List<int[]> _OptionsPositions = new List<int[]>();
        public BasicTextMenu(string textHeader,string[] options)
        {
            
            _Options = options;
            _TextHeader = textHeader;
        }

        public void show()
        {
        
            updateCursorPostion(0,_BufferY);
            write(_TextHeader + "\n");
            foreach(string option in _Options)
            {
                _OptionsPositions.Add(new int[] { _CurrentCursorPosX, _CurrentCursorPosY });
                if (option.Length / _MaxLength > 0)
                {
                    string saux = "";
                    int devidable = option.Length / (_MaxLength - _BufferX);
                    for (int i = 0;  i <= devidable - 1; i++)
                    {
                        saux = option.Substring((_MaxLength - _BufferX) * i, (_MaxLength - _BufferX));
                        write(saux + "\n");
                    }
                    int charLeft = option.Length % (option.Length / (_MaxLength - _BufferX));
                    saux = option.Substring((_MaxLength - _BufferX) * devidable, charLeft);
                    write(saux + "\n");

                }
                else write(option + "\n");
               
            }
            createBorder();
            chooseOption();
        }
        private void chooseOption() {
            ValueTuple<Int32, Int32> pos = Console.GetCursorPosition();
            int optionPicked = 0;
            updateCursorPostion(_OptionsPositions[optionPicked][0], _OptionsPositions[optionPicked][1]);
            write(">>>",1,0);
            String input = Console.ReadKey(true).Key.ToString();

            while (!(input == "Enter")) {
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
                write("   ", 1, 0);
                updateCursorPostion(_OptionsPositions[optionPicked][0], _OptionsPositions[optionPicked][1]);
                write(">>>", 1, 0);
                input = Console.ReadKey(true).Key.ToString();
            
            }
            updateCursorPostion(pos.Item1,pos.Item2);

        }


        private void write(string text) {
            Console.SetCursorPosition(_BufferX, _CurrentCursorPosY);
            Console.Write(text);
            updateCursorPostion(Console.GetCursorPosition());
        }
        private void write(string text,int bufferX, int bufferY)
        {
            Console.SetCursorPosition(bufferX, _CurrentCursorPosY);
            Console.Write(text);
            updateCursorPostion(Console.GetCursorPosition());
        }

        private void updateCursorPostion(int x, int y) {
            _CurrentCursorPosX = x;
            _CurrentCursorPosY = y;
            Console.SetCursorPosition(_CurrentCursorPosX, _CurrentCursorPosY);
        }
     
        private void updateCursorPostion(ValueTuple<Int32, Int32> pos) {
            _CurrentCursorPosX = pos.Item1;
            _CurrentCursorPosY = pos.Item2;
            Console.SetCursorPosition(_CurrentCursorPosX, _CurrentCursorPosY);
        }

        private void createBorder() {
            int auxY = _CurrentCursorPosY + 1;
            int auxX = _MaxLength + 1;

            for (int i = 0; i < auxY; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(_Walls[0]);
                Console.SetCursorPosition(auxX, i);
                Console.Write(_Walls[3]);
                Console.SetCursorPosition(auxX+1, i+1);
                Console.Write("░");
            }
            for (int i = 0; i < auxX + 1; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(_Walls[1]);
                Console.SetCursorPosition(i, auxY);
                Console.Write(_Walls[2]);
                Console.SetCursorPosition(i + 1, auxY + 1);
                Console.Write("░");
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(_Corners[0]);
            Console.SetCursorPosition(0, auxY);
            Console.Write(_Corners[1]);
            Console.SetCursorPosition(auxX, auxY);
            Console.Write(_Corners[2]);
            Console.SetCursorPosition(auxX, 0);
            Console.Write(_Corners[3]);
            updateCursorPostion(0,_CurrentCursorPosY+2);

        }

        
        
    }
}
