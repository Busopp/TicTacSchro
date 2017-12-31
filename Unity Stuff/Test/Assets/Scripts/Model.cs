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
		switch (grid [index]) {
		case Space.Side.NONE:
			grid [index] = Space.Side.UD;
			return Space.Side.UD;
		case Space.Side.UD:
			int result = RNGsus ();
			return (result == 1) ? Space.Side.X : Space.Side.O;

		default:
			return Space.Side.INV;
		}
	}

	/* Returns 1 or 0 with a 50% chance*/
	public int RNGsus() {
		return Random.Range (0, 2);
	}
}
