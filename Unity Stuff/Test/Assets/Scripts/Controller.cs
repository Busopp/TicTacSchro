using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/*

*/
public class Controller : MonoBehaviour {
	/* An array of 'Space' objects to store board state*/
	public Space[] spaces;
	private Model model;
	public Text turn;
	public Button reset;

	/* Function automatically called when object is constructed*/
	void Start() {
		model = new Model("player1", "player2");
		InitSpaces ();
		turn.text = ((model.p1sTurn)? model.playerOne : model.playerTwo) + "'s Turn";
		SetupResetHandler ();
	}

	/* Function to reset the grid, used at the start of each game */
	private void InitSpaces() {
		/* Iterate over all the 'spaces' */
		for (int i = 0; i < spaces.Length; i++) {
			Space space = spaces [i];

			/* Setup handler each space */
			SetupButtonClickHandler (space);
		}
	}

	private void SetupResetHandler() {
		reset.onClick.AddListener (delegate {
			model.Reset ("p1r", "p2r");
			turn.text = ((model.p1sTurn)? model.playerOne : model.playerTwo) + "'s Turn";

			for (int i = 0; i < spaces.Length; i++) {
				// TODO: reset button display
				spaces[i].ClearText();
			}

		});
	}


	/* Even handler for clicking on a 'space'*/
	private void SetupButtonClickHandler(Space space) {
		Button btn = space.button;
		btn.onClick.AddListener (delegate {
			Space.Side side = model.GetSide(int.Parse(space.name));
            
            // TODO: change text to button images
            string sideToDisplay;
			switch (side) {
			case Space.Side.UD:
				sideToDisplay = "?";
                checkWinState(sideToDisplay);
				break;
			case Space.Side.O:
				sideToDisplay = "O";
				space.SetInteractable(false);
                checkWinState(sideToDisplay);
                break;
			case Space.Side.X:
				sideToDisplay = "X";
				space.SetInteractable(false);
                checkWinState(sideToDisplay);
                break;
			default:
				return;
			}

			btn.GetComponentInChildren<Text> ().text = sideToDisplay; 

			/* Deselect button (to prevent it from being highlighted) */
			EventSystem.current.SetSelectedGameObject(null); 

			model.EndTurn();
			turn.text = ((model.p1sTurn)? model.playerOne : model.playerTwo) + "'s Turn";
		});
	}

    private void checkWinState(String placed)
    {
        //Debug.Log("Controller Works");
        Model.TurnResult result;
        result = model.checkWin();
        Debug.Log("Got here");
        if (result == Model.TurnResult.XWON)
        {
            Debug.Log("X Wins");
            //Scene change
            SceneManager.LoadScene("Win Screen");
        }
        if (result == Model.TurnResult.OWON)
        {
            Debug.Log("O Wins");
            SceneManager.LoadScene("Win Screen");
        }
        if (result == Model.TurnResult.NORMAL)
        {
            Debug.Log("Nothing");
        }
    }

}
