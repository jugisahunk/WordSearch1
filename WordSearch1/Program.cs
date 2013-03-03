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
            DoIt(new StreamReader(args[0]));

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("Time elapsed in Milliseconds: {0}", ts.Milliseconds);
            outfile.Write(elapsedTime);
            outfile.Flush();
            Console.WriteLine(String.Format("RunTime: {0}", elapsedTime));

            Console.ReadLine();
        }

        static void DoIt(StreamReader reader){
            //Separate input file into rows
                //read each row into an array
                    //remove the line break characters
            string[][] results;

            PrepareInputData(reader, out results);
        }

        static void PrepareInputData(StreamReader reader, out string[][] results)
        {
            List<string> listOfStrings = new List<string>();

            do
            {         
                listOfStrings.Add(reader.ReadLine());            
            }
            while (!reader.EndOfStream);

            results = null;
        }
    }
}