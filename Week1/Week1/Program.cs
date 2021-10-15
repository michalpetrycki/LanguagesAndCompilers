using System;

namespace Week1
{
    class Program
    {
        public static string directory = "C:\\Users\\Michal\\source\\repos\\LanguagesAndCompilers\\Week1\\";
        public static string fileName = "test-2.txt";
        static void Main(string[] args)
        {

            MyReader myReader = new MyReader(directory, fileName);
            MyOutputReader myOutputReader = new MyOutputReader(directory, fileName);

            myReader.ReadFile();

            Console.WriteLine("================== Here goes whole file======================");
            myReader.ReadFile();

            Console.WriteLine("\n\n");

            Console.WriteLine("================== Here goes line by line ===================");
            myReader.ProcessLine();

            Console.WriteLine("\n\n");

            Console.WriteLine("================== New file has been create ===================");
            myOutputReader.ProcessLine();

            Console.WriteLine("\n\n");

            Console.WriteLine("================== Get Line Count ===================");
            Console.Write(myOutputReader.GetLineCount());
            Console.WriteLine("\n\n");

            Console.WriteLine("================== Get Character Count ===================");
            Console.Write(myOutputReader.GetCharacterCount());
            Console.WriteLine("\n\n");

            Console.WriteLine("================== Get End Line ===================");
            Console.Write(myOutputReader.GetEndLine());
            Console.WriteLine("\n\n");

            Console.WriteLine("================== Get First Word ===================");
            Console.Write(myOutputReader.GetFirstWord());
            Console.WriteLine("\n\n");

            Console.WriteLine("================== Get Word Count ===================");
            Console.Write(myOutputReader.GetWordCount());
            Console.WriteLine("\n\n");

            Console.WriteLine("================== Get First Letter ===================");
            Console.Write(myOutputReader.GetFirstLetter());
            Console.WriteLine("\n\n");

            Console.WriteLine("================== Simple Check Test ===================");
            myOutputReader.SimpleChecking();
            Console.WriteLine("\n\n");


        }
    }
}
