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
        Console.WriteLine("Testing Mexican Train");
        Console.WriteLine("Test 1: Train should be empty:");
        Console.WriteLine(train.IsEmpty ? "Passed" : "Failed");

        // Test 2: Adding dominos to the train
        Domino d1 = new Domino(1, 2);
        Domino d2 = new Domino(2, 3);
        train.AddDomino(d1);
        train.AddDomino(d2);

        Console.WriteLine("Test 2: Adding 2 dominos, which are (1,2) and (2,3) ");
        Console.WriteLine(train.Count == 2 ? "Passed" : "Failed");

        // Test 3: Last domino in the train
        Console.WriteLine("Test 3: Last domino, which should be " + d2.ToString());
        Console.WriteLine(train.LastDomino.Equals(d2) ? "Passed" : "Failed");

        // Test 4: Playable value
        Console.WriteLine("Test 4: Playable value");
        Console.WriteLine(train.PlayableValue == 3 ? "Passed" : "Failed");

        // Test 5: Indexer
        Console.WriteLine("Test 5: Checking to see if the first domino is (1, 2), this should pass");
        Console.WriteLine(train[0].Equals(d1) ? "Passed" : "Failed");

        Domino d3 = new Domino(3, 4);

        // Test 6: ToString
        Console.WriteLine("Test 6: ToString");
        string trainString = train.ToString();
        Console.WriteLine(trainString);

        // Adding Hand and testing the IsPlayable with Hand
        Hand hand = new Hand();
        hand.Dominos.Add(new Domino(3, 4));
        bool mustFlipHand;
        Console.WriteLine("Test 7: IsPlayable with Hand");
        Console.WriteLine(train.IsPlayable(hand, d3, out mustFlipHand) && !mustFlipHand ? "Passed" : "Failed");

        Console.WriteLine("\nTesting Player Train");
        Hand playerHand = new Hand();
        playerHand.Dominos.Add(new Domino(5, 6));
        playerHand.Dominos.Add(new Domino(6, 7));
        PlayerTrain playerTrain1 = new PlayerTrain(playerHand);
        Console.WriteLine("Player Train created without engine value");

        PlayerTrain playerTrain2 = new PlayerTrain(playerHand, 3);
        Console.WriteLine("We created a Player Train with engine value 3.");

        Console.WriteLine("Test 1: The train should be closed");
        Console.WriteLine(!playerTrain1.IsOpen ? "Passed" : "Failed");

        Console.WriteLine("Test 2: Opening and closing our train");
        playerTrain1.Open();
        Console.WriteLine("Opening train");
        Console.WriteLine(playerTrain1.IsOpen ? "Passed" : "Failed");
        playerTrain1.Close();
        Console.WriteLine("Closing train");
        Console.WriteLine(!playerTrain1.IsOpen ? "Passed" : "Failed");

        Console.WriteLine("Test 3: Adding dominos and checking the PlayableValue which should be 6");
        Domino d4 = new Domino(3, 4);
        Domino d5 = new Domino(4, 6);
        playerTrain2.AddDomino(d4);
        playerTrain2.AddDomino(d5);
        Console.WriteLine(playerTrain2.PlayableValue == 6 ? "Passed" : "Failed");

        Console.WriteLine("Test 4: Last domino");
        Console.WriteLine(playerTrain2.LastDomino.Equals(d5) ? "Passed" : "Failed");

        Console.WriteLine("Test 5: Testing IsPlayable with hand");
        Hand testHand = new Hand();
        testHand.Dominos.Add(new Domino(6, 7));
        bool mustFlip1;
        Console.WriteLine(playerTrain2.IsPlayable(testHand, testHand.Dominos[0], out mustFlip1) && !mustFlip1 ? "Passed" : "Failed");

        Console.WriteLine("\nTesting Interfaces");
        Console.WriteLine("Test 1: Dominos sort");
        Console.WriteLine("Creating a domino list with: (3,5) (1,4) (2,5) (3,6)");
        List<Domino> dominos = new List<Domino>
        {
            new Domino(3,5),
            new Domino(1,4),
            new Domino(2,5),
            new Domino(3,6)
        };
        dominos.Sort();
        Console.WriteLine("Here are the dominos sorted out");

        foreach (Domino domino in dominos)
        {
            Console.WriteLine(domino.ToString());
        }
        Console.WriteLine("Test 2: Testing iterations");
        MexicanTrain mexicanTrain = new MexicanTrain(0);
        mexicanTrain.AddDomino(new Domino(0, 1));
        mexicanTrain.AddDomino(new Domino(1, 3));
        mexicanTrain.AddDomino(new Domino(3, 4));

        foreach (Domino domino in mexicanTrain) { Console.WriteLine(domino.ToString());}
    }
}