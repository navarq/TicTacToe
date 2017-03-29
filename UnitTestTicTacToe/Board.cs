using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestTicTacToe
{
    public class Board
    {
        public State[] BoardPositions = new State[9];
        private int[] Positions = new int[9];
        // 1 indicates first move 9 indicates last
        public int Turn = 1;

        // List of X moves taken
        public List<int> X = new List<int>();

        // List of O moves taken
        public List<int> O = new List<int>();

        // Board
        // -------
        // |8|3|4|
        // -------
        // |1|5|9|
        // -------
        // |6|7|2|
        // -------
        public Board()
        {
            Positions[0] = 8;
            Positions[1] = 3;
            Positions[2] = 4;

            Positions[3] = 1;
            Positions[4] = 5;
            Positions[5] = 9;

            Positions[6] = 6;
            Positions[7] = 7;
            Positions[8] = 2;

            for(int i = 0; i<9;i++)
            {
                BoardPositions[i] = State.Empty; 
            }
        }

        public void Go(int move)
        {
            if(BoardPositions[move]!= State.Empty)
            {
                throw new System.Exception("Board not empty at position");
            }
            // if even O's turn if odd X's turn
            if (Turn % 2 == 0)
            {
                BoardPositions[move] = State.O;
                O.Add(Positions[move]);
            }
            else
            {
                BoardPositions[move] = State.X;
                X.Add(Positions[move]);
            }

            Turn++;
        }

        public int PossibleWin(State player)
        {
            // checked if more than 2 moves made
            if(player == State.O)
            { 
                if(O.Count >= 2)
                {
                    for(int i=0;i<O.Count;i++)
                    {
                        for(int j=0;j<O.Count;j++)
                        {
                            if(i!=j)
                            { 
                                int difference = 15 - (O[i] + O[j]);
                                if(difference<0 || difference > 9)
                                {
                                    // ignore
                                }
                                else
                                {
                                    return Array.IndexOf(Positions,difference);
                                }
                            }
                        }
                    }
                }
            }
            else if(player == State.X)
            { 
                if (X.Count >= 2 )
                {
                    for (int i = 0; i < X.Count; i++)
                    {
                        for (int j = 0; j < X.Count; j++)
                        {
                            if (i != j)
                            { 
                                int difference = 15 - (X[i] + X[j]);
                                if (difference < 0 || difference > 9)
                                {
                                    // ignore
                                }
                                else
                                {
                                    return Array.IndexOf(Positions, difference);
                                }
                            }
                        }
                    }
                }
            }
            return -1;
        }
    }
}