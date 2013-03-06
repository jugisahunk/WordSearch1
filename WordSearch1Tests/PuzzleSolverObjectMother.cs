using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch1Tests
{
    class PuzzleSolverObjectMother
    {
        public static WordSearch1.PuzzleSolver GetTestPuzzleSolver(){
            return new WordSearch1.PuzzleSolver(); 
        }
    }
}
