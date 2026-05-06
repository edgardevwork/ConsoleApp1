namespace DickSnake.ConsoleUi;

public class ConsoleManager
{// В данном случае консоль так как это консольная змейка, но в будущем это может быть UiManager.

    public static void FruitPrint(int foodType, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        switch (foodType)
        {
            case (int)1:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("A");
                    break;
                }
            case (int)2:
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("B");
                    break;
                }
            case (int)3:
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("W");
                    break;
                }
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void SnakePrint(bool isHead, int x, int y)
    {
        if(isHead) {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("@"); // Голова
        }
        else
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("#"); // Хвост
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void FreePrint(int x, int y)
    {
        Console.SetCursorPosition((int)x, (int)y);
        Console.Write(" ");
    }

    public static void FieldPrint(int idElement, int x, int y)
    {
        Console.SetCursorPosition((int)x, (int)y);
        switch(idElement)
        {
            case 0:
                {
                    Console.Write("╔");
                    break;
                }
            case 1:
                {
                    Console.Write("║");
                    break;
                }
            case 2:
                {
                    Console.Write("╚");
                    break;
                }
            case 3:
                {
                    Console.Write("╗");
                    break;
                }
            case 4:
                {
                    Console.Write("╝");
                    break;
                }
            case 5:
                {
                    Console.Write("═");
                    break;
                }
        }
    }
    public static void GameOverPrint()
    {
        Console.Clear();
        Console.WriteLine("ИГРА ОКОНЧЕНА!");
    }
}