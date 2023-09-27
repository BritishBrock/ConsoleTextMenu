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

        private char _Corners = '+';
        private char[] _Walls = {'|','-','-','|' };
        private string[] _Options;
        private string _TextHeader;
        private int _BufferX = 5;
        private int _BufferY = 2;
        private int _CurrentCursorPosX = 0;
        private int _CurrentCursorPosY = 0;
        private int _MaxLength = 50;
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
                
                if (option.Length / _MaxLength > 0)
                {
                    int sum = 0;
                    for (int i = 0;  i <= option.Length / (_MaxLength - _BufferX); i++)
                    {
                        string saux = "";
                        sum += (_MaxLength - _BufferX) % option.Length;
                        if(sum% option.Length> (_MaxLength - _BufferX)) saux = option.Substring(((_MaxLength - _BufferX) * i), (_MaxLength - _BufferX));
                        else saux = option.Substring(((_MaxLength - _BufferX) * i), sum % option.Length);
                        write(saux + "\n");
                    }
                    
                }
                else write(option + "\n");


            }


            createBorder();


        }
        private int optionPicked()
        {
            return 1;
        }

        private void write(string text) {
            Console.SetCursorPosition(_BufferX, _CurrentCursorPosY);
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
                Console.Write('|');
                Console.SetCursorPosition(auxX, i);
                Console.Write('|');
            }
            for (int i = 0; i < auxX + 1; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write('-');
                Console.SetCursorPosition(i, auxY);
                Console.Write('-');
            }
        }

        
        
    }
}
