namespace ConsoleManager
{
    public interface IConsoleManager
    {
        void Write(string value);
        void WriteLine(string value);
        void WriteLine();
        string ReadLine();
    }
}
