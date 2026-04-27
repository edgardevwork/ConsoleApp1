
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
        field.snake = new Snake(field.gridWidth, field.gridHeight);
        StringBuilder stringBuilder = new StringBuilder();

        for (int row = 0; row < field.gridHeight; row++)
        {
            for (int col = 0; col < field.gridWidth; col++)
            {
                if(col != 0)
                {
                    if(row == 0 && col != field.gridWidth - 1)
                    {
                        stringBuilder.Append("═");
                    } else if(row == 0 && col == field.gridWidth - 1) {
                        stringBuilder.Append("╗");
                    }
                    continue;
                }
                if(col == 0 && row != 0 && row != field.gridHeight-1)
                {
                    stringBuilder.Append("║");
                } else if(col == 0 && row == 0){
                    stringBuilder.Append("╔");
                } else if (col == 0 && row < field.gridHeight){
                    stringBuilder.Append("╚");
                }
                stringBuilder.Append(" ");
            }

            Console.WriteLine(stringBuilder.ToString());
            stringBuilder.Clear();
        }
    }
}
