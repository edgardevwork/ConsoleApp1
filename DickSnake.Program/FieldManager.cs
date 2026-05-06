using DickSnake.ConsoleUi;
using DickSnake.Models;

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

        for (int row = 0; row < field.gridHeight; row++)
        {
            for (int col = 0; col < field.gridWidth; col++)
            {
                if (row == 0)
                {
                    if (col == 0)
                    {
                        ConsoleManager.FieldPrint(0, col, row);
                    }
                    else if (col == field.gridWidth - 1)
                    {
                        ConsoleManager.FieldPrint(3, col, row);
                    }
                    else
                    {
                        ConsoleManager.FieldPrint(5, col, row);
                    }
                }
                else if (row == field.gridHeight - 1)
                {
                    if (col == 0)
                    {
                        ConsoleManager.FieldPrint(2, col, row);
                    }
                    else if (col == field.gridWidth - 1)
                    {
                        ConsoleManager.FieldPrint(4, col, row);
                    }
                    else
                    {
                        ConsoleManager.FieldPrint(5, col, row);
                    }
                }
                else
                {
                    if (col == 0)
                    {
                        ConsoleManager.FieldPrint(1, col, row);
                    }
                    else if (col == field.gridWidth - 1)
                    {
                        ConsoleManager.FieldPrint(1, col, row);
                    }
                    else
                    {
                        ConsoleManager.FreePrint(col, row);
                    }
                }
            }
        }
        field.snake = new Snake();
    }
}
