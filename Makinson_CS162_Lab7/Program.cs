using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DominoClasses;
using BoneyardClasses;

class Program
{
    static void Main(string[] args)
    {
        // Create a test train
        MexicanTrain train = new MexicanTrain();

        // Test 1: Train is initially empty
        Console.WriteLine("Test 1: Is train empty?");
        Console.WriteLine(train.IsEmpty ? "Passed" : "Failed");

        // Test 2: Adding dominos to the train
        Domino d1 = new Domino(1, 2);
        Domino d2 = new Domino(2, 3);
        train.AddDomino(d1);
        train.AddDomino(d2);

        Console.WriteLine("Test 2: Adding dominos");
        Console.WriteLine(train.Count == 2 ? "Passed" : "Failed");

        // Test 3: Last domino in the train
        Console.WriteLine("Test 3: Last domino");
        Console.WriteLine(train.LastDomino.Equals(d2) ? "Passed" : "Failed");

        // Test 4: Playable value
        Console.WriteLine("Test 4: Playable value");
        Console.WriteLine(train.PlayableValue == 3 ? "Passed" : "Failed");

        // Test 5: Indexer
        Console.WriteLine("Test 5: Indexer");
        Console.WriteLine(train[0].Equals(d1) ? "Passed" : "Failed");

        // Test 6: IsPlayable
        bool mustFlip;
        Domino d3 = new Domino(3, 4);
        //Console.WriteLine("Test 6: IsPlayable");
        //Console.WriteLine(train.IsPlayable(d3, out mustFlip) && !mustFlip ? "Passed" : "Failed");

        // Test 6: ToString
        Console.WriteLine("Test 6: ToString");
        string trainString = train.ToString();
        Console.WriteLine(trainString.Contains("Engine Value: 0") && trainString.Contains("1|2") && trainString.Contains("2|3") ? "Passed" : "Failed");

        // Adding Hand and testing the IsPlayable with Hand
        Hand hand = new Hand();
        hand.Dominos.Add(new Domino(3, 4));
        bool mustFlipHand;
        //Console.WriteLine("Test 8: IsPlayable with Hand");
        //Console.WriteLine(train.IsPlayable(hand, d3, out mustFlipHand) && !mustFlipHand ? "Passed" : "Failed");

        Console.WriteLine("All tests completed.");
    }
}