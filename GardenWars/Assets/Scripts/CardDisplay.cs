using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardDisplay : MonoBehaviour {
	public GameObject VP, D, Effect, Name, Cost;
	public DeckData Atrribute;
	[HideInInspector]
	public int handPos;
	int victoryPoints, Defence, cardCost;
	// Use this for initialization
	void Start () {
		Atrribute = GameObject.Find ("Game Manager").GetComponent<DeckData>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Atrribute.playerMana < cardCost || Atrribute.playing == true) {
			gameObject.GetComponent<Button> ().interactable = false;
		} else {
			gameObject.GetComponent<Button> ().interactable = true;
		}
		VP.GetComponent<Text> ().text = victoryPoints.ToString();
		D.GetComponent<Text> ().text = Defence.ToString();
		Cost.GetComponent<Text> ().text = cardCost.ToString();
	}

	public void DisplayStats(Card card){//Display the stats of the cards while in hand
		if (card.CARDSUBTYPE != "Action") {
			gameObject.tag = "Other";
		} else {
			gameObject.tag = "Action";
		}
		VP.GetComponent<Text> ().text = card.VICTORYPOINTS.ToString();
		D.GetComponent<Text> ().text = card.DEFENCE.ToString();
		Effect.GetComponent<Text> ().text = card.CARDEFFECT.ToString();
		Name.GetComponent<Text> ().text = card.CARDNAME.ToString();
		Cost.GetComponent<Text> ().text = card.CARDCOST.ToString();

		victoryPoints = card.VICTORYPOINTS;
		Defence = card.DEFENCE;
		cardCost = card.CARDCOST;
	}
}
