using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleTextMenu.Menus
{
    internal class ScrollingTextMenu : TextMenu
    {


        private string[] _Texts;
        private string _TextHeader;
        private int _CurrentTextOption = 0;
        private List<int[]> _OptionsPositions = new List<int[]>();
        public ScrollingTextMenu(string[] Texts)
        {
            _Texts = Texts;
        }

        public void inicialize()
        {
            show();
            
        }

        private void chooseOption()
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
                
                if (optionPicked < 0) { optionPicked = 0;  };
                if (optionPicked == _OptionsPositions.Count) { optionPicked = 0; }
                write("   ", _OptionsPositions[prev][0]-3, _OptionsPositions[optionPicked][1]);
                updateCursorPostion(_OptionsPositions[optionPicked][0], _OptionsPositions[optionPicked][1]);
                write(">>>", _OptionsPositions[optionPicked][0] - 3, _OptionsPositions[optionPicked][1]);
                input = Console.ReadKey(true).Key.ToString();
                 
            }
            _CurrentTextOption = (optionPicked == 1 ? _CurrentTextOption + 1 : _CurrentTextOption - 1 );
            updateCursorPostion(pos.Item1, pos.Item2);
            Console.Clear();
            _OptionsPositions = new List<int[]>();
            if (_CurrentTextOption > _Texts.Length-1) { return; }
            show();
            
        }

        public void show()
        {

            String text = _Texts[_CurrentTextOption];
            int charLeft = text.Length;
            updateCursorPostion(4, 2);
            if (text.Length / _MaxLength > 0)
                {
                
                    string saux = "";
                    int divisionable = text.Length / (_MaxLength - _BufferX);
                    for (int i = 0; i <= divisionable - 1; i++)
                    {
                        saux = text.Substring((_MaxLength - _BufferX) * i, (_MaxLength - _BufferX));
                        write(saux + "\n",4,_CurrentCursorPosY);
                        charLeft -= (_MaxLength - _BufferX);
                    }
                    saux = text.Substring((_MaxLength - _BufferX) * divisionable, charLeft);
                    write(saux + "\n", 4, _CurrentCursorPosY);

                }
                else write(text + "\n");


            updateCursorPostion(20, _CurrentCursorPosY);
            _OptionsPositions.Add(new int[] { _CurrentCursorPosX , _CurrentCursorPosY});
            write("back");

            updateCursorPostion(30, _CurrentCursorPosY);
            _OptionsPositions.Add(new int[] { _CurrentCursorPosX , _CurrentCursorPosY });
            write("continue");

            //_OptionsPositions

            createBorder();
            chooseOption();
        }

    }
    
}
