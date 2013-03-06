using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace WordSearch1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Run puzzle code
            PuzzleSolver puzzleSolver = new PuzzleSolver();

            puzzleSolver.DoIt(args[0], args[1], args[2]);
        }


    }
}