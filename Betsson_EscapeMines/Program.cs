using Betsson_EscapeMines.Helpers;
using Betsson_EscapeMines.Interfaces;
using Betsson_EscapeMines.Models;
using Betsson_EscapeMines.Services;
using System;
using System.Collections.Generic;

namespace Betsson_EscapeMines
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set the Foreground color to yellow
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Welcome to Escape Mines!");
            Console.WriteLine("************************");

            // Get Board Size
            BoardSize boardSize = BoardSize();

            // Get Mines List
            List<MinesPoints> minesPoints = MinesPoints(boardSize);

            Console.ReadLine();
        }

        private static BoardSize BoardSize()
        {
            IBoardSizeService boardSizeService = new BoardSizeService();
            Console.WriteLine("Please enter number of columns and rows(For example : 4 5) :");
            var boardSize = Console.ReadLine();
            var boardSizeRespone = new BoardSizeResponse();
            while (!boardSizeRespone.IsValid)
            {
                try
                {
                    boardSizeRespone = boardSizeService.CheckBoardSize(boardSize);
                }
                catch(Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    boardSize = Console.ReadLine();
                    boardSizeRespone = boardSizeService.CheckBoardSize(boardSize);
                }
            }



            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine($"Your enterd table columns : {boardSizeRespone.boardSize.Columns} and rows : {boardSizeRespone.boardSize.Rows}");
            //Console.WriteLine($"Total tiles are {boardSizeRespone.boardSize.Columns * boardSizeRespone.boardSize.Rows}");
            //Console.WriteLine("************************");
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine();
            //return boardSizeRespone.boardSize;
            return new BoardSize();
        }

        private static List<MinesPoints> MinesPoints(BoardSize boardSize)
        {
            MinesPointsHelper minesPointsHelper = new MinesPointsHelper();
            Console.WriteLine("Please enter list of mines points(For example = 1,1 3,1 3,3) :");
            var minesPoints = Console.ReadLine();
            var minesPointsRespone = minesPointsHelper.CheckMinesPoints(minesPoints, boardSize);
            while (!minesPointsRespone.IsValid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(minesPointsRespone.Message);
                minesPoints = Console.ReadLine();
                minesPointsRespone = minesPointsHelper.CheckMinesPoints(minesPoints, boardSize);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your added : {minesPointsRespone.minesPoints.Count} mines on the board ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            return minesPointsRespone.minesPoints;
        }
    }
}
