using System;
using System.IO;
using Library;

namespace CharacterApp
{
    class Program
    {
        private static readonly char[] Alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        static void Main(string[] args)
        {
            string phrase;

            if (args.Length == 0)
            {
                Console.WriteLine("Enter a phrase");
                phrase = Console.ReadLine();
            } 
            else 
            {
                if (!File.Exists(args[0])) {
                    Console.WriteLine("Enter a valid file name");
                    return;
                }
                phrase = File.ReadAllText(args[0]);
            }

            CharacterCount counter = new CharacterCount();

            counter.ParseString(phrase);

            foreach (var letter in Alphabet)
            {
                Console.WriteLine("{0} : {1}", letter, counter.GetCountForLetter(letter));
            }

            Console.WriteLine("Press any key to continue...");
            phrase = Console.ReadLine();
        }
    }
}
