using Week3.IO;
using Week3.Tokenization;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;

namespace Week3
{
    /// <summary>
    /// Compiler for code in a source file
    /// </summary>
    public class Compiler
    {
        /// <summary>
        /// The error reporter
        /// </summary>
        public ErrorReporter Reporter { get; }

        /// <summary>
        /// The file reader
        /// </summary>
        public IFileReader Reader { get; }

        /// <summary>
        /// The tokenizer
        /// </summary>
        public Tokenizer Tokenizer { get; }

        /// <summary>
        /// Creates a new compiler
        /// </summary>
        /// <param name="inputFile">The file containing the source code</param>
        public Compiler(string inputFile)
        {
            Reporter = new ErrorReporter();
            Reader = new FileReader(inputFile);
            Tokenizer = new Tokenizer(Reader, Reporter);
        }

        /// <summary>
        /// Performs the compilation process
        /// </summary>
        public void Compile()
        {
            // Tokenize
            Write("Tokenising...");
            List<Token> tokens = Tokenizer.GetAllTokens();
            if (Reporter.HasErrors) return;
            WriteLine("Done");

            WriteLine(string.Join("\n", tokens));
        }

        /// <summary>
        /// Writes a message reporting on the success of compilation
        /// </summary>
        private void WriteFinalMessage()
        {
            // Write output to tell the user whether it worked or not here
            if (Reporter.ErrorsNumber > 0)
            {

                Console.WriteLine("=================FINAL MESSAGE================");

                foreach (ErrorOccured err in Reporter.Errors)
                {

                    Console.WriteLine($"Error in line: {err.Position.LineNumber} at position: {err.Position.ColumnPosition}: {err.ErrorMessage}");

                }

            }
            else
            {
                Console.WriteLine("=================FINAL MESSAGE================");
                Console.WriteLine($"No errors occured");
            }
        }

        /// <summary>
        /// Compiles the code in a file
        /// </summary>
        /// <param name="args">Should be one argument, the input file (*.tri)</param>
        public static void Main(string[] args)
        {
            if (args == null || args.Length != 1 || args[0] == null)
                WriteLine("ERROR: Must call the program with exactly one argument, the input file (*.tri)");
            else if (!File.Exists(args[0]))
                WriteLine($"ERROR: The input file \"{Path.GetFullPath(args[0])}\" does not exist");
            else
            {
                string inputFile = args[0];
                Compiler compiler = new Compiler(inputFile);
                WriteLine("Compiling...");
                compiler.Compile();
                compiler.WriteFinalMessage();
            }
        }
    }
}
