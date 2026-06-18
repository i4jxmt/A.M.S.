using System;

namespace Game15Library
{
    public class BoardChangedEventArgs : EventArgs
    {
        /// <summary>Снимок доски — массив из 16 чисел (0 = пустая клетка).</summary>
        public int[] Board { get; }

        /// <summary>Индекс пустой клетки (0..15).</summary>
        public int EmptyIndex { get; }

        public BoardChangedEventArgs(int[] board, int emptyIndex)
        {
            Board = (int[])board.Clone();
            EmptyIndex = emptyIndex;
        }
    }
}
