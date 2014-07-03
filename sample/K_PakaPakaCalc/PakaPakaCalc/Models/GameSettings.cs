using System;

namespace PakaPakaCalc.Models
{
    public class GameSettings
    {
        public int Digits
        {
            get;
            private set;
        }

        public int Times
        {
            get;
            private set;
        }

        public int Nums
        {
            get;
            private set;
        }

        public double Intervals
        {
            get;
            private set;
        }

        public GameSettings(int digits, int times, double intervals, int nums)
        {
            this.Digits = digits;
            this.Times = times;
            this.Intervals = intervals;
            this.Nums = nums;
        }
    }
}

