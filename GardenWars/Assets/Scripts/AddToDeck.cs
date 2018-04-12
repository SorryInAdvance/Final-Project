using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AddToDeck : MonoBehaviour {
	
	GameObject cardHolder;
	CardDatabase cardData;
	public int ID;
	public GameObject decklist;
	Card cID;
	void Start () {
		cardHolder = GameObject.Find ("cardDatabaseHolder");
		cardData = cardHolder.GetComponent<CardDatabase> ();
		decklist = GameObject.Find ("DeckList");
		List<Card> tempHold;
		tempHold = cardData.getCards ();

		cID = tempHold [ID];
		Debug.Log (tempHold [ID].CARDNAME);
	}


	public void AddButton_Click(){
		List<Card> tempHold;
		tempHold = cardData.getCards ();

		cardData.addCardtoDeck((int)cID.ID);
		if (cardData.deckSize <= 29) {
			decklist.GetComponent<Text> ().text += tempHold [(int)cID.ID].CARDNAME + ", ";
		}
	}

	public void RemoveCardText(){
		decklist.GetComponent<Text> ().text = "";
	}
}
