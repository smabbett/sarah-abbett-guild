using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class UserInput
    {
     

        public string GetPlayerName(string playerNumber)
        {
            String rv;
            do
            {              
                Console.Write("Player {0}, what is your name? ", playerNumber);
                rv = Console.ReadLine();
                if (rv.Length > 2) break;
                Console.WriteLine("Please enter at least a 2 character name.");
                Console.ReadKey();

            } while (true);
            return rv;
            

        }

        public Coordinate GetCoordinates(string playername)
        {
            int x, y;
            do
            {
                
                Console.WriteLine("{0}, Please enter coordinates A-J, 1-10 example B9)", playername);
                string coordinates = Console.ReadLine();

                string xcoord = coordinates.Substring(0, 1);
                string ycoord = coordinates.Substring(1, coordinates.Length - 1);
               
                x = ConvertLetter(xcoord);
       
               
                            
                if (( int.TryParse(ycoord, out y) && (x > 0)))

                { 
                    return new Coordinate(x, y);
                }
                else
                {
                    Console.WriteLine("That is not a valid coordinate. Please try again!");         
                }
                

            } while (true);

           
            
            
        }

        public ShipDirection GetDirection(string playername)
        {
            string rv;
            do
            {
                Console.WriteLine("{0}, Please enter a direction (Up, Down, Left, Right):", playername);
                rv = Console.ReadLine();
                
                switch (rv.ToUpper())
                {
                    case "UP":
                        return ShipDirection.Up;
                    case "DOWN":
                        return ShipDirection.Down;
                    case "LEFT":
                        return ShipDirection.Left;
                    case "RIGHT":
                        return ShipDirection.Right;
                    default:
                        Console.WriteLine("That was not a valid direction!");
                        break;
                }
                
            } while (true);

        }

        public int ConvertLetter(string x)
        {
            switch (x)
            {
                case "a":
                case "A":
                    return 1;     
                case "b":
                case "B":
                    return 2;
                case "c":
                case "C":
                    return 3;
                case "d":
                case "D":
                    return 4;
                case "e":
                case "E":
                    return 5;
                case "f":
                case "F":
                    return 6;
                case "g":
                case "G":
                    return 7;
                case "h":
                case "H":
                    return 8;
                case "i":
                case "I":
                    return 9;
                case "j":
                case "J":
                    return 10;
                default:
                    return -1;


            }
            
        }


    }
}
