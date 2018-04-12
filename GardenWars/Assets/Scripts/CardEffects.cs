using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardEffects : MonoBehaviour {
	[HideInInspector]
	public GameObject b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14;
	public DeckData play;
	CardDatabase cardSearch;
	public CardDisplay cardName;
	int handpos;
	// Use this for initialization
	void Start () {
		cardName = gameObject.GetComponent<CardDisplay> ();
		cardSearch = GameObject.Find ("cardDatabaseHolder").GetComponent<CardDatabase> ();
		play = GameObject.Find ("Game Manager").GetComponent<DeckData>();
		b1 = GameObject.FindGameObjectWithTag ("BP1");
		b2 = GameObject.FindGameObjectWithTag ("BP2");
		b3 = GameObject.FindGameObjectWithTag ("BP3");
		b4 = GameObject.FindGameObjectWithTag ("BP4");
		b5 = GameObject.FindGameObjectWithTag ("BP5");
		b6 = GameObject.FindGameObjectWithTag ("BP6");
		b7 = GameObject.FindGameObjectWithTag ("BP7");
		b8 = GameObject.FindGameObjectWithTag ("BP8");
		b9 = GameObject.FindGameObjectWithTag ("BP9");
		b10 = GameObject.FindGameObjectWithTag ("BP10");
		b11 = GameObject.FindGameObjectWithTag ("BP11");
		b12 = GameObject.FindGameObjectWithTag ("BP12");
		b13 = GameObject.FindGameObjectWithTag ("BP13");
		b14 = GameObject.FindGameObjectWithTag ("BP14");
	}
	
	// Update is called once per frame
	void Update () {
		handpos = cardName.handPos;
		if (play.playing ==false) {
			b1.GetComponent<Button> ().interactable = false;
			b2.GetComponent<Button> ().interactable = false;
			b3.GetComponent<Button> ().interactable = false;
			b4.GetComponent<Button> ().interactable = false;
			b5.GetComponent<Button> ().interactable = false;
			b6.GetComponent<Button> ().interactable = false;
			b7.GetComponent<Button> ().interactable = false;
			b8.GetComponent<Button> ().interactable = false;
			b9.GetComponent<Button> ().interactable = false;
			b10.GetComponent<Button> ().interactable = false;
			b11.GetComponent<Button> ().interactable = false;
			b12.GetComponent<Button> ().interactable = false;
			b13.GetComponent<Button> ().interactable = false;
			b14.GetComponent<Button> ().interactable = false;
		}
	}

	public void playCard(){
		play.playing = !play.playing;
		play.playedCard = cardSearch.findCardsByName (cardName.Name.GetComponent<Text>().text);
		play.playedCardEffect = this;
		play.hpFocus = handpos;
		play.cpFocus = this.gameObject;
		if (gameObject.tag == "Action" && play.playing == true) {
			if (play.playedCard.CARDNAME == "Extra Polish" || play.playedCard.CARDNAME == "Extra Security" || play.playedCard.CARDNAME == "Greenhouse") {
				if (b1.GetComponent<BoardLogic> ().card != null) {
					b1.GetComponent<Button> ().interactable = true;
				}
				if (b2.GetComponent<BoardLogic> ().card != null) {
					b2.GetComponent<Button> ().interactable = true;
				}
				if (b3.GetComponent<BoardLogic> ().card != null) {
					b3.GetComponent<Button> ().interactable = true;
				}
				if (b4.GetComponent<BoardLogic> ().card != null) {
					b4.GetComponent<Button> ().interactable = true;
				}
				if (b5.GetComponent<BoardLogic> ().card != null) {
					b5.GetComponent<Button> ().interactable = true;
				}
				if (b6.GetComponent<BoardLogic> ().card != null) {
					b6.GetComponent<Button> ().interactable = true;
				}
				if (b7.GetComponent<BoardLogic> ().card != null) {
					b7.GetComponent<Button> ().interactable = true;
				}
			} else {
				b1.GetComponent<Button> ().interactable = true;
				b2.GetComponent<Button> ().interactable = true;
				b3.GetComponent<Button> ().interactable = true;
				b4.GetComponent<Button> ().interactable = true;
				b5.GetComponent<Button> ().interactable = true;
				b6.GetComponent<Button> ().interactable = true;
				b7.GetComponent<Button> ().interactable = true;
				b8.GetComponent<Button> ().interactable = true;
				b9.GetComponent<Button> ().interactable = true;
				b10.GetComponent<Button> ().interactable = true;
				b11.GetComponent<Button> ().interactable = true;
				b12.GetComponent<Button> ().interactable = true;
				b13.GetComponent<Button> ().interactable = true;
				b14.GetComponent<Button> ().interactable = true;
			}
		} else {
			if (b1.GetComponent<BoardLogic> ().card == null) {
				b1.GetComponent<Button> ().interactable = true;
			}
			if (b2.GetComponent<BoardLogic> ().card == null) {
				b2.GetComponent<Button> ().interactable = true;
			}
			if (b3.GetComponent<BoardLogic> ().card == null) {
				b3.GetComponent<Button> ().interactable = true;
			}
			if (b4.GetComponent<BoardLogic> ().card == null) {
				b4.GetComponent<Button> ().interactable = true;
			}
			if (b5.GetComponent<BoardLogic> ().card == null) {
				b5.GetComponent<Button> ().interactable = true;
			}
			if (b6.GetComponent<BoardLogic> ().card == null) {
				b6.GetComponent<Button> ().interactable = true;
			}
			if (b7.GetComponent<BoardLogic> ().card == null) {
				b7.GetComponent<Button> ().interactable = true;
			}
		}
	}

	public int CheckPBoardForSubtype (string type){//Count and return the number of a chosen card Subtype
		int number = 0;
		if (b1.GetComponent<BoardLogic>().card != null && cardSearch.findCardsByName (b1.GetComponent<BoardLogic> ().card.CARDNAME).CARDSUBTYPE == type) {
			number += 1;
		}
		if (b2.GetComponent<BoardLogic>().card != null && cardSearch.findCardsByName(b2.GetComponent<BoardLogic>().card.CARDNAME).CARDSUBTYPE == type) {
			number += 1;
		}
		if (b3.GetComponent<BoardLogic>().card != null && cardSearch.findCardsByName(b3.GetComponent<BoardLogic>().card.CARDNAME).CARDSUBTYPE == type) {
			number += 1;
		}
		if (b4.GetComponent<BoardLogic>().card != null && cardSearch.findCardsByName(b4.GetComponent<BoardLogic>().card.CARDNAME).CARDSUBTYPE == type) {
			number += 1;
		}
		if (b5.GetComponent<BoardLogic>().card != null && cardSearch.findCardsByName(b5.GetComponent<BoardLogic>().card.CARDNAME).CARDSUBTYPE == type) {
			number += 1;
		}
		if (b6.GetComponent<BoardLogic>().card != null && cardSearch.findCardsByName(b6.GetComponent<BoardLogic>().card.CARDNAME).CARDSUBTYPE == type) {
			number += 1;
		}
		if (b7.GetComponent<BoardLogic>().card != null && cardSearch.findCardsByName(b7.GetComponent<BoardLogic>().card.CARDNAME).CARDSUBTYPE == type) {
			number += 1;
		}
		return number;
	}

	public int CheckEBoardForSubtype (string type){//Count and return the number of a chosen card Subtype
		int number = 0;
		if (b8.GetComponent<BoardLogic>().card != null && cardSearch.findCardsByName(b8.GetComponent<BoardLogic>().card.CARDNAME).CARDSUBTYPE == type) {
			number += 1;
		}
		if (b9.GetComponent<BoardLogic>().card != null && cardSearch.findCardsByName(b9.GetComponent<BoardLogic>().card.CARDNAME).CARDSUBTYPE == type) {
			number += 1;
		}
		if (b10.GetComponent<BoardLogic>().card != null && cardSearch.findCardsByName(b10.GetComponent<BoardLogic>().card.CARDNAME).CARDSUBTYPE == type) {
			number += 1;
		}
		if (b11.GetComponent<BoardLogic>().card != null && cardSearch.findCardsByName(b11.GetComponent<BoardLogic>().card.CARDNAME).CARDSUBTYPE == type) {
			number += 1;
		}
		if (b12.GetComponent<BoardLogic>().card != null && cardSearch.findCardsByName(b12.GetComponent<BoardLogic>().card.CARDNAME).CARDSUBTYPE == type) {
			number += 1;
		}
		if (b13.GetComponent<BoardLogic>().card != null && cardSearch.findCardsByName(b13.GetComponent<BoardLogic>().card.CARDNAME).CARDSUBTYPE == type) {
			number += 1;
		}
		if (b14.GetComponent<BoardLogic>().card != null && cardSearch.findCardsByName(b14.GetComponent<BoardLogic>().card.CARDNAME).CARDSUBTYPE == type) {
			number += 1;
		}
		return number;
	}

	public void DamageBoard (int number){//reduces the defence score of each card of the field by a number
		if (b1.GetComponent<BoardLogic>().card != null) {
			b1.GetComponent<BoardLogic> ().Defence -= number;
		}
		if (b2.GetComponent<BoardLogic>().card != null) {
			b2.GetComponent<BoardLogic> ().Defence -= number;
		}
		if (b3.GetComponent<BoardLogic>().card != null) {
			b3.GetComponent<BoardLogic> ().Defence -= number;
		}
		if (b4.GetComponent<BoardLogic>().card != null) {
			b4.GetComponent<BoardLogic> ().Defence -= number;
		}
		if (b5.GetComponent<BoardLogic>().card != null) {
			b5.GetComponent<BoardLogic> ().Defence -= number;
		}
		if (b6.GetComponent<BoardLogic>().card != null) {
			b6.GetComponent<BoardLogic> ().Defence -= number;
		}
		if (b7.GetComponent<BoardLogic>().card != null) {
			b7.GetComponent<BoardLogic> ().Defence -= number;
		}
		if (b8.GetComponent<BoardLogic>().card != null ) {
			b8.GetComponent<BoardLogic> ().Defence -= number;
		}
		if (b9.GetComponent<BoardLogic>().card != null ) {
			b9.GetComponent<BoardLogic> ().Defence -= number;
		}
		if (b10.GetComponent<BoardLogic>().card != null) {
			b10.GetComponent<BoardLogic> ().Defence -= number;
		}
		if (b11.GetComponent<BoardLogic>().card != null) {
			b11.GetComponent<BoardLogic> ().Defence -= number;
		}
		if (b12.GetComponent<BoardLogic>().card != null ) {
			b12.GetComponent<BoardLogic> ().Defence -= number;
		}
		if (b13.GetComponent<BoardLogic>().card != null ) {
			b13.GetComponent<BoardLogic> ().Defence -= number;
		}
		if (b14.GetComponent<BoardLogic>().card != null ) {
			b14.GetComponent<BoardLogic> ().Defence -= number;
		}
	}
	public void DamageBoardtoSide (int number, bool player){
		if (player) {
			if (b1.GetComponent<BoardLogic>().card != null) {
				b1.GetComponent<BoardLogic> ().Defence -= number;
			}
			if (b2.GetComponent<BoardLogic>().card != null) {
				b2.GetComponent<BoardLogic> ().Defence -= number;
			}
			if (b3.GetComponent<BoardLogic>().card != null) {
				b3.GetComponent<BoardLogic> ().Defence -= number;
			}
			if (b4.GetComponent<BoardLogic>().card != null) {
				b4.GetComponent<BoardLogic> ().Defence -= number;
			}
			if (b5.GetComponent<BoardLogic>().card != null) {
				b5.GetComponent<BoardLogic> ().Defence -= number;
			}
			if (b6.GetComponent<BoardLogic>().card != null) {
				b6.GetComponent<BoardLogic> ().Defence -= number;
			}
			if (b7.GetComponent<BoardLogic>().card != null) {
				b7.GetComponent<BoardLogic> ().Defence -= number;
			}
		} else {
			if (b8.GetComponent<BoardLogic>().card != null ) {
				b8.GetComponent<BoardLogic> ().Defence -= number;
			}
			if (b9.GetComponent<BoardLogic>().card != null ) {
				b9.GetComponent<BoardLogic> ().Defence -= number;
			}
			if (b10.GetComponent<BoardLogic>().card != null) {
				b10.GetComponent<BoardLogic> ().Defence -= number;
			}
			if (b11.GetComponent<BoardLogic>().card != null) {
				b11.GetComponent<BoardLogic> ().Defence -= number;
			}
			if (b12.GetComponent<BoardLogic>().card != null ) {
				b12.GetComponent<BoardLogic> ().Defence -= number;
			}
			if (b13.GetComponent<BoardLogic>().card != null ) {
				b13.GetComponent<BoardLogic> ().Defence -= number;
			}
			if (b14.GetComponent<BoardLogic>().card != null ) {
				b14.GetComponent<BoardLogic> ().Defence -= number;
			}
		}
	}
	public int CalcVP(bool player){
		int total = 0;
		if (player) {
			if (b1.GetComponent<BoardLogic> ().card != null) {
				total += b1.GetComponent<BoardLogic> ().victoryPoints;
			}
			if (b2.GetComponent<BoardLogic> ().card != null) {
				total += b2.GetComponent<BoardLogic> ().victoryPoints;
			}
			if (b3.GetComponent<BoardLogic> ().card != null) {
				total += b3.GetComponent<BoardLogic> ().victoryPoints;
			}
			if (b4.GetComponent<BoardLogic> ().card != null) {
				total += b4.GetComponent<BoardLogic> ().victoryPoints;
			}
			if (b5.GetComponent<BoardLogic> ().card != null) {
				total += b5.GetComponent<BoardLogic> ().victoryPoints;
			}
			if (b6.GetComponent<BoardLogic> ().card != null) {
				total += b6.GetComponent<BoardLogic> ().victoryPoints;
			}
			if (b7.GetComponent<BoardLogic> ().card != null) {
				total += b7.GetComponent<BoardLogic> ().victoryPoints;
			}
		} else {
			if (b8.GetComponent<BoardLogic> ().card != null) {
				total += b8.GetComponent<BoardLogic> ().victoryPoints;
			}
			if (b9.GetComponent<BoardLogic> ().card != null) {
				total += b9.GetComponent<BoardLogic> ().victoryPoints;
			}
			if (b10.GetComponent<BoardLogic> ().card != null) {
				total += b10.GetComponent<BoardLogic> ().victoryPoints;
			}
			if (b11.GetComponent<BoardLogic> ().card != null) {
				total += b11.GetComponent<BoardLogic> ().victoryPoints;
			}
			if (b12.GetComponent<BoardLogic> ().card != null) {
				total += b12.GetComponent<BoardLogic> ().victoryPoints;
			}
			if (b13.GetComponent<BoardLogic> ().card != null) {
				total += b13.GetComponent<BoardLogic> ().victoryPoints;
			}
			if (b14.GetComponent<BoardLogic> ().card != null) {
				total += b14.GetComponent<BoardLogic> ().victoryPoints;
			}
		}
		return total;

	}
}
