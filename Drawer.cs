using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMon
{
	static class Drawer
	{
		public static string DrawHangman(int point = 0)
		{
			string ret = "";
			switch (point)
			{
				case 0:
					ret = @"
					+---+     @
					|         @
					|         @
					|         @
					|         @
					+---------@";
					break;

				case 1:
					ret = @" 
					+---+     @
					|   |     @
					|         @
					|         @
					|         @
					+---------@";
					break;

				case 2:
					ret = @"
					+---+     @
					|   |     @  
					|   O     @
					|         @
					|         @
					+---------@";
					break;

				case 3:
					ret = @"
					+---+     @
					|   |     @
					|   O     @
					|   |     @
					|         @
					+---------@";
					break;

				case 4:
					ret = @"
					+---+     @
					|   |     @
					|   O     @
					|  /|\    @
					|         @
					+---------@";
					break;


				case 5:
					ret = @"
					+---+     @
					|   |     @
					|   O     @
					|  /|\    @ 
					|  /      @
					+---------@";
					break;

				case 6:
					ret = @" 
					+---+     @
					|   |     @
					|   O     @
					|  /|\    @ 
					|  / \    @
					+---------@";
					break;

			}

			return ret.Replace("\t\t\t\t\t", "").Replace("@", "");
		}
	}
}
