using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PieceLibrary
{
    static List<LibraryEntry> Entries = new List<LibraryEntry>();
    
    static PieceLibrary()
    {
        PieceComponent[] currentEntry;

        currentEntry = new PieceComponent[1];
        currentEntry[0] = new PieceComponent(0, 0, 0);
        Entries.Add(new LibraryEntry() { Pieces = currentEntry, Weight = 0.3f });

        currentEntry = new PieceComponent[4];
        currentEntry[0] = new PieceComponent(0.5f, 0, 0);
        currentEntry[1] = new PieceComponent(1.5f, 0, 0);
        currentEntry[2] = new PieceComponent(-0.5f, 0, 0);
        currentEntry[3] = new PieceComponent(-1.5f, 0, 0);
        Entries.Add(new LibraryEntry() { Pieces = currentEntry, Weight = 1f });

        currentEntry = new PieceComponent[4];
        currentEntry[0] = new PieceComponent(0, 0, 0);
        currentEntry[1] = new PieceComponent(1, 0, 0);
        currentEntry[2] = new PieceComponent(0, 0, 1);
        currentEntry[3] = new PieceComponent(-1, 0, 0);
        Entries.Add(new LibraryEntry() { Pieces = currentEntry, Weight = 1f });

        currentEntry = new PieceComponent[4];
        currentEntry[0] = new PieceComponent(0, 0, 0.5f);
        currentEntry[1] = new PieceComponent(0, 0, -0.5f);
        currentEntry[2] = new PieceComponent(1, 0, 0.5f);
        currentEntry[3] = new PieceComponent(-1, 0, -0.5f);
        Entries.Add(new LibraryEntry() { Pieces = currentEntry, Weight = 1f });

        currentEntry = new PieceComponent[3];
        currentEntry[0] = new PieceComponent(0, 0, 0);
        currentEntry[1] = new PieceComponent(1, 0, 0);
        currentEntry[2] = new PieceComponent(0, 0, 1);
        Entries.Add(new LibraryEntry() { Pieces = currentEntry, Weight = 1f });

        currentEntry = new PieceComponent[4];
        currentEntry[0] = new PieceComponent(0, 0, 0);
        currentEntry[1] = new PieceComponent(-1, 0, 0);
        currentEntry[2] = new PieceComponent(1, 0, 0);
        currentEntry[3] = new PieceComponent(1, 0, 1);
        Entries.Add(new LibraryEntry() { Pieces = currentEntry, Weight = 1f });


    }
    public static PieceComponent[] PickPiece()
    {
        float totalWeight = 0f;
        float runningWeight = -0.000001f;
        foreach (LibraryEntry x in Entries)
        {
            totalWeight += x.Weight;
        }
        float target = Random.value * totalWeight;
        foreach (LibraryEntry x in Entries)
        {
            if (target <= x.Weight + runningWeight)
            {
                return x.GetPieces();
            }
            runningWeight += x.Weight;
        }
        return Entries[0].GetPieces();
    }
}

public class LibraryEntry
{
    public PieceComponent[] Pieces { get; set; }
    public float Weight { get; set; }

    public PieceComponent[] GetPieces()
    {
        PieceComponent[] output = new PieceComponent[Pieces.Length];
        for(int i = 0; i < output.Length; i++)
        {
            output[i] = new PieceComponent(Pieces[i].GetX(), Pieces[i].GetY(), Pieces[i].GetZ());
        }
        return output;
    }
}
