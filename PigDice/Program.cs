using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GregoryDoud.Games {

	/// <summary>
	/// PigDice is a game where a single die is rolled continually until a one is rolled.
	/// If any other number than one is rolled, that number is accumulated towards the total.
	/// </summary>
	class PigDiceGame {
		/// <summary>
		/// The Random class is used to create a random number to simulate rolling the die
		/// </summary>
		Random rnd = new Random(); // create an instance of Random
		/// <summary>
		/// The RollDice method simulates rolling a single die (singular of Dice)
		/// </summary>
		/// <returns>1 to 6 inclusive</returns>
		int RollDice() {
			// rnd.Next(6) returns an integer between 0 and 5
			// adding one to that integer provides a number between
			// one and six inclusive which simulates rolling one die.
			return rnd.Next(6) + 1;
		}
		/// <summary>
		/// The RunPigDiceGame method playes the PigDice game one time.
		/// </summary>
		/// <returns>The total from the game and the number of rolls done in that game.</returns>
		(int, int) RunPigDiceGame() {
			var Total = 0;						// accumulates the total for the game
			var Rolls = 0;						// accumulates the number of rolls
			int Die;							// the number rolled on the die
			do {
				Rolls++;						// increment the number of rolls
				Die = RollDice();				// roll the die
				if(Die != 1) {					// if the roll is not one
					Total = Total + Die;		// accumulate the roll into the total
				}
			} while (Die != 1);					// continue if the roll is not one
			Console.WriteLine($"Total this game is {Total} in {Rolls} rolls.");
			return (Total, Rolls);				// returns both the total and the number of rolls
		}
		/// <summary>
		/// The Run method plays the RunPigDiceGame multiple times
		/// and displays the highest score and the number of rolls
		/// to create that high score.
		/// </summary>
		void Run() {
			var BestTotal = 0;					// holds the highest total of all games
			var BestRolls = 0;					// holds the number of rolls for the highest game
			var counter = 0;                    // how many times to play the game
			var GamesToPlay = 1000;				// number of games to play
			while(counter++ < GamesToPlay) {	// continue playing until we played all of them
				var (Total, Rolls) = RunPigDiceGame();	// play the game and return the total and number of rolls
				if(Total > BestTotal) {			// if the current total is better than the previous best total
					BestTotal = Total;			// save the new total
					BestRolls = Rolls;			// and the number of rolls it took
				}
			}
			Console.WriteLine($"Best game score is {BestTotal} in only {BestRolls} rolls.");
		}

		static void Main(string[] args) {
			new PigDiceGame().Run();
			Console.WriteLine("Press any key to quit ...");
			Console.ReadKey();
		}
	}
}
