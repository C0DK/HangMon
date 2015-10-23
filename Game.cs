using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMon
{
	/// <summary>
	/// Object that holds the information about an active game
	/// </summary>
	class Game
	{
		public Game()
		{
			word = WordController.GetRandWord();
			correctChars = new bool[word.Length];
			wrongChars = new List<char>();
			fails = 0;
		}

		public string word { get; private set; }
		private bool[] correctChars { get; set; }
		private List<char> wrongChars { get; set; }
		private int fails { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns>state of the game</returns>
		public GameState Update(string input = "")
		{
			GameState state = GameState.InProcess;

				//word
			if(IsInputWord(input))
			{
				if(input == word)
					state = GameState.Won;
				else
					fails++;
			}
				//Char
			else
			{
				char inputChar = GetCharFromInput(input);
				if (isCharInWord(inputChar))
				{
					int[] positions = GetPositionOfChar(inputChar);
					foreach (int pos in positions)
					{
						correctChars[pos] = true;
					}
				}
				else
				{
					wrongChars.Add(inputChar);
					fails++;
				}
			}

			if (fails >= 6)
				state = GameState.lost;
			if (!correctChars.Any(x => x == false))
				state = GameState.Won;

			ShowUI();

			return state;
		}
		public void ShowUI()
		{
			Console.Clear();
			Console.WriteLine(Drawer.DrawHangman(fails));
			Console.WriteLine("Word = " + GetCorrectLetters());
			Console.WriteLine("Wrong characters = " + GetCombinedChars());
		}

		bool IsInputWord(string input)
		{
			return input.Length != 1;
		}
		char GetCharFromInput(string input)
		{
			return input[0];
		}

		bool isCharInWord(char input)
		{
			return word.Contains(input);
		}

		int[] GetPositionOfChar(char input)
		{
			string localWord = word;
			List<int> ints = new List<int>();
			while(true)
			{
				if(localWord.Contains(input))
				{
					int pos = localWord.IndexOf(input);
					
					localWord = localWord.Substring(pos+1,localWord.Length-pos-1);
					if(ints.Count > 0)
						pos += ints.Last()+1;

					ints.Add(pos);
				}
				else
					break;
			}
			return ints.ToArray();
		}
		string GetCombinedChars()
		{
			if (wrongChars.Count > 0)
			{
				string charListString = "";
				foreach (char c in wrongChars)
				{
					charListString += c + ", ";
				}
				charListString.Remove(charListString.Length - 3);
				return charListString;
			}
			else
				return "";
		}
		string GetCorrectLetters()
		{
			string output = "";
			for (int i = 0; i < word.Length; i++)
			{
				if (correctChars[i])
					output += word[i];
				else
					output += "_";
				output += " ";
			}
			return output;
		}

	}
	
		enum GameState
		{
			Won,
			lost,
			InProcess
		}
}
