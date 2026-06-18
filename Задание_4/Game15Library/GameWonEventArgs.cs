using System;

namespace Game15Library
{
    public class GameWonEventArgs : EventArgs
    {
        /// <summary>Время, за которое была решена головоломка.</summary>
        public TimeSpan Elapsed { get; }

        public GameWonEventArgs(TimeSpan elapsed)
        {
            Elapsed = elapsed;
        }
    }
}
