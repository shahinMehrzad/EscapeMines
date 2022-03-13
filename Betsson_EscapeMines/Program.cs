using Betsson_EscapeMines.Core.Interfaces;
using Betsson_EscapeMines.Core.Models;
using Betsson_EscapeMines.Services.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Betsson_EscapeMines
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameOprator gameOprator = new GameOprator();
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
                    var result = gameOprator.MatchMovement(Commandlines);
                    MatchReport(result);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Commands line length should be greater than or equal to 5 rows.");
                }
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("************************");
                Console.WriteLine(e.Message);
            }
        }

        private static void MatchReport(List<MatchMovementModel> matchMovements)
        {
            foreach(var item in matchMovements)
            {
                switch (item.Status)
                {
                    case Core.Enums.Status.Success:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(item.Message);
                        Console.WriteLine("****************************************");
                        break;
                    case Core.Enums.Status.MineHit:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(item.Message);
                        Console.WriteLine("****************************************");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(item.Message + $" column : {item.TurtlePoint.X} - row : {item.TurtlePoint.Y}");
                        Console.WriteLine("**************************************** :|");
                        break;
                }
                Thread.Sleep(1000);
            }
        }
    }
}
