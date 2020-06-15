/*
TIC TAC TOE MADE BY kevz#2073 
MADE WITH C# WITH AI [NO MINIMAX ALGORITHM]
This AI may be unbeatable

This code is a little bit mess up, since im only a beginner. :)
Thanks to :
- Abood#1337 (helping me alot in C# before)
- loanselot#1337 (idk)

*/

using System;

namespace TicTacToe
{
	class Program
	{
		private static readonly string[] mainBoard = new string[9];
		private static int Round { get; set; }
		static void Main()
		{
			Round = 0;

			CreateBoard();

			Turn t = Turn.you;

			PrintBoard(mainBoard);

			while (!IsFull(mainBoard)
				   && !CheckWinner(mainBoard,"X")
				   && !CheckWinner(mainBoard, "O"))
			{
				if (t == Turn.you)
				{
					YourMove(mainBoard);
					t = Turn.computer;
					Round++;
					PrintBoard(mainBoard);
				}
				else
				{
					Algorithm();
					t = Turn.you;
					Round++;
					PrintBoard(mainBoard);
				}
			}

			if (IsFull(mainBoard))
			{
				Console.WriteLine("\nTIE! Total round : " + Round);
			}
			else
			{
				if (CheckWinner(mainBoard, "X"))
				{
					Console.WriteLine("\nYOU WIN!! Total round : " + Round);
				}
				else
				{
					Console.WriteLine("\nYOU LOSE!! Total round : " + Round);
				}
			}
			Console.Write("Play again or not? (y\\n) ");
			string s = Console.ReadLine();

			if (s.ToLower() == "y")
			{
				Console.WriteLine("\n");
				Main();
			}
			else Environment.Exit(1);
		}

		public static bool CheckWinner(string[] board, string s)
		{
			return (board[0] == s && board[0] == board[1] && board[1] == board[2]) ||
				   (board[3] == s && board[3] == board[4] && board[4] == board[5]) ||
				   (board[6] == s && board[6] == board[7] && board[7] == board[8]) ||
				   (board[0] == s && board[0] == board[3] && board[3] == board[6]) ||
				   (board[1] == s && board[1] == board[4] && board[4] == board[7]) ||
				   (board[2] == s && board[2] == board[5] && board[5] == board[8]) ||
				   (board[0] == s && board[0] == board[4] && board[4] == board[8]) ||
				   (board[2] == s && board[2] == board[4] && board[4] == board[6]);
		}

		enum Turn
		{
			you,
			computer
		}

		static void Algorithm()
		{
			string[] copiedBoard = (string[]) mainBoard.Clone();
			bool enemyComplete = false;
			int[] hilol = { 0, 2, 6, 8 };

			if (copiedBoard[4] != " " && Round == 1) 
			{
				int a = hilol[new Random().Next(0, 4)];
				mainBoard[a] = "O";
				Console.WriteLine("Enemy placed an 'O' in " + a + "!");
				return;
			}

			for(int i = 0; i < 9; i++)
			{
				if (copiedBoard[i] == " ")
				{
					copiedBoard[i] = "O";
					if (CheckWinner(copiedBoard, "O"))
					{
						mainBoard[i] = "O";
						Console.WriteLine("\nEnemy placed an 'O' in " + (i + 1) + "\n");
						return;
					}
					else
					{
						copiedBoard[i] = " ";
					}
				}
			}

			for (int i = 0; i < 9; i++)
			{
				if (copiedBoard[i] == " ")
				{
					copiedBoard[i] = "X";
					if (CheckWinner(copiedBoard, "X"))
					{
						mainBoard[i] = "O";
						Console.WriteLine("\nEnemy placed an 'O' in " + (i + 1) + "\n");
						return;
					}
					else
					{
						copiedBoard[i] = " ";
					}
				}
			}
			if (!enemyComplete)
			{
				bool lol = false;
				for (int i = 0; i < 9; i++)
				{
					if (copiedBoard[i] == " ")
					{
						copiedBoard[i] = "O";
						if (CheckWinner(copiedBoard, "O"))
						{
							mainBoard[i] = "O";
							Console.WriteLine("\nEnemy placed an 'O' in " + (i + 1) + "\n");
							return;
						}
						else
						{
							for(int j = 0; j < 9; j++)
							{
								if(copiedBoard[j] == " " && i != j)
								{
									copiedBoard[j] = "O";
									if (CheckWinner(copiedBoard, "O"))
									{
										mainBoard[i] = "O";
										Console.WriteLine("\nEnemy placed an 'O' in " + (i + 1) + "\n");
										return;
									}
									else
									{
										copiedBoard[j] = " ";
									}
								}
							}
						}
					}
				}

				if (!lol)
				{
					while (true)
					{
						Random r = new Random();
						int a = r.Next(0, 9);
						if (mainBoard[a] == " ")
						{
							mainBoard[a] = "O";
							Console.WriteLine("\nEnemy placed an 'O' in " + (a + 1) + "\n");
							return;
						}
					}
				}
			}
		}

		static bool IsFull(string[] board)
		{
			int c = 0;
			foreach(string s in board)
			{
				if (s == " ") c++;
			}
			return c == 0;
		}
		static void YourMove(string[] board)
		{
			while (true)
			{
				Console.WriteLine("\nWhere do you want to place a \'X\' ? (1 - 9)");
				Console.Write("Input : ");
				try
				{
					int a = Convert.ToInt32(Console.ReadLine());
					if (a > 0 && a < 10)
					{
						if (board[a - 1] == " ")
						{
							mainBoard[a-1] = "X";
							break;
						}
						else
						{
							Console.WriteLine("That position is already" +
								" occupied!");
						}
					}
					else
					{
						Console.WriteLine("Put only numbers between " +
							"1 to 9 !");
					}
				}
				catch
				{
					Console.WriteLine("You didn't put number!");
				}
			}
		}

		static void CreateBoard()
		{
			for(int i = 0; i < 9; i++)
			{
				mainBoard[i] = " ";
			}
		}

		static void PrintBoard(string[] board)
		{
			string result = " ";
			for(int i = 0; i < 9; i++)
			{					
				if (i == 2)
				{
					result += board[i] + "\n-----------\n ";
				}
				else if (i == 5)
				{
					result += board[i] + "\n-----------\n ";
				}
				else if ( i == 8)
				{
					result += board[i];
				}
				else
					result += board[i] + " | ";
			}
			result += "\n";
			Console.Write(result);
		}
	}
}