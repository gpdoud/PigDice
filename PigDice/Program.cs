using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDice {
	class Program {
		Random rnd = new Random();

		int RollDice() {
			return rnd.Next(6) + 1;
		}
		int RunPigDice() {
			var Total = 0;
			int Die = 0;
			do {
				Die = RollDice();
				if(Die != 1) {
					Total += Die;
				}
			} while (Die != 1);
			//Console.WriteLine($"Total this game is {Total}");
			return Total;
		}
		void Run() {
			var BestTotal = 0;
			//for (var idx = 0; idx < 1000000; idx++) {
			var counter = 0;
			while(counter++ < 100) { 
				var ThisGame = RunPigDice();
				BestTotal = (ThisGame > BestTotal) ? ThisGame : BestTotal;
			}
			Console.WriteLine($"Best game score is {BestTotal} in only {counter-1} rolls.");
		}
		static void Main(string[] args) {
			new Program().Run();
		}
	}
}
