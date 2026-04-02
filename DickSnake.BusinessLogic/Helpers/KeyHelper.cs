namespace DickSnake.BusinessLogic.Helpers;

public class KeyHelper : IKeyHelper
{
    public event AccountHandler? KeyPressed;

    public void StartListening()
    {
        ConsoleKey currentKey = ConsoleKey.Backspace;
        Task.Run(() => {
            do
            {
                while (!Console.KeyAvailable)
                {
                    currentKey = Console.ReadKey(true).Key;
                    KeyPressed?.Invoke(currentKey);
                }
            } while (currentKey != ConsoleKey.Escape);
        });
    }
}
