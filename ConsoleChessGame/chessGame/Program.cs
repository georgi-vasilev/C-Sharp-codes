using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessGame
{
    class Program
    {
        static void Main(string[] args)
        {
			//There is no point of initializating 'n'.
			//There isn't matrix a.k.a multidimensional array - in this case two-dimensionanal array;
			//So that means infinitive chess board;
			int n = int.Parse(Console.ReadLine());
			//pawn coordinates;
			Console.WriteLine("Enter the pawn coordinates - x by y");
			int pawn_x = int.Parse(Console.ReadLine());
			int pawn_y = int.Parse(Console.ReadLine());
			//initializating chess piece type
			Console.Write("Enter the chess piece type = ");
			var chessPiece = Console.ReadLine();
			//choosen piece coordinates;
			Console.WriteLine("Enter the {0} coordinates - x by y", chessPiece);
			int randomPiece_x = int.Parse(Console.ReadLine());
			int randomPiece_y = int.Parse(Console.ReadLine());
			//recognizing the chess piece type
			if (chessPiece == "Queen") 
			{

			};
			if (chessPiece == "Knight")
			{
				if (randomPiece_x == (pawn_x - 2) && randomPiece_y == (pawn_y - 1))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else if (randomPiece_x == (pawn_x - 2) && randomPiece_y == (pawn_y + 1))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else if (randomPiece_x == (pawn_x + 2) && randomPiece_y == (pawn_y - 1))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else if (randomPiece_x == (pawn_x + 2) && randomPiece_y == (pawn_y + 1))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else if (randomPiece_x == (pawn_x + 1) && randomPiece_y == (pawn_y + 2))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else if (randomPiece_x == (pawn_x - 1) && randomPiece_y == (pawn_y + 2))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else if (randomPiece_x == (pawn_x + 1) && randomPiece_y == (pawn_y - 2))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else if (randomPiece_x == (pawn_x - 1) && randomPiece_y == (pawn_y - 2))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else Console.WriteLine("There isn't pawn in this area");
			}
			if (chessPiece == "King") 
			{
				if (randomPiece_x == (pawn_x - 1) && randomPiece_y == (pawn_y))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else if (randomPiece_x == (pawn_x) && randomPiece_y == (pawn_y - 1))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else if (randomPiece_x == (pawn_x + 1) && randomPiece_y == (pawn_y))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else if (randomPiece_x == (pawn_x) && randomPiece_y == (pawn_y + 1))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else if (randomPiece_x == (pawn_x + 1) && randomPiece_y == (pawn_y + 1))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else if (randomPiece_x == (pawn_x - 1) && randomPiece_y == (pawn_y - 1))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else if (randomPiece_x == (pawn_x + 1) && randomPiece_y == (pawn_y - 1))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else if (randomPiece_x == (pawn_x - 1) && randomPiece_y == (pawn_y + 1))
				{
					Console.WriteLine("The pawn is eaten by the {0}", chessPiece);
				}
				else Console.WriteLine("There isn't pawn in this area");
			}
			if (chessPiece == "Rook" || chessPiece == "Castle")
			{

			}
		}
	}
}

