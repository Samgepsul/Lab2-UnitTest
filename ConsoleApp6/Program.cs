
using System;
using System.Collections.Generic;
using ConsoleApp6;

public class Program
{
    public static Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
    private static WordDictionary dict = new WordDictionary();
    static void Main()
    {
        Console.WriteLine("Добро пожаловать в программу словаря однокоренных слов!");

        while (true)
        {
            Console.Write("\nВведите слово (Для выхода введите 'q'): ");
            string inputWord = Console.ReadLine().Trim();

            if (inputWord == "q")
            {
                Console.WriteLine("Выход из программы.");
                break;
            }

            if (dict.Contains(inputWord))
            {
                DisplayRelatedWords(inputWord);
            }
            else
            {
                Console.Write($"Неизвестное слово. Хотите добавить его в словарь (y/n)? ");
                char response = Console.ReadLine()[0];

                if (response == 'y')
                {
                    AddWordToDictionary(inputWord);
                }
            }
        }
    }

    public static void AddWordToDictionary(string word)
    {
        string prefix = "";
        while (true)
        {
            Console.Write("Приставка: ");
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            prefix += input;
        }

        Console.Write("Корень: ");
        string root = Console.ReadLine().Trim();

        string suffix = "";
        while (true)
        {
            Console.Write("Суффикс или окончание: ");
            string input = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            suffix += input;
        }

        string newWord = ($"{prefix}{root}{suffix}");

        if (!IsWordValid(newWord, word))
        {
            Console.WriteLine("Неверные части слова. Пожалуйста, повторите ввод.");
            return;
        }

        Word w = new Word();
        w.Prefix = prefix;
        w.Root = root;
        w.Suffix = suffix;
        //..

        dict.Add(w);

        if (dictionary.ContainsKey(word))
        {
            dictionary[word].Add(newWord);
        }
        else
        {
            dictionary[word] = new List<string> { newWord };
        }

        Console.WriteLine($"Слово \"{newWord}\" добавлено.");
    }

    public static bool IsWordValid(string word, string originalWord)
    {
        string[] parts = word.Split('-');
        string assembledWord = string.Join("", parts);

        return assembledWord == originalWord;
    }

    public static void DisplayRelatedWords(string word)
    {
        Console.WriteLine($"Известные однокоренные слова для \"{word}\":");

        Console.WriteLine(string.Join(Environment.NewLine, dict.FindByRoot(word)));

        return;

        static List<string> FindWordsWithSameRoot(string word)
        {
            List<string> relatedWords = new List<string>();

            foreach (var entry in dictionary)
            {
                if (entry.Key != word && entry.Key.Contains(word))
                {
                    relatedWords.AddRange(entry.Value);
                }
            }

            return relatedWords;
        }
    }
}
