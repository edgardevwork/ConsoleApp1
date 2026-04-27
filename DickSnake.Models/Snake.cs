using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using static System.Net.WebRequestMethods;

namespace DickSnake.Models;
public class Snake
{
    public List<TailSnakePos> tailSnakePos;
    public int facePosX;
    public int facePosY;

    public Snake(int bufX, int bufY)
    {
        tailSnakePos = new List<TailSnakePos>();
        facePosX = 3;
        facePosY = 3;
        tailSnakePos.Add(new TailSnakePos(facePosX-1, facePosY));
        Draw(); // Отрисовка змеи
    }

    public void Draw()
    {
        Console.SetCursorPosition(facePosX, facePosY);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("@"); // Голова

        foreach (var segment in tailSnakePos)
        {
            Console.SetCursorPosition(segment.positionX, segment.positionY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("#"); // Хвост
        }

        Console.ForegroundColor = ConsoleColor.White;
    }
}
