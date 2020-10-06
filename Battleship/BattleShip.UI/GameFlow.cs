
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.UI;

namespace BattleShip.UI
{
    public class GameFlow
    {
        private string _player1Name;
        private string _player2Name;
        private GameDisplay _display;
        private UserInput _input;
        private Board _player1Board;
        private Board _player2Board;

        private bool _isPlayer1Turn = true;
        private bool _gameWon = false;
        private bool _gameAbandoned = false;
        private Coordinate c;
        
        public void Run()
        {
            _display = new GameDisplay();
            _display.DisplayStartMenu();

            _input = new UserInput();
            _player1Name = _input.GetPlayerName("1");
            _player2Name = _input.GetPlayerName("2");

            _player1Board = new Board();
            _player2Board = new Board();
            
            TakeTurns();
                      
        }

        private void TakeTurns()
        {
            while (!_gameAbandoned)
            {

            
            PromptforShipPlacement(_player1Name, _player1Board, ShipType.Destroyer);
            PromptforShipPlacement(_player1Name, _player1Board, ShipType.Submarine);
            PromptforShipPlacement(_player1Name, _player1Board, ShipType.Cruiser);
            PromptforShipPlacement(_player1Name, _player1Board, ShipType.Battleship);
            PromptforShipPlacement(_player1Name, _player1Board, ShipType.Carrier);
            Console.Clear();

            PromptforShipPlacement(_player2Name, _player2Board, ShipType.Destroyer);
            PromptforShipPlacement(_player2Name, _player2Board, ShipType.Submarine);
            PromptforShipPlacement(_player2Name, _player2Board, ShipType.Cruiser);
            PromptforShipPlacement(_player2Name, _player2Board, ShipType.Battleship);
            PromptforShipPlacement(_player2Name, _player2Board, ShipType.Carrier);
            Console.Clear();

                while (!_gameWon)
                {


                    if (_isPlayer1Turn)
                    {
                        _display.DisplayBoard(_player2Board, _player2Name);
                        PromptforShot(_player1Name);

                        FireShotResponse response = _player2Board.FireShot(c);

                        DisplayShotFiredResponse(response);
                        Console.Clear();
                    }

                    else
                    {
                        _display.DisplayBoard(_player1Board, _player1Name);
                        PromptforShot(_player2Name);

                        FireShotResponse response = _player1Board.FireShot(c);

                        DisplayShotFiredResponse(response);
                        Console.Clear();
                    }


                }
            }
               
        }

        private void PromptforShipPlacement(string playername, Board board, ShipType type)
        {
            PlaceShipRequest request = new PlaceShipRequest();

            while (true)
            {

                Console.WriteLine($"{playername}, where would you like to place your {type}?");

                Coordinate coordinate = _input.GetCoordinates(playername);
                ShipDirection direction = _input.GetDirection(playername);

                request.Coordinate = coordinate;
                request.Direction = direction;
                request.ShipType = type;

                ShipPlacement response = board.PlaceShip(request);

                switch (response)
                {
                    case ShipPlacement.Overlap:
                        Console.WriteLine("You cannot place a ship in that position. It overlaps another ship!");
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("You cannot place a ship in that position. It is off the board!");
                        break;
                    case ShipPlacement.Ok:
                        return;

                }
            }

        }



        private Coordinate PromptforShot(string playername)
        {
            Console.WriteLine($"{playername}, it is your turn. Fire a shot!");
            c = _input.GetCoordinates(playername);
            return c;
            

        }


        private void DisplayShotFiredResponse(FireShotResponse response)
        {
            while (true)
            {
                switch (response.ShotStatus)
                {
                    case ShotStatus.Duplicate:
                        Console.WriteLine("You already fired a shot at that coordinate. Press any key to continue.");
                        Console.ReadKey();
                        //repeat turn??
                       
                        return;
                    case ShotStatus.Hit:
                        Console.WriteLine("You hit something! Press any key to continue.");
                        Console.ReadKey();
                        _isPlayer1Turn = !_isPlayer1Turn;
                        return;
                    case ShotStatus.HitAndSunk:
                        Console.WriteLine("You sank your opponent's {0}! Press any key to continue.", response.ShipImpacted);
                        Console.ReadKey();
                        _isPlayer1Turn = !_isPlayer1Turn;
                        return;
                    case ShotStatus.Invalid:
                        Console.WriteLine("That is not a valid coordinate. Try Again. Press any key to continue.");
                        Console.ReadKey();
                        //repeat turn??
                        return;
                    case ShotStatus.Miss:
                        Console.WriteLine("Your projectile splashes into the ocean, you missed! Press any key to continue.");
                        Console.ReadKey();
                        _isPlayer1Turn = !_isPlayer1Turn;
                        return;
                    case ShotStatus.Victory:
                        Console.WriteLine("You have sunk all of your opponent's ships! YOU WIN!");
                        _gameWon = true;
                        Console.WriteLine("Would you like to play again? Press Y or N");
                        string rv = Console.ReadLine();
                        if (rv.ToUpper() == "N")
                        {
                            _gameAbandoned = true;                           
                        }
                        return;
                }

            }
           
            
        }


    }

}


       




    

