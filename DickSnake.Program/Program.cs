

internal class Program
{
    private static void Main(string[] args)
    {
        FieldHelper.checkSize(Field.gridWidth, Field.gridHeight);
        Field field = new Field();
        Food food = new Food();
        food.start();
        //snake.readKeys();
        while (true) ;
    }
}