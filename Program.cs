using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CA3_2022_Demo
{
    class Program
    {
        static Player[] myPlayers = new Player[5];
        static void Main(string[] args)
        {
            // create 5 players
            string[] randomNames = { "pat", "ann", "frank", "mary", "john" };
            for (int i = 0; i < 5; i++) // create 5 players
            {
                //Console.WriteLine("Enter player name :");
                myPlayers[i] = new Player();
                myPlayers[i].Name = randomNames[i]; //Console.ReadLine();
            }
            
            Console.WriteLine("Menu");
            Console.WriteLine("1. Enter results ");
            Console.WriteLine("2. View player details");
            Console.WriteLine("3. Play a game");
            Console.WriteLine("4. Exit");
            int choice;
            Console.Write("Enter choice :");
            choice = int.Parse(Console.ReadLine());

            while (choice != 4)
            {
                if (choice == 1)
                    AddScores();
                else if (choice == 2)
                    PrintPlayerInfo();
                else if (choice == 3)
                    PlayGame();
                else
                    Console.WriteLine("invalid choice for now");

                Console.WriteLine("Menu");
                Console.WriteLine("1. Enter results ");
                Console.WriteLine("2. View player details");
                Console.WriteLine("3. Play a game");
                Console.WriteLine("4. Exit");
                Console.WriteLine("5. Save to file");

                Console.Write("Enter choice :");
                choice = int.Parse(Console.ReadLine());
            }

        }

        static void saveTofile()
        {
            FileStream fs = new FileStream("players.txt", FileMode.Open, FileAccess.Write);
            
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < 5; i++)
            {
                sw.WriteLine("{0},{1},{2}", myPlayers[i].Name, myPlayers[i].PlayerNumber, myPlayers[i].GamesPlayed);
            }

            
        }

        static void PlayGame()
        {
            bool match = false;
            int count = 0;

            Random myRandom = new Random();
            int num = myRandom.Next(1, 20);
            Console.WriteLine("number = {0}",num);

            while (match == false)
            {
                count++;
                Console.WriteLine("Guess a number between 1 - 20");

                int myGuess = int.Parse(Console.ReadLine());
                if (myGuess == num)
                    Console.WriteLine("you win");
                else if (myGuess < num)
                    Console.WriteLine("too low");
                else
                    Console.WriteLine("too high");
            }
            Console.WriteLine("you took {0} turns",count);
        }
        static void PrintPlayerInfo()
        {
            Console.WriteLine("player info ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(myPlayers[i].ToString());
                Console.WriteLine(myPlayers[i].avg());
                Console.WriteLine(myPlayers[i].PercentageWin());

            }
        }
        static void AddScores()
        {
            string doAgain = "yes";

            while (doAgain == "yes")
            {
                Console.Write("Enter player number : ");
                int n = int.Parse(Console.ReadLine());

                if (myPlayers[n-1].GamesPlayed <=10) // check before we set value
                
                {
                    
                    Console.WriteLine("How many turns did you take");
                    int t = int.Parse(Console.ReadLine());
                    myPlayers[n - 1].AddTurnsTaken(t);
                }
                else
                {
                    Console.WriteLine("league over");
                }

                Console.WriteLine("Enter another score (yes/no) : ");
                doAgain = (Console.ReadLine());

            }

        }
    }
}
