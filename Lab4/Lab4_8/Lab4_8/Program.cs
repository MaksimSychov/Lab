using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Нажмите 1, если хотите выбрать Шифр Атбаш\nНажмите 2, если хотите выбрать Шифр Вернама\nНажмите 3, если хотите выбрать Шифр простой одинарной перестановки");
        string selector = Console.ReadLine();
        //Шифр Атбаш
        if (selector == "1")
        {
            var atbash = new Atbash();
            Console.Write("Введите текст сообщения: ");
            var text = Console.ReadLine();
            var EnglishEncryptedMessage = atbash.EnglishEncryptText(text);
            Console.WriteLine("Зашифрованный английский текст: {0}", EnglishEncryptedMessage);
            var EnglishDecryptedMessage = atbash.EnglishDecryptText(EnglishEncryptedMessage);
            Console.WriteLine("Расшифрованный английский текст: {0}", EnglishDecryptedMessage);
            var RussianEncryptedMessage = atbash.RussianEncryptText(text);
            Console.WriteLine("Зашифрованный русский текст: {0}", RussianEncryptedMessage);
            var RussianDecryptedMessage = atbash.RussianDecryptText(RussianEncryptedMessage);
            Console.WriteLine("Расшифрованный русский текст: {0}", RussianDecryptedMessage);
            Console.ReadKey();
        }
        //Шифр Вернама
        if (selector == "2")
        {
            Console.WriteLine("Введите текст (каждую букву через пробел): ");
            string text = Console.ReadLine();
            Console.WriteLine("Введите ключ (каждую цифру через пробел): ");
            string key = Console.ReadLine();
            if (key.Length != text.Length)
            {
                return;
            }
            string vernamCipherText = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                vernamCipherText += (char)(text[i] ^ key[i]);
            }
            Console.WriteLine(vernamCipherText);
            Console.ReadKey();
        }
        //Шифр простой одинарной перестановки
        if (selector == "3")
        {
            Console.WriteLine("Введите текст: ");
            string text = Console.ReadLine();
            Console.WriteLine("Введите ключ (каждую цифру через пробел): ");
            string key = Console.ReadLine();
            string encrypted = Encrypt(text, key);
            string decrypted = Decrypt(encrypted, key);
            Console.WriteLine("Расшифрованный текст: " + decrypted);
            Console.WriteLine("Зашифрованный текст: " + encrypted);
            Console.ReadKey();
        }
    }
    //Шифр Атбаш
    public class Atbash
    {
        public const string RussianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public const string EnglishAlphabet = "abcdefghijklmnopqrstuvwxyz";
        public string Reverse(string inputText)
        {
            var reversedText = string.Empty;
            foreach (var s in inputText)
            {
                reversedText = s + reversedText;
            }
            return reversedText;
        }
        public string EnglishEncryptDecrypt(string text, string symbols, string cipher)
        {
            text = text.ToLower();
            var outputText = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                var index = symbols.IndexOf(text[i]);
                if (index >= 0)
                {
                    outputText += cipher[index].ToString();
                }
            }
            return outputText;
        }
        public string RussianEncryptDecrypt(string text, string symbols, string cipher)
        {
            text = text.ToLower();
            var outputText = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                var index = symbols.IndexOf(text[i]);
                if (index >= 0)
                {
                    outputText += cipher[index].ToString();
                }
            }
            return outputText;
        }
        public string EnglishEncryptText(string plainText)
        {
            return EnglishEncryptDecrypt(plainText, EnglishAlphabet, Reverse(EnglishAlphabet));
        }
        public string EnglishDecryptText(string EnglishEncryptedText)
        {
            return EnglishEncryptDecrypt(EnglishEncryptedText, Reverse(EnglishAlphabet), EnglishAlphabet);
        }
        public string RussianEncryptText(string plainText)
        {
            return RussianEncryptDecrypt(plainText, RussianAlphabet, Reverse(RussianAlphabet));
        }
        public string RussianDecryptText(string RussianEncryptedText)
        {
            return RussianEncryptDecrypt(RussianEncryptedText, Reverse(RussianAlphabet), RussianAlphabet);
        }
    }
    //Шифр простой одинарной перестановки
    static string Decrypt(string text, string key)
    {
        string res = "";
        string[] strKey = key.Split(' ');
        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j < strKey.Length; j++)
            {
                if (int.Parse(strKey[j]) == i + 1)
                {
                    res += text[j];
                    break;
                }
            }
        }
        return res;
    }
    static string Encrypt(string text, string key)
    {
        string res = "";
        string[] strKey = key.Split(' ');
        for (int i = 0; i < strKey.Length; i++)
        {
            res += text[int.Parse(strKey[i]) - 1];
        }
        return res;
    }
}