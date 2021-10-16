namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Result(11111);
            Console.ReadLine();
        }
        static void Result(int seconds)
        {
            TimeSpan a = new TimeSpan(0, 0, seconds);
            Console.WriteLine("Часов: {0}\nМинут: {1}", a.Hours, a.Minutes);
            Console.ReadKey();
        }
    }
}