﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class StartButton : MonoBehaviour, IPointerClickHandler {


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}
    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }
    public void OnPointerClick( PointerEventData eventData) {
		Application.LoadLevel("Cutscene");
	}

    public void LoadLevel()
    {
        Application.LoadLevel("Cutscene");

    }
    public void OnSubmit()
    {
        Application.LoadLevel("Cutscene");

    }
}
