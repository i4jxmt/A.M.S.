using System;
using System.Collections.Generic;

namespace Game15Library
{
    /// <summary>
    /// Модель игры «15». Не зависит от интерфейса.
    /// Хранит состояние доски, обрабатывает ходы, генерирует перемешанное поле.
    /// </summary>
    public class GameModel
    {
        // Решённое состояние: 1..15 по порядку, 0 — пустая клетка в конце
        private static readonly int[] SolvedState =
            { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };

        private int[] _board = new int[16];
        private int _emptyIndex;
        private DateTime _startTime;

        // ──────────────────── Публичное состояние ────────────────────

        /// <summary>True — игра идёт, ходы принимаются.</summary>
        public bool GameInProgress { get; private set; }

        /// <summary>Время, затраченное на решение (заполняется при победе).</summary>
        public TimeSpan FinalElapsed { get; private set; }

        /// <summary>Индекс пустой клетки.</summary>
        public int EmptyIndex => _emptyIndex;

        // ──────────────────── События ────────────────────

        /// <summary>Срабатывает при каждом изменении доски.</summary>
        public event EventHandler<BoardChangedEventArgs>? BoardChanged;

        /// <summary>Срабатывает, когда головоломка решена.</summary>
        public event EventHandler<GameWonEventArgs>? GameWon;

        // ──────────────────── Конструктор ────────────────────

        public GameModel()
        {
            ResetToSolved();
        }

        // ──────────────────── Публичные методы ────────────────────

        /// <summary>Возвращает копию текущей доски (0 = пустая клетка).</summary>
        public int[] GetBoard() => (int[])_board.Clone();

        /// <summary>Начать новую игру: перемешать поле и запустить таймер.</summary>
        public void NewGame()
        {
            ResetToSolved();
            Shuffle();
            _startTime = DateTime.Now;
            GameInProgress = true;
            RaiseBoardChanged();
        }

        /// <summary>
        /// Проверяет, можно ли переместить фишку с данным индексом.
        /// Фишка перемещаема, если она соседняя с пустой клеткой.
        /// </summary>
        public bool CanMove(int index)
        {
            if (index < 0 || index > 15 || _board[index] == 0) return false;
            int er = _emptyIndex / 4, ec = _emptyIndex % 4;
            int tr = index / 4, tc = index % 4;
            return Math.Abs(er - tr) + Math.Abs(ec - tc) == 1;
        }

        /// <summary>
        /// Перемещает фишку на указанном индексе в пустую клетку.
        /// Возвращает true, если ход был выполнен.
        /// </summary>
        public bool TryMove(int index)
        {
            if (!GameInProgress || !CanMove(index)) return false;

            _board[_emptyIndex] = _board[index];
            _board[index] = 0;
            _emptyIndex = index;

            RaiseBoardChanged();

            if (IsWon())
            {
                FinalElapsed = DateTime.Now - _startTime;
                GameInProgress = false;
                OnGameWon(new GameWonEventArgs(FinalElapsed));
            }

            return true;
        }

        /// <summary>Проверяет, решена ли головоломка.</summary>
        public bool IsWon()
        {
            for (int i = 0; i < 15; i++)
                if (_board[i] != i + 1) return false;
            return _board[15] == 0;
        }

        /// <summary>Текущее прошедшее время (только пока идёт игра).</summary>
        public TimeSpan GetElapsedTime()
            => GameInProgress ? DateTime.Now - _startTime : TimeSpan.Zero;

        // ──────────────────── Приватные методы ────────────────────

        private void ResetToSolved()
        {
            Array.Copy(SolvedState, _board, 16);
            _emptyIndex = 15;
            GameInProgress = false;
        }

        /// <summary>
        /// Перемешивание случайными допустимыми ходами из решённого состояния.
        /// Гарантирует разрешимость — решённое поле всегда разрешимо,
        /// а любой ход не меняет чётность числа инверсий соответствующим образом.
        /// </summary>
        private void Shuffle()
        {
            var rng = new Random();
            int prevEmpty = -1;

            for (int i = 0; i < 300; i++)
            {
                var neighbors = GetNeighbors(_emptyIndex);
                // Не возвращаться на предыдущую позицию (избегаем немедленного отката)
                var candidates = neighbors.Count > 1
                    ? neighbors.FindAll(n => n != prevEmpty)
                    : neighbors;

                int chosen = candidates[rng.Next(candidates.Count)];
                prevEmpty = _emptyIndex;
                _board[_emptyIndex] = _board[chosen];
                _board[chosen] = 0;
                _emptyIndex = chosen;
            }
        }

        private List<int> GetNeighbors(int idx)
        {
            var list = new List<int>(4);
            int r = idx / 4, c = idx % 4;
            if (r > 0) list.Add(idx - 4);
            if (r < 3) list.Add(idx + 4);
            if (c > 0) list.Add(idx - 1);
            if (c < 3) list.Add(idx + 1);
            return list;
        }

        // ──────────────────── Вызов событий (конвенция Microsoft) ────────────────────

        /// <summary>Вызывает событие BoardChanged.</summary>
        protected virtual void OnBoardChanged(BoardChangedEventArgs e)
        {
            BoardChanged?.Invoke(this, e);
        }

        /// <summary>Вызывает событие GameWon.</summary>
        protected virtual void OnGameWon(GameWonEventArgs e)
        {
            GameWon?.Invoke(this, e);
        }

        private void RaiseBoardChanged()
            => OnBoardChanged(new BoardChangedEventArgs(_board, _emptyIndex));
    }
}
