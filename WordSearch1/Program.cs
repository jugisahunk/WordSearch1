using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace WordSearch1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter outfile = new StreamWriter(args[1]);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //Run puzzle code
            DoIt(args[0], args[1],args[2]);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("Time elapsed in Milliseconds: {0}", ts.Milliseconds);
            outfile.Write(elapsedTime);
            outfile.Flush();
            Console.WriteLine(String.Format("RunTime: {0}", elapsedTime));

            Console.ReadLine();
        }

        static void DoIt(string inputDataFilePath, string outputFilePath, string intputWordsFilePath){
            //Separate input file into rows
                //read each row into an array
                    //remove the line break characters
            List<string>
                inputData = ExtractData(inputDataFilePath),
                inputWords = ExtractData(intputWordsFilePath);

            FindHorizontal(inputData, inputWords);
            FindVertical(inputData, inputWords);
            FindDiagonal(inputData, inputWords);
        }

        static void FindHorizontal(List<string> inputData, List<string> inputWords)
        {
            foreach (string line in inputData)
            {
                List<string> foundWords = new List<string>();
                foreach (string word in inputWords)
                {
                    if (line.Contains(word))
                    {

                        foundWords.Add(word);
                    }
                    else
                    {
                        char[] reversed = word.ToCharArray();
                        Array.Reverse(reversed);
                        if (line.Contains(new String(reversed)))
                        {

                            foundWords.Add(word);
                        }
                    }
                }
                foundWords.ForEach(x => inputWords.Remove(x));
            }
        }

        static void FindVertical(List<string> inputData, List<string> inputWords)
        {
            int rowLength = inputData.FirstOrDefault().Length;

            for (int i = 0; i < rowLength; i++)
            {
                string verticalRow = new String(inputData.SelectMany(x => x.Substring(i, 1)).ToArray<char>());
                List<string> foundWords = new List<string>();

                foreach (string word in inputWords)
                {
                    if (verticalRow.Contains(word))
                    {

                        foundWords.Add(word);
                    }
                    else
                    {
                        char[] reversed = word.ToCharArray();
                        Array.Reverse(reversed);
                        if(verticalRow.Contains(new String(reversed)))
                        {

                            foundWords.Add(word);
                        }
                    }
                }
                foundWords.ForEach(x => inputWords.Remove(x));
            }
        }

        static void FindDiagonal(List<string> inputData, List<string> inputWords)
        {
            int rowLength = inputData.FirstOrDefault().Length;

            for (int i = 0; i < rowLength; i++)
            {
                int k = i;
                string diagonalRow = new String(inputData.SelectMany(x => x.Substring(k++, 1)).ToArray<char>());
                List<string> foundWords = new List<string>();

                foreach (string word in inputWords)
                {
                    if (diagonalRow.Contains(word))
                    {

                        foundWords.Add(word);
                    }
                    else
                    {
                        char[] reversed = word.ToCharArray();
                        Array.Reverse(reversed);
                        if (diagonalRow.Contains(new String(reversed)))
                        {

                            foundWords.Add(word);
                        }
                    }
                }
                foundWords.ForEach(x => inputWords.Remove(x));
            }
        }

        static List<string> ExtractData(string filePath)
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
    }
}