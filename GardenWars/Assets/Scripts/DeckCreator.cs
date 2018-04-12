using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.SceneManagement;

public class DeckCreator : MonoBehaviour {
	List<Card> deck;
	int deckSize;
	public CardDatabase cardData;

	void Start () {
		List<Card> tempHold;
		tempHold = cardData.getCards ();
	}

	public void addCardtoDeck(int cardID){
		List<Card> tempHold;
		tempHold = cardData.getCards ();
		if (deckSize < 30) {
			cardData.findCardsByID (cardID);
			deckSize++;
			for (int i = 0; i < deck.Count; i++) {
				Debug.Log (deck [i].CARDNAME+", ");
			}
		} else {
			Debug.Log ("Deck is full");
		}
	}


}
