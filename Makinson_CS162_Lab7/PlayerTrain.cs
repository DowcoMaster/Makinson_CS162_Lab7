using System;
using System.Collections.Generic;
using System.Diagnostics;
using BoneyardClasses;
using DominoClasses;

public class PlayerTrain : Train
{
    public Hand Hand { get; private set; }
    public bool IsOpen { get; private set; }

    // Constructor with hand
    public PlayerTrain(Hand hand)
    {
        this.Hand = hand;
    }

    // Constructor with hand and engine value
    public PlayerTrain(Hand hand, int engineValue)
    {
        this.Hand = hand;
        this.EngineValue = engineValue;
    }

    // Method to open the train
    public void Open()
    {
        IsOpen = true;
    }

    // Method to close the train
    public void Close()
    {
        IsOpen = false;
    }

    // Implementation of the abstract IsPlayable method
    public override bool IsPlayable(Hand hand, Domino domino, out bool mustFlip)
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