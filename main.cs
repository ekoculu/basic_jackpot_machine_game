RandomReel(0);
static void RandomReel(int totalScore) //selects the color and assign the reel randomly - 0 is red, 1 is green, 2 is blue
{
    Random rnd = new Random();
    int colorIndex1 = rnd.Next(0, 3);
    int reel1 = AssignTheReel(colorIndex1);
    int colorIndex2 = rnd.Next(0, 3);
    int reel2 = AssignTheReel(colorIndex2);
    int colorIndex3 = rnd.Next(0, 3);
    int reel3 = AssignTheReel(colorIndex3);

    int score = 0;

    if ((reel1 == reel2) && (reel2 == reel3))
    { //same numbers
        if ((colorIndex1 == colorIndex2) && (colorIndex2 == colorIndex3))
        {
            score += 30;
            Message(score);
        }
        else if ((colorIndex1 != colorIndex2) && (colorIndex2 != colorIndex3) && (colorIndex1 != colorIndex3))
        {
            score += 28;
            Message(score);
        }
        else
        {
            score += 26;
            Message(score);
        }
    }
    else if (((reel1 + 1 == reel2) && (reel2 + 1 == reel3)) || ((reel3 + 1 == reel2) && (reel2 + 1 == reel1)))
    { //consecutive numbers
        if ((colorIndex1 == colorIndex2) && (colorIndex2 == colorIndex3))
        {
            score += 20;
            Message(score);
        }
        else if ((colorIndex1 != colorIndex2) && (colorIndex2 != colorIndex3) && (colorIndex1 != colorIndex3))
        {
            score += 18;
            Message(score);
        }
        else
        {
            score += 16;
            Message(score);
        }
    }
    else if ((reel1 != reel2) && (reel2 != reel3) && (reel1 != reel3))
    { //different numbers
        if ((colorIndex1 == colorIndex2) && (colorIndex2 == colorIndex3))
        {
            score += 10;
            Message(score);
        }
        else if ((colorIndex1 != colorIndex2) && (colorIndex2 != colorIndex3) && (colorIndex1 != colorIndex3))
        {
            score += 8;
            Message(score);
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("You lost.");
        }
    }
    else
    {
        if ((colorIndex1 == colorIndex2) && (colorIndex2 == colorIndex3))
        {
            score += 6;
            Message(score);
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("You lost.");
        }
    }
    if ((reel1 % 2 == 0 && reel2 % 2 == 0 && reel3 % 2 == 0) || (reel1 % 2 == 1 && reel2 % 2 == 1 && reel3 % 2 == 1))
    {
        score += 3;
        Console.WriteLine("You win $3 bonus.");
    }

    totalScore += score;
    Console.WriteLine("");
    Console.WriteLine("Do you want to play again?");
    string choice = Console.ReadLine();
    ApplyTheChoice(choice, totalScore);
}
static int AssignTheReel(int colorIndex)
{
    Random rnd1 = new Random();
    int reel = rnd1.Next(1, 7);

    if (colorIndex == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(reel);
    }
    if (colorIndex == 1)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(reel);
    }
    if (colorIndex == 2)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(reel);
    }
    Console.ResetColor();
    Console.Write("  ");
    return reel;
}
static void Message(int score)
{
    Console.WriteLine("");
    Console.WriteLine("Congratulations!");
    Console.WriteLine("You win $" + score + ".");
}
static void ApplyTheChoice(string choice, int totalScore)
{
    if ((choice == "Y") || (choice == "y"))
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine(" ");
        RandomReel(totalScore);
    }
    else if ((choice == "N") || (choice == "n"))
    {
        Console.WriteLine(". . . . . . . . . . . . . .");
        Console.WriteLine(" ");
        Console.WriteLine("The game is finished!");
        Console.WriteLine("Total score obtained is $" + totalScore);
    }
    else
        Console.WriteLine("Enter Y or N!");
}