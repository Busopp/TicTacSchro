using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model{
	public static int numSpaces = 25;
	/* An array to store board state*/
	private Space.Side[] grid;

	public string playerOne;
	public string playerTwo;
	public Space.Side p1Side;
	public Space.Side p2Side;
	public bool p1sTurn;

	public Model(string p1Name, string p2Name) {
		Reset (p1Name, p2Name);

	}

	public void Reset(string p1Name, string p2Name) {
		playerOne = p1Name;
		playerTwo = p2Name;

		AssignSides ();
		p1sTurn = (RNGsus () == 1) ? true : false;

		grid = new Space.Side[numSpaces];

		for (int i = 0; i < numSpaces; i++) {
			grid[i] = Space.Side.NONE;
		}
	}
		
	public void EndTurn() {
		p1sTurn = !p1sTurn;
	}
		
	public enum TurnResult {
		NORMAL, TIMEOUT, XWON, OWON, ERROR
	}

	private void AssignSides() {
		int result = RNGsus ();
		if (result == 1) {
			p1Side = Space.Side.O;
			p2Side = Space.Side.X;
		} else {
			p1Side = Space.Side.X;
			p2Side = Space.Side.O;
		}
	}
		

	/* Function called when a grid space is selected (with a mouse click) */
	public Space.Side GetSide(int index) {
		switch (grid[index]) {
		case Space.Side.NONE:
			grid[index] = Space.Side.UD;
			return Space.Side.UD;
		case Space.Side.UD:
			int result = RNGsus ();
			if (result == 1) {
                    grid[index] = Space.Side.X;
                    return Space.Side.X;
                } else {
                    grid[index] = Space.Side.O;
                    return Space.Side.O;
                }

		default:
			return Space.Side.INV;
		}
	}

	/* Returns 1 or 0 with a 50% chance*/
	public int RNGsus() {
		return UnityEngine.Random.Range (0, 2);
	}

    public Model.TurnResult checkWin()
    {
        if (checkXWins()) { return Model.TurnResult.XWON; }

        return Model.TurnResult.OWON;
    }

    public bool checkXWins()
    {
        Space.Side Sym = Space.Side.X;
        Space.Side Empty = Space.Side.NONE;
        int j = 0;
        //Check row 1
        for (int i = 0; i < 5; i++)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    j++;
                    Debug.Log(j);
                }
                
            }
        }
        if (j == 5) { return true; }
        //Check row 2
        for (int i = 5; i < 10; i++)
        {
            if (grid[i].Equals(Sym) || grid[i].Equals(Empty))
            {
                return false;
            }
        }
        //Check row 3
        for (int i = 10; i < 15; i++)
        {
            if (grid[i].Equals(Sym) || grid[i].Equals(Empty))
            {
                return false;
            }
        }
        //Check row 4
        for (int i = 15; i < 20; i++)
        {
            if (grid[i].Equals(Sym) || grid[i].Equals(Empty))
            {
                return false;
            }
        }
        //Check row 5
        for (int i = 20; i < 25; i++)
        {
            if (grid[i].Equals(Sym) || grid[i].Equals(Empty))
            {
                return false;
            }
        }
        return true;
    }
}
