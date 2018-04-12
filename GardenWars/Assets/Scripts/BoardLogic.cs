using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoardLogic : MonoBehaviour {
	public DeckData Board;
	public GameObject DisplayCards;
	CardEffects CB;
	public GameObject name, VP, D;
	CardDatabase search;
	public Card card;
	[HideInInspector]
	public int victoryPoints, Defence;
	public GameObject playhistory;
	// Use this for initialization
	void Start () {
		search = GameObject.Find ("cardDatabaseHolder").GetComponent<CardDatabase>();
		//CB = DisplayCards.GetComponent<CardEffects> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (card == null) {
			name.GetComponent<Text> ().text = "";
			VP.GetComponent<Text> ().text = "";
			D.GetComponent<Text> ().text = "";
		} else {
			name.GetComponent<Text> ().text = card.CARDNAME.ToString();
			VP.GetComponent<Text> ().text = "VP: "+victoryPoints.ToString();
			D.GetComponent<Text> ().text = "D: "+Defence.ToString();

			if (Defence <= 0) {
				Debug.Log (card.CARDCOST);
				card = null;
				victoryPoints = 0; 
				Defence = 0;
			}
		}
	}

	public void addCard(){//Update board with cards stats
		if (Board.playedCard.CARDSUBTYPE != "Action") {
			card = Board.playedCard;
			Board.playing = false;
			Board.playerMana -= card.CARDCOST;
			Board.removeFromHand ();
			victoryPoints = card.VICTORYPOINTS;
			Defence = card.DEFENCE;
			cardEffect ();
		} else {
			Board.playing = false;
			Board.removeFromHand ();
			card = Board.playedCard;
			cardEffect ();
		}

	}
	public void addECard(Card Ecard){
		victoryPoints = Ecard.VICTORYPOINTS;
		Defence = Ecard.DEFENCE;
		card = Ecard;
		Board.enemyMana -= card.CARDCOST;
		playhistory.GetComponent<Text> ().text += "Opponent played " + Ecard.CARDNAME + "!";
		if (Ecard.CARDSUBTYPE == "Action") {
			AIAction (Ecard);
		}
	}
	public void cardEffect(){//All of the card effects
		switch (card.CARDNAME) {
		case "Garden Gnome":		
			Board.DrawCards (1, true);
			break;
		case "Mirror Carp":
			Board.addCardtoHand (true, card);
			break;
		case "Bird Egg":
			Board.addCardtoHand (true, search.findCardsByName ("Blackbird")); 
			break;
		case "Bird Bath":
			victoryPoints += Board.playedCardEffect.CheckPBoardForSubtype ("Bird");
			break;
		case "Fish Pond":
			victoryPoints += Board.playedCardEffect.CheckPBoardForSubtype ("Fish");
			break;
		case "Rainbow Koi":
			victoryPoints += Board.playedCardEffect.CheckPBoardForSubtype ("Fish");
			victoryPoints += Board.playedCardEffect.CheckPBoardForSubtype ("Bird");
			victoryPoints += Board.playedCardEffect.CheckPBoardForSubtype ("Plant");
			victoryPoints += Board.playedCardEffect.CheckPBoardForSubtype ("Decoration");
			break;
		case "Berry Bush":
			Board.addCardtoHand (true, search.findCardsByName ("Berries"));
			Board.addCardtoHand (true, search.findCardsByName ("Berries"));
			break;
		case "Berries":
			Board.DrawCards (1, true);
			break;
		case "Lava Fountain":
			Board.playedCardEffect.DamageBoard (1);
			break;
		case "Thunder Storm":
			Board.playerMana -= search.findCardsByName ("Thunder Storm").CARDCOST;
			card = null;
			break;
		case "Extra Security":
			Board.playerMana -= search.findCardsByName ("Extra Security").CARDCOST;
			Defence += 2;
			break;
		case "Playful Pets":
			Board.playerMana -= search.findCardsByName ("Playful Pets").CARDCOST;
			Board.playedCardEffect.DamageBoard (3);
			break;
		case "Extra Polish":
			Board.playerMana -= search.findCardsByName ("Extra Polish").CARDCOST;
			victoryPoints += 2;
			break;
		case "Swarm of Insects":
			Board.playerMana -= search.findCardsByName ("Swarm of Insects").CARDCOST;
			Board.playedCardEffect.DamageBoard (1);
			break;
		case "Toxic Rose":
			Board.playedCardEffect.DamageBoardtoSide (4, true);
			break;
		case "Gardens ablaze":
			Board.playerMana -= search.findCardsByName ("Gardens ablaze").CARDCOST;
			Board.playedCardEffect.DamageBoardtoSide (2, false);
			break;
		case "Greenhouse":
			Board.playerMana -= search.findCardsByName ("Greenhouse").CARDCOST;
			Board.playedCardEffect.DamageBoardtoSide (-1, true);
			break;
		case "Overnight Bandit":
			Board.playerMana -= search.findCardsByName ("Overnight Bandit").CARDCOST;
			Defence -= 1;
			Board.DrawCards (1, true);
			break;
		default:
			break;
		}
	}

	public void AIAction(Card action){
		switch (action.CARDNAME) {
		case "Playful Pets":
			
			Board.playedCardEffect.DamageBoard (3);
			break;
		case "Thunder Storm":
			
			card = null;
			break;
		case "Extra Security":
			
			Defence += 2;
			break;
		case "Extra Polish":
			
			victoryPoints += 2;
			break;
		case "Swarm of Insects":
			
			Board.playedCardEffect.DamageBoard (1);
			break;
		case "Gardens ablaze":
			
			Board.playedCardEffect.DamageBoardtoSide (2, true);
			break;
		case "Greenhouse":
			
			Board.playedCardEffect.DamageBoardtoSide (-1, false);
			break;
		case "Overnight Bandit":
			
			Defence -= 1;
			Board.DrawCards (1, false);
			break;
		default:
			break;
		}
	}

	public void AICard(Card other){
		switch (other.CARDNAME) {
		case "Garden Gnome":
			Board.DrawCards (1, false);
			break;
		case "Berries":
			Board.DrawCards (1, false);
			break;
		case "Mirror Carp":
			Board.addCardtoHand (false, card);
			break;
		case "Bird Egg":
			Board.addCardtoHand (false, search.findCardsByName ("Blackbird")); 
			break;
		case "Bird Bath":
			victoryPoints += Board.playedCardEffect.CheckEBoardForSubtype ("Bird");
			break;
		case "Fish Pond":
			victoryPoints += Board.playedCardEffect.CheckEBoardForSubtype ("Fish");
			break;
		case "Rainbow Koi":
			victoryPoints += Board.playedCardEffect.CheckEBoardForSubtype ("Fish");
			victoryPoints += Board.playedCardEffect.CheckEBoardForSubtype ("Bird");
			victoryPoints += Board.playedCardEffect.CheckEBoardForSubtype ("Plant");
			victoryPoints += Board.playedCardEffect.CheckEBoardForSubtype ("Decoration");
			break;
		case "Berry Bush":
			Board.addCardtoHand (false, search.findCardsByName ("Berries"));
			Board.addCardtoHand (false, search.findCardsByName ("Berries"));
			break;
		case "Lava Fountain":
			Board.playedCardEffect.DamageBoard (1);
			break;
		case "Toxic Rose":
			Board.playedCardEffect.DamageBoardtoSide (4, false);
			break;
		default:
			break;
		}
	}
}
