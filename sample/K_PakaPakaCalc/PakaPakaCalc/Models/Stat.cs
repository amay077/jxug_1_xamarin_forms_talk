using System;

namespace PakaPakaCalc.Models
{
    public class Stat
    {
        public int Number { get; private set; }
        public int CollectAnswer { get; private set; }
        public int Answer { get; private set; }

        public bool IsCollect 
        { 
            get 
            {
                return this.CollectAnswer == this.Answer; 
            } 
        }

        public Stat(int number, int collectAnswer, int answer)
        {
            this.Number = number;
            this.CollectAnswer = collectAnswer;
            this.Answer = answer;
        }
    }
}

