﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeckConstructorButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void LoadScene () {
		SceneManager.LoadScene (2);
	}
	public void LoadScene2(){
		SceneManager.LoadScene (3);
	}
}
