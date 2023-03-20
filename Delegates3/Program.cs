using System;

namespace delegatesAndEvents
{
    public delegate void Notify(int n);  // delegate

    public class Race
    {
        public event Notify ContestEnd; // event

        public void Racing(int contestants, int laps)
        {
            Console.WriteLine("Ready\nSet\nGo!");
            Random r = new Random();
            int[] participants = new int[contestants];
            bool done = false;
            int champ = -1;
            // first to finish 100 wins
            while (!done)
            {
                for (int i = 0; i < contestants; i++)
                {

                    if (participants[i] <= laps)
                    {
                        participants[i] += r.Next(1, 5);
                    }
                    else
                    {
                        champ = i;
                        done = true;
                        continue;
                    }
                }

            }

            TheWinner(champ);
        }
        private void TheWinner(int champ)
        {
            Console.WriteLine("We have a winner!");
            ContestEnd(champ);
        }
    }
    class Program
    {
        public static void Main()
        {
            // create a class object
            Race round1 = new Race();
            // register with an event
            round1.ContestEnd += carRace;
            // trigger the event
            round1.Racing(20, 10);
            // register with a different event
            round1.ContestEnd -= carRace;
            round1.ContestEnd += footRace;
            //trigger the event
            round1.Racing(20, 10);
            // register with a different event using a lambda expression
            round1.ContestEnd -= footRace;
            round1.ContestEnd += (winner) => Console.WriteLine($"The foot race competition winner is {winner}");
            // trigger the event
            round1.Racing(20, 10);
        }

        // event handlers
        public static void carRace(int winner)
        {
            Console.WriteLine($"Car number {winner} is the winner.");
        }
        public static void footRace(int winner)
        {
            Console.WriteLine($"Racer number {winner} is the winner.");
        }
    }
}