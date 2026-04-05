using System;
using System.Collections.Generic;
using System.Text;

namespace DickSnake.Models;

public class TailSnakePos
{
    public int positionX;
    public int positionY;

    public TailSnakePos(int positionX, int positionY)
    {
        this.positionX = positionX;
        this.positionY = positionY;
    }
}
