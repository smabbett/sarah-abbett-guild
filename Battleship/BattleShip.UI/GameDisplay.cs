using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class GameDisplay
    {
        public void DisplayStartMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(":::::::::      ::: ::::::::::: ::::::::::: :::        :::::::::: ::::::::  :::    ::: ::::::::::: :::::::::");
            Console.WriteLine(":+:    :+:   :+: :+:   :+:         :+:     :+:        :+:       :+:    :+: :+:    :+:     :+:     :+:    :+:");
            Console.WriteLine("+:+    +:+  +:+   +:+  +:+         +:+     +:+        +:+       +:+        +:+    +:+     +:+     +:+    +:+");
            Console.WriteLine("+#++:++#+  +#++:++#++: +#+         +#+     +#+        +#++:++#  +#++:++#++ +#++:++#++     +#+     +#++:++#+ ");
            Console.WriteLine("+#+    +#+ +#+     +#+ +#+         +#+     +#+        +#+              +#+ +#+    +#+     +#+     +#+       ");
            Console.WriteLine("#+#    #+# #+#     #+# #+#         #+#     #+#        #+#       #+#    #+# #+#    #+#     #+#     #+#       ");
            Console.WriteLine("#########  ###     ### ###         ###     ########## ########## ########  ###    ### ########### ###       ");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("Press any key to start the game");
            Console.ReadKey();
            Console.Clear();

        }

        public void DisplayBoard(Board board, string playername)
        {
            Console.WriteLine($"                    {playername.ToUpper()}'S BOARD            ");
            Console.WriteLine();
            Console.WriteLine("     | A | B | C | D | E | F | G | H | I | J ");

            for (int row = 1; row <= 10; row++)
            {
                Console.Write($"| {row}".PadRight(5));

                for (int col = 1; col <= 10; col++)
                {
                    Coordinate coord = new Coordinate(col, row);

                    if (board.ShotHistory.ContainsKey(coord))
                    {
                        ShotHistory result = board.ShotHistory[coord];


                        switch (result)
                        {
                            case ShotHistory.Miss:
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(" M ");
                                Console.ResetColor();
                                break;
                            case ShotHistory.Hit:
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" H ");
                                Console.ResetColor();
                                break;
                        }
                    }
                    else
                    {
                        Console.Write("|   ");
                    }
                }
                Console.WriteLine();             
            }
        }
    }
}
