using System;
using System.IO;

namespace Week1
{
    class MyReader
    {

        private StreamReader reader;
        private string line;
        public string fileName;
        public string directory;

        public MyReader() { }

        public MyReader(string directory, string fileName) 
        {
            this.directory = directory;
            this.fileName = fileName;
        }

        public void ReadFile()
        {

            this.reader = File.OpenText(this.directory + this.fileName);
            this.line = reader.ReadLine();

            while (line != null)
            {

                Console.WriteLine(line);
                this.line = this.reader.ReadLine();

            }

            this.reader.Close();

        }

        public virtual void ProcessLine() 
        {

            int lineNumber = 1;

            this.reader = File.OpenText(this.directory + this.fileName);
            this.line = reader.ReadLine();

            while (line != null)
            {

                this.line = $"{lineNumber}: {this.line}";
                Console.WriteLine(this.line);
                this.line = this.reader.ReadLine();
                lineNumber++;
            
            }

        }

    }
}
