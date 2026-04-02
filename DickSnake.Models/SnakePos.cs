using System;
using System.Collections.Generic;
using System.Text;

namespace DickSnake.Models;

public class SnakePos
{
    public int positionX;
    public int positionY;

    public SnakePos(int positionX, int positionY)
    {
        this.positionX = positionX;
        this.positionY = positionY;
    }
}
