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
        internal void DoIt(string inputDataFilePath, string outputFilePath, string intputWordsFilePath)
        {
            using (StreamWriter outfile = new StreamWriter(outputFilePath))
            {
                List<string>
                    inputData = ExtractData(inputDataFilePath),
                    inputWords = ExtractData(intputWordsFilePath);

                inputWords.Sort();

                FindHorizontal(inputData, inputWords);
                FindVertical(inputData, inputWords);
                FindDiagonal(inputData, inputWords);

                outfile.Write("Time elapsed in Milliseconds: {0}");
            }
        }

        internal void FindHorizontal(List<string> inputData, List<string> inputWords)
        {
            foreach (string line in inputData)
            {
                List<string> foundWords = new List<string>();

                inputWords.ForEach(x => foundWords.AddRange(CheckBiDirectional(line, x)));

                foundWords.ForEach(x => inputWords.Remove(x));
            }
        }

        internal void FindVertical(List<string> inputData, List<string> inputWords)
        {
            int rowLength = inputData.FirstOrDefault().Length;

            for (int i = 0; i < rowLength; i++)
            {
                List<string> foundWords = new List<string>();

                inputWords.ForEach(x => foundWords.AddRange(
                           CheckBiDirectional(
                               new String(inputData.SelectMany(y => y.Substring(i, 1)).ToArray<char>()),
                               x)));

                foundWords.ForEach(x => inputWords.Remove(x));
            }
        }

        internal void FindDiagonal(List<string> inputData, List<string> inputWords)
        {
            int rowLength = inputData.FirstOrDefault().Length;

            for (int i = 0; i < rowLength; i++)
            {
                int k = i;
                string diagonalRow = new String(inputData.Where(x => k < rowLength).SelectMany(x => x.Substring(k++, 1)).ToArray<char>());

                List<string> foundWords = new List<string>();

                inputWords.ForEach(x => foundWords.AddRange(CheckBiDirectional(diagonalRow, x)));

                foundWords.ForEach(x => inputWords.Remove(x));
            }

            for (int i = rowLength; i > 0; i--)
            {
                int k = i - 1;
                string diagonalRow = new String(inputData.Where(x => k > 0).SelectMany(x => x.Substring(k--, 1)).ToArray<char>());

                List<string> foundWords = new List<string>();

                inputWords.ForEach(x => foundWords.AddRange(CheckBiDirectional(diagonalRow, x)));

                foundWords.ForEach(x => inputWords.Remove(x));
            }

            inputData = inputData.Reverse<string>().ToList<string>();

            for (int i = 0; i < rowLength; i++)
            {
                int k = i;
                string diagonalRow = new String(inputData.Where(x => k < rowLength).SelectMany(x => x.Substring(k++, 1)).ToArray<char>());

                List<string> foundWords = new List<string>();

                inputWords.ForEach(x => foundWords.AddRange(CheckBiDirectional(diagonalRow, x)));

                foundWords.ForEach(x => inputWords.Remove(x));
            }

            //start at row length -1 because we will have already checked the main diagonal
            for (int i = rowLength - 1; i > 1; i--)
            {
                int k = i - 1;
                string diagonalRow = new String(inputData.Where(x => k > 0).SelectMany(x => x.Substring(k--, 1)).ToArray<char>());

                List<string> foundWords = new List<string>();

                inputWords.ForEach(x => foundWords.AddRange(CheckBiDirectional(diagonalRow, x)));

                foundWords.ForEach(x => inputWords.Remove(x));
            }
        }

        #region Helper Functions

        internal  List<string> CheckBiDirectional(string row, string word)
        {
            List<string> foundWords = new List<string>();

            if (row.Contains(word))
                foundWords.Add(word);
            else
            {
                char[] reversed = word.ToCharArray();
                Array.Reverse(reversed);
                if (row.Contains(new String(reversed)))
                    foundWords.Add(word);
            }

            return foundWords;
        }


        internal List<string> ExtractData(string filePath)
        {
            List<string> listOfStrings = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                do
                {
                    listOfStrings.Add(reader.ReadLine());
                }
                while (!reader.EndOfStream);
            }

            return listOfStrings;
        }

        #endregion
    }
}
