using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyAnalysis
{
    internal class LetterCount
    {
        public string Letter { get; set; }
        public int Count { get; set; }

        public LetterCount() { }

        public LetterCount(string letter, int count)
        {
            Letter = letter;
            Count = count;
        }
    }
}
