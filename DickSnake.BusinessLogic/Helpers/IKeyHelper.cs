namespace DickSnake.BusinessLogic.Helpers;

public interface IKeyHelper
{
    public event AccountHandler KeyPressed;

    void StartListening();
}

public delegate void AccountHandler(ConsoleKey key);