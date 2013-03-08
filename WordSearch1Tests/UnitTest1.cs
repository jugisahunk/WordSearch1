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

        private const string  
            CAKE = "cake",
            FORREST_CAKE = "Forrest Cake",
            AMERICA = "america",
            FREEDOM = "freedom",
            PERSPICACITY = "perspicacity",
            CIRCUMLOCUTION = "circumlocution",
            BAD_WOLF = "bad wolf";

        string _word, _row;
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
            
            _inputWords = new List<string>()
            {
                "cake",
                "ForrestCake",
                "america",
                "freedom",
                "perspicacity",
                "circumlocution",
                "badwolf"
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
                "____________________________ta_____________________________________modeerf",
                "___________________________s_k____________________________________________",
                "__________________________e__e____________________________y_______________",
                "_________________________r_________________________________t______________",
                "________________________r___________________________________i_____________",
                "circumlocution_________r_____________________________________c____________",
                "______________________o_______________________________________a___________",
                "_____________________f_________________________________________c__________",
                "________________________________________________________________i_________",
                "__________________________________a_______________f______________p________",
                "___________________________________m______________l_______________s_______",
                "____________________________________e_____________o________________r______",
                "_____________________________________r____________w_________________e_____",
                "______________________________________i___________d__________________p____",
                "_______________________________________c__________a_______________________",
                "________________________________________a_________b_______________________",
            };

            _puzzleSolver = new WordSearch1.PuzzleSolver(_inputData, _inputWords);
        }

        #endregion

        #region Tests

        #region IsWordInRow

        [TestMethod]
        public void IsWordInRow_LeftToRightWordExists()
        {
            Assert.IsTrue(_puzzleSolver.IsWordInRow(_row, _word));
        }

        [TestMethod]
        public void IsWordInRow_RightToLeftWordExists()
        {
            _word = new String(_word.Reverse().ToArray<char>());

            Assert.IsTrue(_puzzleSolver.IsWordInRow(_row, _word));
        }

        [TestMethod]
        public void IsWordInRow_LeftToRightWordNotExists()
        {
            _word = "jack";
            _row = "squat";

            Assert.IsFalse(_puzzleSolver.IsWordInRow(_row, _word));
        }

        [TestMethod]
        public void IsWordInRow_RightToLeftWordNotExists()
        {
            _word = "jack";
            _row = "squat";

            _word = new String(_word.Reverse().ToArray<char>());

            Assert.IsFalse(_puzzleSolver.IsWordInRow(_row, _word));
        }

        #endregion

        #region FindHorizontal

        [TestMethod]
        public void FindHorizontal_WordInRow()
        {
            _puzzleSolver.FindHorizontal();

            Assert.IsTrue(!_inputWords.Contains(FREEDOM));
            Assert.IsTrue(!_inputWords.Contains(CIRCUMLOCUTION));
        }

        [TestMethod]
        public void FindVertical_WordInRow()
        {
            _puzzleSolver.FindVertical();

            Assert.IsTrue(!_inputWords.Contains(CAKE));
            Assert.IsTrue(!_inputWords.Contains(BAD_WOLF));
        }

        [TestMethod]
        public void FindDiagonal_WordInRow()
        {
            _puzzleSolver.FindDiagonal();

            Assert.IsTrue(!_inputWords.Contains(FORREST_CAKE));
            Assert.IsTrue(!_inputWords.Contains(AMERICA));
            Assert.IsTrue(!_inputWords.Contains(PERSPICACITY));
        }

        #endregion

        #endregion
    }
}
