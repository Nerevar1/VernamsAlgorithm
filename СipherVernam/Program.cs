using System;

namespace VernamCipher
{
    class Program
    {
        public static string alphabet;
        public static int m;
        static void Main(string[] args)
        {

            Console.WriteLine("Введите алфавит");
            alphabet = Console.ReadLine();
            // абвгдеёжзийклмнопрстуфхцчшщъыьэюя
            // абвгдежзийклмнопрстуфхцчшщъыьэюя

            m = alphabet.Length;//мощность алфавита

            Console.WriteLine("Введите сообщение");
            string message = Console.ReadLine().ToLower();

            Console.WriteLine("Введите гамму");
            string gamma = Console.ReadLine().ToLower();

            string EncryptedMessage = null;
            int cntGamma = 0;
            for (int i = 0; i < message.Length; i++)//цикл шифровки сообщения
            {
                if (cntGamma > gamma.Length - 1)
                {
                    cntGamma = 0;
                }
                int x = (FindNumLetter(message[i]) + FindNumLetter(gamma[cntGamma])) % m;
                cntGamma++;
                EncryptedMessage += Convert.ToString(alphabet[x]);

            }
            cntGamma = 0;
            Console.WriteLine("Шифровка - " + EncryptedMessage);

            string DecryptedMessage = null;
            for (int i = 0; i < message.Length; i++)//цикл РАСшифровки сообщения
            {
                if (cntGamma > gamma.Length - 1)
                {
                    cntGamma = 0;
                }
                int x = (m + (FindNumLetter(EncryptedMessage[i]) - FindNumLetter(gamma[cntGamma]))) % m;
                cntGamma++;
                //Console.WriteLine(x);
                DecryptedMessage += Convert.ToString(alphabet[x]);
            }

            Console.WriteLine("Расшифрованное сообщение");
            Console.WriteLine(DecryptedMessage);
        }
        public static int FindNumLetter(char letter)
        {
            int numletter = 0;
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (letter == alphabet[i])
                {
                    numletter = i;
                    break;
                }
            }
            return numletter;
        }
    }
}