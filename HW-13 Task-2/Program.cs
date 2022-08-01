using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HW_13_Task_2
{
    class Program
    {
        // объявляем словарь, в котором ключ - слово, значение - кол-во этого слова в тексте
        public static Dictionary<string, int> dictionary = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            // читаем весь файл в строку текста
            string text = File.ReadAllText("C:\\Work\\skillFactori\\unit 13\\text11.txt");
            //Console.WriteLine(text.Length); // можно вывести длину(количество символов) и весь текст, для контроля
            //Console.WriteLine(text);
            //Console.WriteLine();

            // убираем из текста знаки пунктуации
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            //Console.WriteLine(noPunctuationText.Length); // можно вывести длину(количество символов) и текст после того, как убрали знаки пунктуации
            //Console.WriteLine(noPunctuationText);
            //Console.WriteLine();

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // выводим количество элементов (для проверки)
            Console.WriteLine($"Всего записано элементов: {words.Length}");
            Console.WriteLine();

            foreach (var key in words) // перебираем все элементы
            {
                if (dictionary.ContainsKey(key)) // если элемент найден по ключу
                {
                    if (dictionary.TryGetValue(key, out int number)) // достаем значение, увеличиваем на еденицу
                    {
                        number++;
                        dictionary[key] = number; //
                    }                       
                }
                else
                    dictionary.Add(key, 1);  //     иначе, добавляем ключ и значение(1 - т.е. слово встретилось 1 раз)    
            }

            // сортируем словарь по значению в порядке убывания 
            dictionary = dictionary.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            int i = 0;
            Console.WriteLine("В тексте чаще всего встречались следующие слова:");
            Console.WriteLine();
            
                foreach (var word in dictionary) // перебераем элементы словаря
                {
                    Console.WriteLine("Слово '{0}' в количестве {1} ", word.Key, word.Value); // выводим элемент (слово и кол-во его в тексте)
                    i++;
                    if (!(i < 10 & i < dictionary.Count)) // если элементов больше 10 и больше, чем всего элементов в словаре, выходим
                    {
                    break;
                    }
                } 
                
            Console.ReadKey();           
        }
    }
}
