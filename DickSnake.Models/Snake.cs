using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using static System.Net.WebRequestMethods;
using DickSnake.ConsoleUi;

namespace DickSnake.Models;
public class Snake
{
    public List<TailSnakePos> tailSnakePos;
    public int facePosX;
    public int facePosY;

    public Snake()
    {
        tailSnakePos = new List<TailSnakePos>();
        facePosX = 2;
        facePosY = 1;
        tailSnakePos.Add(new TailSnakePos(facePosX-1, facePosY));
        Draw(); // Отрисовка змеи
    }

    public void Draw()
    {
        ConsoleManager.SnakePrint(true, facePosX, facePosY);

        foreach (var segment in tailSnakePos)
        {
            ConsoleManager.SnakePrint(false, segment.positionX, segment.positionY);
        }
    }
}
