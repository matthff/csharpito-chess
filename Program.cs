﻿using System;
using Match;
using ChessBoard;
using ChessBoard.Exceptions;
using View;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                ChessMatch gameMatch = new ChessMatch();
                while(!gameMatch.IsMatchOver){
                    try{
                        Console.Clear();
                        ScreenRenderer.RenderBoard(gameMatch.Board);
                        System.Console.WriteLine();
                        System.Console.WriteLine("Turn:" + gameMatch.Turn);
                        System.Console.WriteLine($"Waiting play from: {gameMatch.CurrentColorPlayer}");

                        System.Console.WriteLine();
                        System.Console.Write("Origin: ");
                        Position origin = ScreenInput.ReadBoardPosition().ToNumberFormatPosition();
                        gameMatch.OriginPositionValidation(origin);

                        bool[,] possibleMovesForSelectedPiece = gameMatch.Board.GetPiece(origin).PossibleMoviments();

                        Console.Clear();
                        ScreenRenderer.RenderBoard(gameMatch.Board, possibleMovesForSelectedPiece);

                        System.Console.WriteLine();
                        System.Console.Write("Destination: ");
                        Position destination = ScreenInput.ReadBoardPosition().ToNumberFormatPosition();
                        gameMatch.DestinationPositionValidation(origin, destination);

                        gameMatch.StartTurn(origin, destination);
                    }
                    catch (BoardException e){
                        System.Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch(BoardException e){
                System.Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
