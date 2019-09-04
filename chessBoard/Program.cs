using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessBoard
{
    class Program
    {

        static int[,] board = new int[8, 8];
        static List<int> attackedRows = new List<int>();
        static List<int> attackedColls = new List<int>();
        static List<int> attackedDiagonalR = new List<int>();
        static List<int> attackedDiagonalL = new List<int>();

        static void Main(string[] args)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = 0;
                }
            }
            PutQueen(0);
        }

        private static void PutQueen(int n)
        {
            if (n == 8)
            {
                PrintBoard();
            }
            else
            {
                for (int col = 0; col < 8; col++)
                {
                    if (CanPutQueen(n, col))
                    {
                        MarkPosition(n, col);
                        PutQueen(n + 1);
                        UnmarkPosition(n, col);
                    }
                }
            }
        }

        private static void UnmarkPosition(int row, int col)
        {
            board[row, col] = 0;
            attackedRows.Remove(row);
            attackedColls.Remove(col);
            attackedDiagonalL.Remove(row + col);
            attackedDiagonalR.Remove(col - row);
        }

        private static bool CanPutQueen(int row, int col)
        {
            if (board[row, col] == 1 ||
               attackedRows.Contains(row) ||
               attackedColls.Contains(col) ||
               attackedDiagonalL.Contains(row + col) ||
               attackedDiagonalR.Contains(col - row))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void MarkPosition(int row, int col)
        {
            board[row, col] = 1;
            attackedRows.Add(row);
            attackedColls.Add(col);
            attackedDiagonalL.Add(row + col);
            attackedDiagonalR.Add(col - row);
        }

        private static void PrintBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
