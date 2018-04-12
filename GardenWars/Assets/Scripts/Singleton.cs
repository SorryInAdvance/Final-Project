using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

	public static Singleton i;

	void Awake () {
		if(!i) {
			i = this;
			DontDestroyOnLoad(gameObject);
		}else 
			Destroy(gameObject);
	}
}
