using System;
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
                string argumentString;
                string checkingString;
                FindPosition(input, out argumentString,out checkingString);

                Process process = new Process();
                process.StartInfo.FileName = "qq1lab.exe";
                process.StartInfo.Arguments = $"{argumentString}";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                string result = process.StandardOutput.ReadToEnd();

                process.WaitForExit();

                process.Dispose();

                if (result.ToLower().TrimEnd() == checkingString)
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

        private static void FindPosition(string input, out string argumentString, out string checkingString)
        {
            argumentString = "";
            checkingString = "";
            if (input.Contains("обычный") || input.Contains("равнобедренный") || input.Contains("равносторонний") || input.Contains("неизвестнаяошибка")|| input.Contains("нетреугольник"))
            {
                foreach (var phrase in new[] { "обычный", "равнобедренный", "равносторонний", "неизвестнаяошибка", "нетреугольник" })
                {
                    if (input.Contains(phrase))
                    {
                        int index = input.IndexOf(phrase);
                        if (index > 0)
                        {
                            argumentString = input.Substring(0, index).Trim();
                            checkingString = phrase;
                            return;
                        }
                    }
                }
            }
        }
    }
}
