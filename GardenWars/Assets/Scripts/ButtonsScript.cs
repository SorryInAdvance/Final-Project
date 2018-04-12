using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonsScript : MonoBehaviour {

	public void home(){
		SceneManager.LoadScene ("Main Menu");
	}
}
