

using DickSnake.BusinessLogic.Helpers;
using DickSnake.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        FieldHelper.checkSize(Field.gridWidth, Field.gridHeight);
        Field field = new Field();
        var keyHelper = new KeyHelper();
        SnakeManager snake = new SnakeManager(keyHelper);
        keyHelper.StartListening();
        Food food = new Food();
        food.start();
        
        while (true) ;
    }
}