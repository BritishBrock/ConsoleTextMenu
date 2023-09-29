using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextMenu.Menus
{
    internal class TextMenu
    {
        internal char[] _Corners = { '╔', '╚', '╝', '╗' };
        internal char[] _Walls = { '║', '═', '═', '║' };
        internal int _CurrentCursorPosX = 0;
        internal int _CurrentCursorPosY = 0;
        internal int _MaxLength = 100;
        internal int _BufferX = 5;
        internal int _BufferY = 2;
        internal int _Maxheight = 0;

        internal void write(string text)
        {
            Console.SetCursorPosition(_CurrentCursorPosX, _CurrentCursorPosY);
            Console.Write(text);
            updateCursorPostion(Console.GetCursorPosition());
        }
        internal void write(string text, int bufferX, int bufferY)
        {
            Console.SetCursorPosition(bufferX, bufferY);
            Console.Write(text);
            updateCursorPostion(Console.GetCursorPosition());
        }

        internal void updateCursorPostion(int x, int y)
        {
            _CurrentCursorPosX = x;
            _CurrentCursorPosY = y;
            _Maxheight = (_CurrentCursorPosY > _Maxheight ? _CurrentCursorPosY : _Maxheight);
            Console.SetCursorPosition(_CurrentCursorPosX, _CurrentCursorPosY);
        }

        internal void updateCursorPostion(ValueTuple<Int32, Int32> pos)
        {
            _CurrentCursorPosX = pos.Item1;
            _CurrentCursorPosY = pos.Item2;
            _Maxheight = (_CurrentCursorPosY > _Maxheight ? _CurrentCursorPosY : _Maxheight);
            Console.SetCursorPosition(_CurrentCursorPosX, _CurrentCursorPosY);
        }

        internal void createBorder()
        {
            int auxY = _Maxheight + 1;
            int auxX = _MaxLength + 1;

            for (int i = 0; i < auxY; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(_Walls[0]);
                Console.SetCursorPosition(auxX, i);
                Console.Write(_Walls[3]);
                Console.SetCursorPosition(auxX + 1, i + 1);
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
            updateCursorPostion(0, auxY + 2);

        }
    }
}
