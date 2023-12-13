using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    
     public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private string[,] board = new string[3, 3]; 

        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10, 6);
            _boardRenderer.Render();
            CheckBoard();
        }

        private void CheckBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = " ";
                }
            }
        }

        public void Run()
        {
            bool gameComplete = false;

            while (!gameComplete)
            {
                Console.Clear();
                _boardRenderer.Render();

                Console.SetCursorPosition(2, 19);
                Console.Write("Player X");

                Console.SetCursorPosition(2, 20);
                Console.Write("Please Enter Row: ");
                int row = int.Parse(Console.ReadLine());

                Console.SetCursorPosition(2, 22);
                Console.Write("Please Enter Column: ");
                int column = int.Parse(Console.ReadLine());

                if (IsValidMove(row, column))
                {
                    board[row, column] = "X";
                    _boardRenderer.AddMove(row, column, PlayerEnum.X, true);
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                    Console.ReadLine();
                    continue;
                }

                if (CheckWin("X"))
                {
                    Console.WriteLine("Player X wins!");
                    gameComplete = true;
                    break;
                }

                Console.Clear();
                _boardRenderer.Render();

                Console.SetCursorPosition(2, 19);
                Console.Write("Player O");

                Console.SetCursorPosition(2, 20);
                Console.Write("Please Enter Row: ");
                row = int.Parse(Console.ReadLine());

                Console.SetCursorPosition(2, 22);
                Console.Write("Please Enter Column: ");
                column = int.Parse(Console.ReadLine());

                if (IsValidMove(row, column))
                {
                    board[row, column] = "O";
                    _boardRenderer.AddMove(row, column, PlayerEnum.O, true);
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                    Console.ReadLine();
                    continue;
                }

                if (CheckWin("O"))
                {
                    Console.WriteLine("Player O wins!");
                    gameComplete = true;
                }
            }
        }

        private bool IsValidMove(int row, int column)
        {
            return board[row, column] == " ";
        }

        private bool CheckWin(string player)
        {
            
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                    return true;
            }

            
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == player && board[1, i] == player && board[2, i] == player)
                    return true;
            }

            
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
                return true;
            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
                return true;

            return false;
        }


    }
}