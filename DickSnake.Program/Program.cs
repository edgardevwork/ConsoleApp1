using DickSnake.BusinessLogic.Helpers;
using DickSnake.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        FieldManager fieldManager = new FieldManager();
        Food food = new Food(fieldManager.field);
        var keyHelper = new KeyHelper();
        SnakeManager snake = new SnakeManager(fieldManager.field, food, keyHelper);
        keyHelper.StartListening();

        while (true) ;
    }
}