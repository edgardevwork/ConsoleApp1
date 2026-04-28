
using DickSnake.Models;
using System.Text;

public class FieldManager
{
    public Field field;
    public FieldManager()
    {
        field = new Field();
        var newSize = FieldHelper.checkSize();
        field.gridWidth = newSize.width;
        field.gridHeight = newSize.height;
        add();
    }

    public void add()
    {
        StringBuilder stringBuilder = new StringBuilder();

        for (int row = 0; row < field.gridHeight; row++)
        {
            for (int col = 0; col < field.gridWidth; col++)
            {
                if (row == 0)
                {
                    if (col == 0)
                    {
                        stringBuilder.Append("╔");
                    }
                    else if (col == field.gridWidth - 1)
                    {
                        stringBuilder.Append("╗");
                    }
                    else
                    {
                        stringBuilder.Append("═");
                    }
                }
                else if (row == field.gridHeight - 1)
                {
                    if (col == 0)
                    {
                        stringBuilder.Append("╚");
                    }
                    else if (col == field.gridWidth - 1)
                    {
                        stringBuilder.Append("╝");
                    }
                    else
                    {
                        stringBuilder.Append("═");
                    }
                }
                else
                {
                    if (col == 0)
                    {
                        stringBuilder.Append("║");
                    }
                    else if (col == field.gridWidth - 1)
                    {
                        stringBuilder.Append("║");
                    }
                    else
                    {
                        stringBuilder.Append(" ");
                    }
                }
            }
            Console.WriteLine(stringBuilder.ToString());
            stringBuilder.Clear();
        }
        field.snake = new Snake(field.gridWidth, field.gridHeight);
    }
}
