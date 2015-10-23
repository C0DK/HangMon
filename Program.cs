using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HangMon
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Game game = new Game();
				//initialize
				game.ShowUI();

				GameState state = GameState.InProcess;
				while (state == GameState.InProcess)
				{
					state = game.Update(Console.ReadLine());
				}

				if (state == GameState.Won)
					Console.WriteLine("YOU WON!");
				else
				{
					Console.WriteLine("YOU LOST! The word was '"+game.word+"'");
				}

				if (!WantToPlayAgain())
					break;


			}

		}

		static bool WantToPlayAgain()
		{
			Console.WriteLine("Want to play again? [y]");
			return Console.ReadLine().ToLower()[0] == 'y';
		}
	}
}
