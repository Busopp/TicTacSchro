using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Space : MonoBehaviour 
{
	public Button button;
	public Text buttonText;

	public enum Side{
		X, O, UD, NONE, INV
	}

	public void SetInteractable(bool interactable) {
		button.interactable = interactable;
	}

	public void ClearText() {
		buttonText.text = "";
		SetInteractable (true);
	}
}
