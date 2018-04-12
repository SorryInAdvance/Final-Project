using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddtoList : MonoBehaviour {
	public GameObject ItemTeplate;

	public GameObject Content;

	public GameObject cardHolder;
	public CardDatabase cardData;

	void Start () {
		cardHolder = GameObject.Find ("cardDatabaseHolder");
		cardData = cardHolder.GetComponent<CardDatabase> ();
		List<Card> tempHold;
		tempHold = cardData.getCards ();

		for (int i = 0; i < tempHold.Count; i++) {
			var copy = Instantiate (ItemTeplate);
			copy.transform.SetParent(Content.transform, false);
			copy.GetComponentInChildren<Text> ().text = tempHold [i].CARDNAME + " ("+ tempHold[i].CARDCOST + ") - " + tempHold[i].CARDEFFECT;
			copy.GetComponent<AddToDeck> ().ID = i;
		}

		List<Card> deckhold;
		deckhold = cardData.getCards ();

	}
}
