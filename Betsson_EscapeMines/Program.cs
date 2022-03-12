using Betsson_EscapeMines.Services.Services;
using System;
using System.IO;

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

            try
            {
                //Read EscapeMines.txt file
                string[] Commandlines = File.ReadAllLines("../../../EscapeMines.txt");

                if (Commandlines.Length > 4)
                {
                    var result = new GameOprator(Commandlines);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Commands line length should be greater than or equal to 5 rows.");
                }
                // Get Board Size
                //var boardSizeResponse = BoardSize(lines[0]);

                //if (boardSizeResponse.IsValid)
                //{
                //    // Get Mines List
                //    //MinesPointsModel minesPointsResponse = MinesPoints(boardSizeResponse.BoardSize, lines[1]);

                //    //if (minesPointsResponse.IsValid)
                //    //{
                //    //    //Get exit point
                //    //}
                //}

                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("************************");
                Console.WriteLine(e.Message);
            }
        }

        //private static BoardSizeModel BoardSize(string boardSize)
        //{
        //    IBoardSizeService boardSizeService = new BoardSizeService();

        //    var boardSizeRespone = new BoardSizeModel();

        //    try
        //    {
        //        boardSizeRespone = boardSizeService.CheckBoardSize(boardSize);
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        Console.WriteLine($"Total tiles are {boardSizeRespone.BoardSize.Columns * boardSizeRespone.BoardSize.Rows}");
        //        Console.WriteLine("************************");
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.WriteLine();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine(e.Message);
        //        boardSize = Console.ReadLine();                
        //    }

        //    return boardSizeRespone;
        //}

        //private static MinesPointsModel MinesPoints(BoardSize boardSize, string minesPoints)
        //{
        //    IMinesPointsService minesPointsService = new MinesPointsService();
        //    MinesPointsModel minesPointsRespone = new MinesPointsModel();

        //    try
        //    {
        //        minesPointsRespone = minesPointsService.CheckMinesPoints(minesPoints, boardSize);
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        Console.WriteLine($"You added {minesPointsRespone.minesPoints.Count} mines on the board.");
        //        Console.WriteLine("************************");
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.WriteLine();                
        //    }
        //    catch (Exception e)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine(e.Message);
        //        minesPoints = Console.ReadLine();
        //    }

        //    return minesPointsRespone;
        //}

        //private static ExitPointModel BoardExitPoint(BoardSize boardSize, List<MinesPoints> minesPoints, string ExitPoint)
        //{
        //    IExitPointService exitPointService = new ExitPointService();
        //    ExitPointModel exitPointResponse = new ExitPointModel();
        //    return exitPointResponse;
        //}
    }
}
