﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TickTackToe
{
    public class Game
    {


        public int GirdSize
        {
            get
            { return 3; }
        }

        private GameState gs;
        public GameState StateOfGame
        {
            get
            {
                return gs;
            }
        }

        private BoxState[][] GameGrid;
        public Game()
        {
            GameGrid = new BoxState[GirdSize][];
            for (int i = 0; i < GirdSize; i++)

            {
                GameGrid[i] = new BoxState[GirdSize];
            }
        }
        public BoxState GetBox(int x, int y)
        {
            return GameGrid[x][y];
        }

        private bool isXTurn = true;

        public void MakeMove(int x, int y)
        {
            if (GetBox(x, y) != BoxState.Clear) throw new InvalidOperationException("Cannot mark a non-empty location");
            if (isXTurn)
            {
                GameGrid[x][y] = BoxState.X;
            }
            else
            {
                GameGrid[x][y] = BoxState.O;
            }
            isXTurn = !isXTurn;
            CheckGameState();
        }

        private void CheckGameState()
        {

            bool xwin = false;
            bool owin = false;
            // Check vert
            if (GameGrid.Any(p => p.All(q => q == BoxState.X))) xwin = true;
            if (GameGrid.Any(p => p.All(q => q == BoxState.O))) owin  = true;
            // Check horz
            if (Enumerable.Range(0, GirdSize).Any(p => GameGrid.All(q => q[p] == BoxState.X))) xwin = true;
            if (Enumerable.Range(0, GirdSize).Any(p => GameGrid.All(q => q[p] == BoxState.O))) owin = true;
            
            // Check diag
            if (Enumerable.Range(0, GirdSize).All(p => GameGrid[p][p] == BoxState.X)) xwin = true;
            if (Enumerable.Range(0, GirdSize).All(p => GameGrid[p][p] == BoxState.O)) xwin = true;
            if (Enumerable.Range(0, GirdSize).All(p => GameGrid[p][GirdSize - p - 1] == BoxState.X)) xwin = true;
            if (Enumerable.Range(0, GirdSize).All(p => GameGrid[p][GirdSize-p-1] == BoxState.O)) xwin = true;


            if (xwin) gs = GameState.XWins;
            if (owin) gs = GameState.OWins;
            if (!xwin && !owin)
            {
                if (GameGrid.All(p => p.All(q => q != BoxState.Clear))) gs = GameState.Tie;
            }
            
        }

        public string ShowGameState()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < GirdSize; y++)
            {
                for (int x = 0; x < GirdSize; x++)
                {
                    if (GetBox(x, y) == BoxState.X) sb.Append("X");
                    if (GetBox(x, y) == BoxState.O) sb.Append("O");
                    if (GetBox(x, y) == BoxState.Clear) sb.Append(" ");
                    sb.Append("|");
                }
                sb.AppendLine();
                sb.Append('-', GirdSize * 2);
                sb.AppendLine();
            }
            return sb.ToString();
        }

    }

    public class GameControl
    {
        Game g;
        bool hasMoved = false;
        public GameControl(Game game)
        {
            g = game;
        }

        public int Size
        {
            get
            {
                return g.GirdSize;
            }
        }

        public void MakeMove(int x, int y)
        {
            if (!hasMoved)
            {
                g.MakeMove(x, y);
                hasMoved = true;
            }
            else
            {
                throw new InvalidCastException("Cannot move more then once per turn");
            }
        }

        public BoxState GetBox(int x, int y)
        {
           return g.GetBox(x, y);
        }

    }


    public enum BoxState
    {
        Clear,
        X,
        O
    }

    public enum GameState
    {
        Running,
        Tie,
        XWins,
        OWins
    }
}
