namespace BattleBoats
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(Constants.WindowWidth, Constants.WindowHeight);
            }
            else
            {
                Console.WriteLine("\n\nPlease ensure terminal is of adequate size in order to fit the following UI. Press Any Key To Continue");
                Console.ReadKey();
            }
            Menu.ShowMenu();
        }
    }
}
