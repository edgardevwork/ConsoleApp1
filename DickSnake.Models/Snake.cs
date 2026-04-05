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
        facePosX = 1;
        facePosY = 0;
        Draw(); // Отрисовка змеи
    }

    void Draw()
    {
        tailSnakePos.Add(new TailSnakePos(facePosX - 1, facePosY));
        Console.SetCursorPosition(tailSnakePos[0].positionX, tailSnakePos[0].positionY);
        Console.Write("-");
        Console.SetCursorPosition(facePosX, facePosY);
        Console.Write("@");
    }
}
