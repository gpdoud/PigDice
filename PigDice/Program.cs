using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDice {
	class Program {
		Random rnd = new Random();

		int RollDice() {
			var roll1 = rnd.Next(6) + 1;
			var roll2 = rnd.Next(6) + 1;
			return roll1 + roll2;
		}
		int RunPigDice() {
			var Total = 0;
			int Die;
			do {
				Die = RollDice();
				if(Die != 1) {
					Total = Total + Die;
				}
			} while (Die != 1);
			Console.WriteLine($"Total this game is {Total}");
			return Total;
		}
		void Run() {
			var BestTotal = 0;
			//for (var idx = 0; idx < 1000000; idx++) {
			var counter = 0;
			while(counter++ < 10) { 
				var ThisGame = RunPigDice();
				//BestTotal = (ThisGame > BestTotal) ? ThisGame : BestTotal;
				if(ThisGame > BestTotal) {
					BestTotal = ThisGame;
				}
			}
			Console.WriteLine($"Best game score is {BestTotal} in only {counter-1} rolls.");
		}
		static void Main(string[] args) {
			new Program().Run();
		}
	}
}
