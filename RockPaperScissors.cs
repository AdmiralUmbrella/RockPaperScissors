//ABDIEL WONG AVILA

/*****************************************************************************\
|*                                                                            *|
\*****************************************************************************/
using System;

public class RockPaperScissors
{
    /**************************************************************************\
    |* Game Constants                                                          *|
    \**************************************************************************/

    const string ROCK = "rock";
    const string PAPER = "paper";
    const string SCISSORS = "scissors";

    /**************************************************************************\
    |* Game State                                                              *|
    \**************************************************************************/

    int pWin;
    int cWin;
    string pMove;
    string cMove;
    int round = 1;

    /**************************************************************************\
    |*                                                                         *|
    \**************************************************************************/
    public static void Main(string[] arg)
    {
        RockPaperScissors ag = new RockPaperScissors();
        ag.Start();
    }
    /**************************************************************************\
    |*                                                                         *|
    \**************************************************************************/
    public RockPaperScissors()
    {
    }
    /**************************************************************************\
    |*                                                                         *|
    \**************************************************************************/
    public void Start()
    {
        string input;
        ShowGameStartScreen(); // 2. Show Game Start Screen
        do
        {
            ShowBoard(); // 3. Show Board / Scene / Map
            do
            {
                ShowInputOptions(); // 4. Show Input Options
                input = GetInput(); // 5. Get Input
            }
            while (!IsValidInput(input)); // 6. Validate Input
            ProcessInput(input); // 7. Process Input
            UpdateGameState(); // 8. Update Game State
        }
        while (!IsGameOver()); // 9. Check for Termination Conditions
        ShowGameOverScreen(); // 10. Show Game Results
    }
    /**************************************************************************\
    |*                                                                         *|
    \**************************************************************************/
    public void ShowGameStartScreen()
    {
        Console.WriteLine("Welcome to Rock-Paper-Scissors!\n");
    }
    /**************************************************************************\
    |*                                                                         *|
    \**************************************************************************/
    public void ShowBoard()
    {
        Console.WriteLine($"----------------------------------\nRound {round}\nRock... Paper... Scissors!\nPlayer: {pWin}       Computer: {cWin}\n");
    }
    /**************************************************************************\
    |*                                                                         *|
    \**************************************************************************/
    public void ShowInputOptions()
    {
        Console.Write($"Input {ROCK} or {PAPER} or {SCISSORS}: ");
    }
    /**************************************************************************\
    |*                                                                         *|
    \**************************************************************************/
    public string GetInput()
    {
        try
        {
            string input = Console.ReadLine().Trim().ToLower();
            return input;
        }
        catch (Exception e)
        {
            return "An error ocurred";
        }
    }
    /**************************************************************************\
    |*                                                                         *|
    \**************************************************************************/
    public bool IsValidInput(string input)
    {
        if (input == ROCK || input == PAPER || input == SCISSORS)
        {
            return true;
        }
        else
        {
            Console.WriteLine("\nInvalid input\n");
            return false;
        }
    }
    /**************************************************************************\
    |*                                                                         *|
    \**************************************************************************/
    public void ProcessInput(string input)
    {
        pMove = input;
        Console.WriteLine($"\nYou choose {input}.");
    }
    /**************************************************************************\
    |*                                                                         *|
    \**************************************************************************/
    public void UpdateGameState()
    {
        string[] moves = new string[] { "rock", "paper", "scissors" };
        Random rng = new Random();
        cMove = moves[rng.Next(moves.Length)];
        Console.WriteLine($"\nComputer choose {cMove}.\n");
        round++;
    }
    /**************************************************************************\
    |*                                                                         *|
    \**************************************************************************/
    public bool IsGameOver()
    {
        CheckWin();
        if ((pMove != cMove))
        {
            if (pWin == 2 || cWin == 2)
            {
                return true;
            }
            else
                return false;
        }
        else //In case the player and computer make the same move.
        {
            Console.WriteLine("You both choose the same move.\nAGAIN!");
            round--; //Subtracts the round so that when the ShowGameStartScreen is displayed it shows the correct round.
            return false;
        }
    }
    /**************************************************************************\
    |*                                                                         *|
    \**************************************************************************/
    public bool CheckWin()
    {
        if ((pMove == ROCK && cMove == SCISSORS) || (pMove == PAPER && cMove == ROCK) || (pMove == SCISSORS && cMove == PAPER)) //Displays and checks if the player won the round.
        {
            pWin++;
            Console.WriteLine("Round won!\n");
            return true;
        }
        else if ((cMove == ROCK && pMove == SCISSORS) || (cMove == PAPER && pMove == ROCK) || (cMove == SCISSORS && pMove == PAPER)) //Displays and checks if the computer won the round.
        {
            cWin++;
            Console.WriteLine("Round loss!\n");
            return false;
        }
        else
        {
            Console.WriteLine("Round tied!\n"); //Displays and checks if the round was tied.
            return false;
        }
    }
    /**************************************************************************\
    |*                                                                         *|
    \**************************************************************************/
    public void ShowGameOverScreen()
    {

        if (pWin == 2) //Best of 3 wins the match.
        {
            Console.WriteLine("Congrats! You Won!");
        }
        else
        {
            Console.WriteLine("Too bad! You Lost!");
        }
    }
}