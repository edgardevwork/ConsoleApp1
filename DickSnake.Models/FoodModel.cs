namespace DickSnake.Models;
public class FoodModel
{
    public int X { get; set; }
    public int Y { get; set; }

    public FoodType foodType { get; set; }

    public FoodModel(int x, int y, FoodType foodType)
    {
        X = x;
        Y = y;
        this.foodType = foodType;
    }

    public int getX() => X;
    public int getY() => Y;
    
    public FoodType getFoodType() => foodType;
}