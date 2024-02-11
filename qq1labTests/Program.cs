using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qq1labTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFile = args[0];
            string outputFile = args[1];
            StreamReader reader = new StreamReader(inputFile);
            StreamWriter writer = new StreamWriter(outputFile);
            while (!reader.EndOfStream)
            {
                string input = reader.ReadLine();
                string[] subs = input.Split(' ');
                int a = int.Parse(subs[0]);
                int b = int.Parse(subs[1]);
                int c = int.Parse(subs[2]);
                string type = subs[3];

                Process process = new Process();
                process.StartInfo.FileName = "qq1lab.exe";
                process.StartInfo.Arguments = $"{a} {b} {c}";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                string result = process.StandardOutput.ReadToEnd();

                process.WaitForExit();

                process.Dispose();

                if (result.ToLower().TrimEnd() == type)
                {
                    writer.WriteLine("> success");
                }
                else
                {
                    writer.WriteLine("> error");
                }
            }
            reader.Close();
            writer.Close();
        }
    }
}
