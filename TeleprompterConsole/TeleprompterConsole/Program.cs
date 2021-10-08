using System;
using System.Collections.Generic;

namespace TeleprompterConsole
{

    class Program
    {

        public static List<Option> options;

        static void Main(string[] args)
        {

            // Task 5 - A menu to choose the speech to show
            string fileName = string.Empty;
            options = new List<Option>
            {

                new Option("BarackObama"),
                new Option("BorisJohnson"),
                new Option("DonaldTrump"),
                new Option("EdDavey"),
                new Option("GordonBrown"),
                new Option("JeremyCorbyn"),
                new Option("JoeBiden"),
                new Option("JoSwinsonJoSwinson"),
                new Option("KeirStarmer"),
                new Option("NicolaSturgeon")

            };

            // Set default selected index.
            int index = 0;

            WriteMenu(options, options[index]);

            // Store key info in here
            ConsoleKeyInfo keyinfo;

            do
            {
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    fileName = options[index].Name;
                    index = 0;
                }

            } while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();


            Console.WriteLine($"Your choice is: {fileName}");

            // To run it select an option, hit Enter, click X, hit enter
            Teleprompter.RunTeleprompter(fileName).Wait();

        }

        static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();

            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }
    }

    public class Option
    {
        public string Name { get; }

        public Option(string name)
        {

            Name = name;

        }
    }

}
