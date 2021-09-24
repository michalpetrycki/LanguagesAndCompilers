using System;
using System.IO;

namespace Week1
{
    class MyOutputReader: MyReader, IStatsGenerator<MyReader>
    {

        private StreamWriter writer;
        private StreamReader reader;
        private string line;

        public MyOutputReader() { }

        public MyOutputReader(string directory, string fileName)
        {

            this.directory = directory;
            this.fileName = fileName;

        }


        public override void ProcessLine()
        {

            int lineNumber = 1;

            this.reader = File.OpenText(this.directory + this.fileName);
            this.writer = File.CreateText(this.directory + "test-output.txt");
            this.line = reader.ReadLine();

            while (line != null)
            {

                this.line = $"{lineNumber}: {this.line}";
                writer.WriteLine(this.line);
                this.line = this.reader.ReadLine();
                lineNumber++;

            }

            this.writer.Close();

        }

        public int GetLineCount()
        {

            int lineCount = 0;
            this.reader = File.OpenText(this.directory + this.fileName);
            this.line = reader.ReadLine();

            while (line != null)
            {

                lineCount++;
                this.line = this.reader.ReadLine();

            }

            return lineCount;

        }

        public int GetCharacterCount()
        {

            int characterCount = 0;
            this.reader = File.OpenText(this.directory + this.fileName);
            this.line = reader.ReadLine();

            while (line != null)
            {

                characterCount += line.Length;
                this.line = this.reader.ReadLine();

            }

            return characterCount;

        }

        public string GetEndLine()
        {
            string endLine = string.Empty;
            this.reader = File.OpenText(this.directory + this.fileName);
            this.line = reader.ReadLine();

            while (line != null)
            {

                char[] lineChars = line.ToCharArray();
                if (lineChars.Length > 0)
                {

                    char c = lineChars[line.Length - 1];
                    if (c == ' ') c = lineChars[line.Length - 2];
                    endLine += c + ", ";

                } 
                line = this.reader.ReadLine();

            }

            endLine = endLine.Substring(0, endLine.Length - 1);
            return endLine;
        }

        public string GetFirstWord()
        {
            string endLine = string.Empty;
            this.reader = File.OpenText(this.directory + this.fileName);
            this.line = reader.ReadLine();

            while (line != null)
            {

                string[] words = line.Split(" ");
                endLine += words[0] + ", ";
                this.line = reader.ReadLine();

            }

            endLine = endLine.Substring(0, endLine.Length - 1);
            return endLine;
        }

        public int GetWordCount()
        {
            int wordCount = 0;
            this.reader = File.OpenText(this.directory + this.fileName);
            this.line = reader.ReadLine();

            while (line != null)
            {

                wordCount += this.line.Split(" ").Length;
                this.line = this.reader.ReadLine();

            }

            return wordCount;
        }

        public string GetFirstLetter()
        {

            string endLine = string.Empty;
            this.reader = File.OpenText(this.directory + this.fileName);
            this.line = reader.ReadLine();

            while (line != null)
            {

                string[] words = line.Split(" ");

                foreach(string w in words)
                {

                    char[] chars = w.ToCharArray();
                    if (chars.Length > 0) endLine += chars[0] + ", ";
                    this.line = this.reader.ReadLine();

                }

            }

            endLine = endLine.Substring(0, endLine.Length - 1);
            return endLine;

        }

        public void SimpleChecking()
        {

            Boolean success = true;
            this.reader = File.OpenText(this.directory + this.fileName);
            this.line = reader.ReadLine();
            int lineNumber = 0;

            while (line != null && success)
            {

                lineNumber++;
                char[] chars = this.line.ToCharArray();
                if (chars.Length > 0)
                {

                    if (chars[0] != '#')
                    {

                        char c = chars[chars.Length - 1];
                        if (c != ';' && c != '+')
                        {

                            success = false;
                            line = null;

                        }
                        
                    }

                }

                this.line = this.reader.ReadLine();

            }

            if (success)
            {


                this.reader = File.OpenText(this.directory + this.fileName);
                this.writer = File.CreateText(this.directory + "simple-check.txt");
                this.line = reader.ReadLine();

                while (line != null)
                {

                    this.writer.WriteLine(this.line);
                    this.line = this.reader.ReadLine();

                }

                this.reader.Close();
                this.writer.Close();

            }

            else
            {
                Console.WriteLine("===ERROR===");
                Console.WriteLine($"Error occured in line: {lineNumber}");
            }
            

        }

    }
}
