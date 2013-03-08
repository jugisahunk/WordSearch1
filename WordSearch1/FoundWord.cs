using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch1
{
    internal class FoundWord
    {
        FoundWord(string word, Point a, Point b)
        {
            Word = word;
            A = a;
            B = b;
        }

        string Word { get; set; }
        Point A { get; set; }
        Point B { get; set; }
    }
}
