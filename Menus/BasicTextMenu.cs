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
     class BasicTextMenu : TextMenu
    {


        
        private string[] _Options;
        private string _TextHeader;

        
        private List<int[]> _OptionsPositions = new List<int[]>();
        public BasicTextMenu(string textHeader,string[] options)
        {
            
            _Options = options;
            _TextHeader = textHeader;
        }

        public int show()
        {
        
            updateCursorPostion(4,_BufferY);
            write(_TextHeader + "\n");
            
            foreach (string option in _Options)
            {
                updateCursorPostion(4, _CurrentCursorPosY);
                _OptionsPositions.Add(new int[] { _CurrentCursorPosX, _CurrentCursorPosY });
                if (option.Length / _MaxLength > 0)
                {
                    string saux = "";
                    int divisionable = option.Length / (_MaxLength - _BufferX);
                    for (int i = 0;  i <= divisionable - 1; i++)
                    {
                        saux = option.Substring((_MaxLength - _BufferX) * i, (_MaxLength - _BufferX));
                        write(saux + "\n");
                    }
                    int charLeft = option.Length % (option.Length / (_MaxLength - _BufferX));
                    saux = option.Substring((_MaxLength - _BufferX) * divisionable, charLeft);
                    write(saux + "\n", 4, _CurrentCursorPosY);

                }
                else write(option + "\n", 4, _CurrentCursorPosY);
               
            }
            createBorder();
            return chooseOption();
        }
        private int chooseOption() {
            ValueTuple<Int32, Int32> pos = Console.GetCursorPosition();
            int optionPicked = 0;
            updateCursorPostion(_OptionsPositions[optionPicked][0], _OptionsPositions[optionPicked][1]);
            write(">>>", _OptionsPositions[optionPicked][0]-3, _OptionsPositions[optionPicked][1]);
            String input = Console.ReadKey(true).Key.ToString();

            while (!(input == "Enter")) {
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
            updateCursorPostion(pos.Item1,pos.Item2);
            Console.Clear();
            return optionPicked;
        }


        

        
        
    }
}
