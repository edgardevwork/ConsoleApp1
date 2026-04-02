using DickSnake.BusinessLogic.Helpers;
using DickSnake.Models;
using System.Text;

// отделяем модель от бизнес-логики, - я правильно сделал?
public class Field
{
    public static int gridWidth = 25;
    public static int gridHeight = 25;
    Snake snake;
    public static List<FoodModel> foods = new List<FoodModel>();
    public Field()
	{
        var keyHelper = new KeyHelper();
        snake = new Snake(keyHelper);

        keyHelper.StartListening();
        StringBuilder stringBuilder = new StringBuilder();

        for (int row = 0; row < gridHeight; row++)
        {
            for (int col = 0; col < gridWidth; col++)
            {
                stringBuilder.Append(" ");
            }

            Console.WriteLine(stringBuilder.ToString());
            stringBuilder.Clear();
        }
    }
}
