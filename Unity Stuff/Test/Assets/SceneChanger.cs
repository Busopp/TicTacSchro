using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour {

	// Use this for initialization
	//public Button changeSceneButton;
	InputField player1Name;
	
	void Start () {
        Button changeSceneButton = gameObject.GetComponent<Button>();
        //Button btn = changeSceneButton.GetComponent<Button>();
        changeSceneButton.onClick.AddListener(ChangeScene);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangeScene(){
		Debug.Log("Loaded");
		SceneManager.LoadScene("Main");
	}
}
