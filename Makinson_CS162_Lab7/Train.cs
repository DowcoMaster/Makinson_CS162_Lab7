using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoneyardClasses;
using DominoClasses;

public abstract class Train : IEnumerable<Domino>
{
    protected List<Domino> dominos = new List<Domino>();
    protected int engineValue;
    public IEnumerator<Domino> GetEnumerator()
    {
        return dominos.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public int Count
    {
        get
        {
            return dominos.Count;
        }
    }
    public int EngineValue
    {
        get
        {
            return engineValue;
        }
        set
        {
            engineValue = value;
        }
    }
    public bool IsEmpty
    {
        get
        {
            return dominos.Count == 0;
        }
    }
    public Domino LastDomino
    {
        get
        {
            if (dominos.Count == 0)
                throw new InvalidOperationException("Train is empty");
            return dominos[dominos.Count - 1];
        }

    }
    public int PlayableValue
    {
        get
        {
            if (dominos.Count == 0)
            {
                return EngineValue;
            }
            return LastDomino.RightDot;
        }
    }
    public Domino this[int i]
    {
        get
        {
            return dominos[i];
        }
    }
    public void AddDomino(Domino d)
    {
        dominos.Add(d);
    }
    public bool IsPlayable(Domino d, out bool mustFlip)
    {
        mustFlip = false;
        if (dominos.Count == 0)
            return true;
        if (d.LeftDot == LastDomino.RightDot || d.RightDot == LastDomino.RightDot)
            return true;
        if (d.LeftDot == LastDomino.LeftDot || d.RightDot == LastDomino.LeftDot)
        {
            mustFlip = true;
            return true;
        }
        return false;
    }
    public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);
    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("Engine Value: " + EngineValue + "\n");
        stringBuilder.Append("Dominos: \n");
        foreach (var d in dominos)
        {
            stringBuilder.Append(d.ToString() + "\n");
        }
        return stringBuilder.ToString();
    }
    public void Play(Hand h, Domino d)
    {
        bool mustFlip = false;
        if (IsPlayable(h, d, out mustFlip))
        {
            if (mustFlip)
            {
                d.Flip();
                dominos.Add(d);
            }
            else
            {
                throw new Exception("Domino " + d.ToString() + " does not match last domino in the train and cannot be played");
            }
        }
    }
}