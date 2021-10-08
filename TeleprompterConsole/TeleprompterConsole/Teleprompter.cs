using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TeleprompterConsole
{
    class Teleprompter
    {

        private static IEnumerable<string> ReadFrom(string file)
        {

            using (StreamReader reader = File.OpenText(file))
            {

                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {

                    string[] words = line.Split(' ');
                    int lineLength = 0;
                    foreach (string word in words)
                    {
                        yield return word + " ";

                        lineLength += word.Length + 1;
                        if (lineLength > 70)
                        {
                            yield return Environment.NewLine;
                            lineLength = 0;
                        }

                        // Task 2 - Extra-long pauses at the end of sentences 
                        if (word.IndexOf('.') > -1)
                        {
                            Task.Delay(1000).Wait();
                        }

                    }

                    yield return Environment.NewLine;

                }

            }


        }

        private static async Task ShowTeleprompter(TeleprompterConfig config, string fileName)
        {

            IEnumerable<string> words = ReadFrom($"C:\\Users\\Michal\\source\\repos\\LanguagesAndCompilers\\week2\\TeleprompterConsole\\speeches\\{fileName}.txt");
            foreach (string word in words)
            {

                Console.Write(word);
                if (!string.IsNullOrWhiteSpace(word))
                {
                    await Task.Delay(config.DelayInMilliseconds);
                }

            }

            config.Done = true;

        }

        public static async Task RunTeleprompter(string fileName)
        {

            TeleprompterConfig config = new TeleprompterConfig();
            Task displayTask = ShowTeleprompter(config, fileName);
            Task speedTask = GetInput(config);
            await Task.WhenAny(displayTask, speedTask);


        }

        private static async Task GetInput(TeleprompterConfig config)
        {

            void CheckKeyPress()
            {

                while (!config.Done)
                {

                    int choice = 0;
                    Int32.TryParse(string.Empty + (char)Console.ReadKey(true).Key, out choice);
                    switch (choice)
                    {

                        case 1: config.UpdateDelay(100); break;
                        case 2: config.UpdateDelay(400); break;
                        case 3: config.UpdateDelay(700); break;
                        case 4: config.UpdateDelay(1000); break;
                        case 5: config.UpdateDelay(2000); break;

                    }

                }

            }

            await Task.Run(CheckKeyPress);

        }

    }

}
