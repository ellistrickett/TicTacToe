namespace ConsoleManager
{
    public class ConsoleManager : IConsoleManager
    {
        public void Write(string value)
        {
            Console.Write(value);
        }
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}