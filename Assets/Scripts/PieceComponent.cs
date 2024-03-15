using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceComponent
{

    float PositionX;
    float PositionY;
    float PositionZ;
    
    public PieceComponent(float x, float y, float z)
    {
        PositionX = x;
        PositionY = y;
        PositionZ = z;
    }
    public void SetX(float x)
    {
        PositionX = x;
    }
    public float GetX()
    {
        return PositionX;
    }
    public void SetY(float y)
    {
        PositionY = y;
    }
    public float GetY()
    {
        return PositionY;
    }
    public void SetZ(float z)
    {
        PositionZ = z;
    }
    public float GetZ()
    {
        return PositionZ;
    }
    public void SetPosition(int x, int y, int z)
    {
        PositionX = x;
        PositionY = y;
        PositionZ = z;
    }
}
