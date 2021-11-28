using System;
class Program
{
    static void Main(string[] args)
    {
        var atbash = new Atbash();
        Console.Write("Введите текст сообщения: ");
        var message = Console.ReadLine();
        var EnglishEncryptedMessage = atbash.EnglishEncryptText(message);
        Console.WriteLine("Зашифрованный английский текст: {0}", EnglishEncryptedMessage);
        var EnglishDecryptedMessage = atbash.EnglishDecryptText(EnglishEncryptedMessage);
        Console.WriteLine("Расшифрованный английский текст: {0}", EnglishDecryptedMessage);
        var RussianEncryptedMessage = atbash.RussianEncryptText(message);
        Console.WriteLine("Зашифрованный русский текст: {0}", RussianEncryptedMessage);
        var RussianDecryptedMessage = atbash.RussianDecryptText(RussianEncryptedMessage);
        Console.WriteLine("Расшифрованный русский текст: {0}", RussianDecryptedMessage);
        Console.ReadLine();
    }
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
}