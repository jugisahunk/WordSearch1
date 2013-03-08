using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch1
{
    internal class PuzzleSolver
    {
        private readonly string _inputRowsPath, _outputFilePath, _inputWordsFilePath;
        int _rowLength;
        List<FoundWord> _foundWords;

        List<string> _inputRows, _inputWords;

        internal PuzzleSolver(string inputRowsFilePath, string outputFilePath, string inputWordsFilePath)
        {
            _foundWords = new List<FoundWord>();

            _inputRowsPath = inputRowsFilePath;
            _outputFilePath = outputFilePath;
            _inputWordsFilePath = inputWordsFilePath;

            _inputRows = ExtractData(_inputRowsPath);
            _inputWords = ExtractData(_inputWordsFilePath);

            _rowLength = _inputRows.FirstOrDefault().Length;
        }

        internal PuzzleSolver(List<string> inputRows, List<string> inputWords)
        {
            _inputRows = inputRows;
            _inputWords = inputWords;

            _rowLength = _inputRows.FirstOrDefault().Length;
        }

        internal void DoIt()
        {
            if (!_inputRows.Any() || !_inputWords.Any()) return;                

            _inputWords.Sort();

            FindHorizontal();
            FindVertical();
            FindDiagonal();
        }


        internal void FindHorizontal()
        {
            List<string> foundWords = new List<string>();

            for (int i = 0; i < _inputRows.Count(); i++)
            {
                for (int j = 0; j < _inputWords.Count(); j++)
                {
                    string row = _inputRows[i], word = _inputWords[j];
                    if (IsWordInRow(row, word))
                    {                        
                        foundWords.Add(word);
                    }
                }
            }

            RemoveFoundWords(foundWords);
        }

        internal void FindVertical()
        {
            List<string> foundWords = new List<string>();

            for (int i = 0; i < _rowLength; i++)
            {
                string verticalRow = new String(_inputRows.SelectMany(x => x.Substring(i, 1)).ToArray<char>());
                foundWords.AddRange(_inputWords.Where(word => IsWordInRow(verticalRow,word)));

                RemoveFoundWords(foundWords);
            }
        }

        internal void FindInLeftRightDiagonal(int startingIndex, int endingIndex){
            List<string> foundWords = new List<string>();
            for (int i = startingIndex; i < endingIndex; i++)
            {
                int k = i;
                string diagonalRow = new String(_inputRows.Where(x => k < endingIndex).SelectMany(x => x.Substring(k++, 1)).ToArray<char>());

                foundWords.AddRange(_inputWords.Where(x => IsWordInRow(diagonalRow, x)));

                RemoveFoundWords(foundWords);
            }
        }

        internal void FindInRightLeftDiagonal(int startingIndex, int endingIndex)
        {
            List<string> foundWords = new List<string>();

            for (int i = startingIndex; i >= endingIndex; i--)
            {
                int k = i;
                string diagonalRow = new String(_inputRows.Where(x => k > endingIndex).SelectMany(x => x.Substring(k--, 1)).ToArray<char>());

                foundWords.AddRange(_inputWords.Where(x => IsWordInRow(diagonalRow, x)));

                RemoveFoundWords(foundWords);
            }
        }

        internal void FindDiagonal()
        {
            List<string> foundWords = new List<string>();

            //Search Left to Right Diagonal
            FindInLeftRightDiagonal(0, _rowLength);

            //Search Rigth to Left Diagonal
            FindInRightLeftDiagonal(_rowLength - 1, 0);

            _inputRows = _inputRows.Reverse<string>().ToList<string>();

            FindInLeftRightDiagonal(0, _rowLength - 1);

            FindInRightLeftDiagonal(_rowLength - 1, 1);
        }

        #region Helper Functions

        internal bool IsWordInRow(string row, string word)
        {
            if (row.Contains(word))
                return true;
            else
            {
                char[] reversed = word.ToCharArray();
                Array.Reverse(reversed);
                if (row.Contains(new String(reversed)))
                    return true;
            }

            return false;
        }

        private void RemoveFoundWords(List<string> foundWords)
        {
            foundWords.ForEach(x => _inputWords.Remove(x));
        }

        internal List<string> ExtractData(string filePath)
        {
            List<string> listOfStrings = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                do
                {
                    listOfStrings.Add(reader.ReadLine().ToLower());
                }
                while (!reader.EndOfStream);
            }

            return listOfStrings;
        }

        #endregion
    }
}
