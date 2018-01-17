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
        if (checkOWins()) { return Model.TurnResult.OWON; }
        return Model.TurnResult.NORMAL;
    }

    public bool checkXWins()
    {
        Space.Side Sym = Space.Side.O;
        Space.Side Empty = Space.Side.NONE;
        int j = 0;
        //Check row 1
        for (int i = 0; i < 5; i++)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }
                
            }
        }
        if (j == 104 || j == 203 || j==302 || j== 401 || j==500) { return true; }

        j = 0;
        //Check row 2
        for (int i = 0; i < 5; i++)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        j = 0;
        //Check row 3
        for (int i = 0; i < 5; i++)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        j = 0;
        //Check row 4
        for (int i = 0; i < 5; i++)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        j = 0;
        //Check row 5
        for (int i = 0; i < 5; i++)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        //Check Columns
        //Check col 1
        j = 0;
        for (int i = 0; i < 25; i+=5)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        //Check col 2
        j = 0;
        for (int i = 1; i < 25; i += 5)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        //Check col 3
        j = 0;
        for (int i = 2; i < 25; i += 5)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        //Check col 4
        j = 0;
        for (int i = 3; i < 25; i += 5)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        //Check col 5
        j = 0;
        for (int i = 4; i < 25; i += 5)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        //Check diagonal \
        j = 0;
        for (int i = 0; i < 25; i += 6)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        //Check diagonal /
        j = 0;
        for (int i = 0; i < 21; i += 4)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }


        return false;
    }

    public bool checkOWins()
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
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        j = 0;
        //Check row 2
        for (int i = 0; i < 5; i++)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        j = 0;
        //Check row 3
        for (int i = 0; i < 5; i++)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        j = 0;
        //Check row 4
        for (int i = 0; i < 5; i++)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        j = 0;
        //Check row 5
        for (int i = 0; i < 5; i++)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        //Check Columns
        //Check col 1
        j = 0;
        for (int i = 0; i < 25; i += 5)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        //Check col 2
        j = 0;
        for (int i = 1; i < 25; i += 5)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        //Check col 3
        j = 0;
        for (int i = 2; i < 25; i += 5)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        //Check col 4
        j = 0;
        for (int i = 3; i < 25; i += 5)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        //Check col 5
        j = 0;
        for (int i = 4; i < 25; i += 5)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        //Check diagonal \
        j = 0;
        for (int i = 0; i < 25; i += 6)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }

        //Check diagonal /
        j = 0;
        for (int i = 0; i < 21; i += 4)
        {
            if (!grid[i].Equals(Sym))
            {
                if (!grid[i].Equals(Empty))
                {
                    if (grid[i].Equals(Space.Side.UD)) { j++; } else { j += 100; }
                }

            }
        }
        if (j == 104 || j == 203 || j == 302 || j == 401 || j == 500) { return true; }


        return false;
    }
}
