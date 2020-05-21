﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoAI : AI
{
    /**
     * board es el tablero. Podemos acceder a una posición concreta mediante board[x][y]
     * Cada posición contiene un valor que nos indica si está ocupada o no, y qué jugador la ha ocupado.
     * Valores posibles:
     *    Piece.Empty ---> Casilla libre
     *    Piece.PlayerOne ---> Casilla con una ficha del Player One
     *    Piece.PlayerTwo ---> Casilla con una ficha del Player Two
    **/

    /**
     *  [Esta función tiene que existir obligatoriamente y tiene que devolver un entero. Modificar solo la funcionalidad.]
     *  Devuelve el índice de la columna en la que caerá la ficha
     *  La columna que está más a la izquierda es la 0, la columna que está más a la derecha es Config.numColumns-1 (==> 6)
     **/
    public override int nextMove()
    {
        int column = ObtainColumnWith3();

        int RandomPosition = Random.Range(0, 6);

        if (column == -1)
        {
            column = ObtainRowWith3();

            if (column == -1)
            {
                column = RandomPosition;
            }
        }
        return column;
    }

    public int ObtainColumnWith3()
    {
        
        for (int column = 0; column < Config.numColumns; column++)
        {
            int numPiecesMineStrike = 0;
            int numPiecesEnemyStrike = 0;

            for (int row = Config.numRows - 1; row >= 0; row--)
            {
                //DEFENSE//

                if (board[column][row] == Piece.PlayerTwo)
                {
                    numPiecesMineStrike++;
                }
                else
                {
                    numPiecesMineStrike = 0;
                }

                if (numPiecesMineStrike >= 3)
                {
                    int rowAbove = row - 1;

                    if (row - 1 >= 0)
                    {

                        Debug.Log(" ");
                        if (board[column][rowAbove] == Piece.Empty)
                        {
                            return column;
                        }
                    }
                    
                }

                    //ATTACK//

                if (board[column][row] == Piece.PlayerOne)
                {
                    numPiecesEnemyStrike++;
                }
                else
                {
                    numPiecesEnemyStrike = 0;
                }

                if (numPiecesEnemyStrike >= 3)
                {
                    int rowAbove = row - 1;

                    if (row - 1 >= 0)
                    {
                        Debug.Log(" ");
                        if (board[column][rowAbove] == Piece.Empty)
                        {
                            return column;
                        }
                    }
                }
            }
        }
        
        return -1;
    }

    //------------------------//

    public int ObtainRowWith3()
    {

        for (int column = 0; column < Config.numColumns; column++)
        {

            //DEFENSE//

            for (int row = Config.numRows - 1; row >= 0; row--)
            {

                if (column + 1 < Config.numColumns)
                {

                    if (board[column][row] == Piece.PlayerTwo)
                    {

                        if (board[column + 1][row] == Piece.PlayerTwo)
                        {

                            if (column + 2 < Config.numColumns)
                            {
                                
                                if (board[column + 2][row] == Piece.PlayerTwo)
                                {

                                    int columnR = column + 3;
                                    int columnL = column - 1;

                                    if (column - 1 >= 0)
                                    {
                                        if (row + 1 <= 5)
                                        {
                                            if (board[column - 1][row + 1] == Piece.Empty)
                                            {

                                            }
                                            else if (board[columnL][row] == Piece.Empty)
                                            {
                                                return column - 1;
                                            }
                                        }
                                        else if (board[columnL][row] == Piece.Empty)
                                        {
                                            return column - 1;
                                        }

                                        if (column + 3 < Config.numColumns)
                                        {
                                            if (row - 1 >= 0)
                                            {
                                                if (board[column + 3][row - 1] == Piece.Empty)
                                                {
                                                
                                                }
                                                else if (board[columnR][row] == Piece.Empty)
                                                {
                                                    return column + 3;
                                                }
                                            }

                                            if (board[columnR][row] == Piece.Empty)
                                            {
                                                return column + 3;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            

                //ATTACK//

                if (column + 1 < Config.numColumns)
                {
                    if (board[column][row] == Piece.PlayerOne)
                    {

                        if (board[column + 1][row] == Piece.PlayerOne)
                        {

                            if (column + 2 < Config.numColumns)
                            {

                                if (board[column + 2][row] == Piece.PlayerOne)
                                {

                                    int columnR = column + 3;
                                    int columnL = column - 1;

                                    

                                    if (column -1 >= 0)
                                    {
                                        if (row + 1 <= 5)
                                        {
                                            if (board[column -1][row + 1] == Piece.Empty)
                                            {

                                            }
                                            else if (board[columnL][row] == Piece.Empty)
                                            {
                                                return column - 1;
                                            }
                                        }
                                        else if (board[columnL][row] == Piece.Empty)
                                        {
                                            return column - 1;
                                        }

                                        
                                    }

                                    if (column + 3 < Config.numColumns)
                                    {
                                        if (row - 1 >= 0)
                                        {
                                            if (board[column + 3][row - 1] == Piece.Empty)
                                            {

                                            }
                                            else if (board[columnR][row] == Piece.Empty)
                                            {
                                                return column + 3;
                                            }
                                        }

                                        if (board[columnR][row] == Piece.Empty)
                                        {
                                            return column + 3;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
            }
        }
    

    return -1;
   
    }



        /**
         *  [Función de ejemplo, se puede borrar]
         *  Devuelve todas las columnas del tablero vacías. Devolverá la misma columna tantas veces como casillas
         *  tenga disponibles. Por lo tanto, si escogemos la columna aleatoriamente, habrá más
         *  posibilidad de seleccionar nuestro próximo movimiento como aquella columna que tenga más casillas vacías.
         **/
        public List<int> GetPossibleMoves()
    {
        List<int> possibleMoves = new List<int>();

        // Recorremos todo el tablero
        for (int column = 0; column < Config.numColumns; column++)
        {
            for (int row = 0; row < Config.numRows; row++)
            {
                // Si la casilla vale Piece.Empty, significa que está libre
                if (board[column][row] == Piece.Empty)
                {
                    // Guardamos la columna
                    possibleMoves.Add(column);
                }
            }
        }

        return possibleMoves;
    }
}
