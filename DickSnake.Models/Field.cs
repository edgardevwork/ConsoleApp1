using DickSnake.Models;
using System.Text;

// отделяем модель от бизнес-логики, - я правильно сделал?
public class Field
{
    public int gridWidth = 25;
    public int gridHeight = 25;
    public Snake snake;
    public List<FoodModel> foods = new List<FoodModel>();
}
