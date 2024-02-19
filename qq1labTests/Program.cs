using System.Diagnostics;
using System.IO;

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
                double a1;
                double a2;
                double a3;
                double a = double.TryParse(subs[0], out a1) ? a1 : 0.0;
                double b = double.TryParse(subs[1], out a2) ? a2 : 0.0;
                double c = double.TryParse(subs[2], out a3) ? a3 : 0.0;
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
