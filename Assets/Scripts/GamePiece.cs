using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece
{

    PieceComponent[] Pieces;

    int PositionX = 0;
    int PositionY = 0;
    int PositionZ = 0;

    public GamePiece()
    {
        SetPiece();
    }

    protected GamePiece(GamePiece input)
    {
        PositionX = input.GetPositionX();
        PositionY = input.GetPositionY();
        PositionZ = input.GetPositionZ();

        Pieces = input.GetPieces();

    }

    public GamePiece Clone()
    {
        return new GamePiece(this);
    }

    public void SetPiece()
    {
        Pieces = PieceLibrary.PickPiece();
    }

    public void SetPosition(int x, int y, int z)
    {
        PositionX = x;
        PositionY = y;
        PositionZ = z;
    }

    public int GetPositionX()
    {
        return PositionX;
    }
    
    public int GetPositionY()
    {
        return PositionY;
    }

    public int GetPositionZ()
    {
        return PositionZ;
    }

    public PieceComponent[] GetPieces()
    {
        PieceComponent[] piecesBuffer = new PieceComponent[Pieces.Length];
        for (int i = 0; i < Pieces.Length; i++)
        {
            piecesBuffer[i] = new PieceComponent(Pieces[i].GetX(), Pieces[i].GetY(), Pieces[i].GetZ());
        }
        return piecesBuffer;
    }

    public void RotateXZ(bool CounterClockwise)
    {
        if (CounterClockwise)
        {
            for (int i = 0; i < Pieces.Length; i++)
            {
                float tempX = Pieces[i].GetX();
                float tempZ = Pieces[i].GetZ();
                Pieces[i].SetX(tempZ);
                Pieces[i].SetZ(tempX * -1);
            }
        }
        else
        {
            for (int i = 0; i < Pieces.Length; i++)
            {
                float tempX = Pieces[i].GetX();
                float tempZ = Pieces[i].GetZ();
                Pieces[i].SetX(tempZ * -1);
                Pieces[i].SetZ(tempX);
            }
        }
    }

    public void RotateXY(bool CounterClockwise)
    {
        if (CounterClockwise)
        {
            for (int i = 0; i < Pieces.Length; i++)
            {
                float tempX = Pieces[i].GetX();
                float tempY = Pieces[i].GetY();
                Pieces[i].SetX(tempY * -1);
                Pieces[i].SetY(tempX);
            }
        }
        else
        {
            for (int i = 0; i < Pieces.Length; i++)
            {
                float tempX = Pieces[i].GetX();
                float tempY = Pieces[i].GetY();
                Pieces[i].SetX(tempY);
                Pieces[i].SetY(tempX * -1);
            }
        }
    }

    public void RotateYZ(bool CounterClockwise)
    {
        if (CounterClockwise)
        {
            for (int i = 0; i < Pieces.Length; i++)
            {
                float tempY = Pieces[i].GetY();
                float tempZ = Pieces[i].GetZ();
                Pieces[i].SetY(tempZ * -1);
                Pieces[i].SetZ(tempY);
            }
        }
        else
        {
            for (int i = 0; i < Pieces.Length; i++)
            {
                float tempY = Pieces[i].GetY();
                float tempZ = Pieces[i].GetZ();
                Pieces[i].SetY(tempZ);
                Pieces[i].SetZ(tempY * -1);
            }
        }
    }

    public void MoveX(int input)
    {
        PositionX += input;
    }

    public void MoveY(int input)
    {
        PositionY += input;
    }

    public void MoveZ(int input)
    {
        PositionZ += input;
    }

    public void Error()
    {
        Debug.Log("_____________________________________________________________________");
        Debug.Log(string.Format("This object had an error. It's position is ({0},{1},{2})", PositionX, PositionY, PositionZ));
        for (int i = 0; i < Pieces.Length; i++)
        {
            Debug.Log(string.Format("Piece {0} with position ({1}.{2},{3})", i + 1, Pieces[i].GetX(), Pieces[i].GetY(), Pieces[i].GetZ()));
        }
        Debug.Log("_____________________________________________________________________");
    }
}
