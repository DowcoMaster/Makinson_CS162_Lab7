using System;
using System.Collections.Generic;
using System.Diagnostics;
using BoneyardClasses;
using DominoClasses;

public class MexicanTrain : Train
{
    // Default constructor
    public MexicanTrain()
    {
    }

    // Constructor with engine value
    public MexicanTrain(int engineValue)
    {
        this.EngineValue = engineValue;
    }

    // Implementation of the abstract IsPlayable method
    protected override bool IsPlayable(Hand hand, Domino domino, out bool mustFlip)
    {
        mustFlip = false;
        foreach (Domino d in hand.Dominos)
        {
            if (base.IsPlayable(d, out bool flip))
            {
                mustFlip = flip;
                return true;
            }
        }
        return false;
    }
}