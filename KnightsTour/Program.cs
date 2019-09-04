using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessBoard
{
    class Program
    {

        private static int n = 5;
        private static int counter = 0;
        private static int solution = 0;
        static int[,] board = new int[n, n];



        static void Main(string[] args)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = 0;
                }
            }
            PutKnight(0, 0);
        }

        private static void PutKnight(int row, int col)
        {
            if (CanPutKnight(row, col) == true)
            {
                MarkPosition(row, col);
                if (counter == n * n)
                {
                    PrintBoard();
                }
                else
                {
                    PutKnight(row - 2, col - 1);
                    PutKnight(row - 2, col + 1);
                    PutKnight(row + 2, col - 1);
                    PutKnight(row + 2, col + 1);

                    PutKnight(row + 1, col - 2);
                    PutKnight(row + 1, col + 2);
                    PutKnight(row - 1, col + 2);
                    PutKnight(row - 1, col - 2);


                }
                UnmarkPosition(row, col);
            }
        }

        private static void UnmarkPosition(int row, int col)
        {
            board[row, col] = 0;
            counter--;

        }

        private static bool CanPutKnight(int row, int col)
        {
            if (row < 0 || row >= n)
            {
                return false;
            }
            if (col < 0 || col >= n)
            {
                return false;
            }
            if (board[row, col] != 0)
            {
                return false;
            }
            return true;
        }

        private static void MarkPosition(int row, int col)
        {
            counter++;
            board[row, col] = counter;
        }

        private static void PrintBoard()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
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
