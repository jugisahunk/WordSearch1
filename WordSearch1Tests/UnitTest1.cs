using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace WordSearch1Tests
{
    [TestClass]
    public class UnitTest1
    {
        #region Fields

        private WordSearch1.PuzzleSolver _puzzleSolver;
        string _word = "SACRAMENTO", _row = "SACRAMENTOTWICV";
        List<string> _foundWords;

        List<string> _inputData;
        List<string> _inputWords;

        #endregion

        #region Setup

        [TestInitialize]
        public void Initialize()
        {
            _word = "SACRAMENTO";
            _row = "SACRAMENTOTWICV";

            _puzzleSolver = PuzzleSolverObjectMother.GetTestPuzzleSolver();

            _inputWords = new List<string>()
            {
                "cake",
                "Forrest Cake",
                "america",
                "freedom",
                "perspicacity",
                "circumlocution",
                "bad wolf"
            };

            _inputData = new List<string>()
            {
                "__________________________________________________________________________",
                "__________________________________________________________________________",
                "__________________________________________________________________________",
                "________________________________e_________________________________________",
                "_______________________________k__________________________________________",
                "______________________________a___________________________________________",
                "_____________________________c____________________________________________",
                "____________________________ta_________________________modeerf____________",
                "___________________________s_k____________________________________________",
                "__________________________e__e____________________________y_______________",
                "_________________________r_________________________________t______________",
                "________________________r___________________________________i_____________",
                "_______________________r_______circumlocution________________c____________",
                "______________________o_______________________________________a___________",
                "_____________________F_________________________________________c__________",
                "________________________________________________________________i_________",
                "__________________________________a_______________f______________p________",
                "___________________________________m______________l_______________s_______",
                "____________________________________e_____________o________________r______",
                "_____________________________________r____________w_________________e_____",
                "______________________________________i___________d__________________p____",
                "_______________________________________c__________a_______________________",
                "________________________________________a_________b_______________________",
            };

            _foundWords = new List<string>();
        }

        #endregion

        #region Tests

        #region CheckBiDirectional

        [TestMethod]
        public void CheckBiDirectional_LeftToRightWordExists()
        {
            _foundWords.AddRange(_puzzleSolver.CheckBiDirectional(_row, _word));

            Assert.IsTrue(_foundWords.Count == 1);
            Assert.IsTrue(_foundWords.First<string>() == _word);
        }

        [TestMethod]
        public void CheckBiDirectional_RightToLeftWordExists()
        {
            _word = new String(_word.Reverse().ToArray<char>());

            _foundWords.AddRange(_puzzleSolver.CheckBiDirectional(_row, _word));

            Assert.IsTrue(_foundWords.Count == 1);
            Assert.IsTrue(_foundWords.First<string>() == _word);
        }

        [TestMethod]
        public void CheckBiDirectional_LeftToRightWordNotExists()
        {
            _word = "jack";
            _row = "squat";

            _foundWords.AddRange(_puzzleSolver.CheckBiDirectional(_row, _word));

            Assert.IsTrue(!_foundWords.Any());
        }

        [TestMethod]
        public void CheckBiDirectional_RightToLeftWordNotExists()
        {
            _word = "jack";
            _row = "squat";

            _word = new String(_word.Reverse().ToArray<char>());

            _foundWords.AddRange(_puzzleSolver.CheckBiDirectional(_row, _word));

            Assert.IsTrue(!_foundWords.Any());
        }

        #endregion

        #region FindHorizontal

        [TestMethod]
        public void FindHorizontal_WordInRow()
        {

        }

        #endregion

        #endregion
    }
}
