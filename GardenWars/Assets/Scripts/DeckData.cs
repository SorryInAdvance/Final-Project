using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class DeckData : MonoBehaviour {
	public bool playing = false;
	public Card playedCard;
	public CardEffects playedCardEffect;

	public int hpFocus;
	public GameObject cpFocus;

	public GameObject cardHolder;
	public CardDatabase cardData;
	public CardDisplay cDisplay;
	public GameObject iCard; //prefab to Instantiate
	public GameObject canvas;
	[HideInInspector]
	public GameObject CardInstance;
	public GameObject hp1, hp2, hp3, hp4, hp5, hp6;//hand postions
	[HideInInspector]
	public int playerMaxMana = 0;
	[HideInInspector]
	public int enemyMaxMana = 0;
	[HideInInspector]
	public int playerMana = 0;
	[HideInInspector]
	public int enemyMana = 0;
	[HideInInspector]
	public int pVP, eVP;
	List<Card> tempHold;//tempory hold for the card database

	[HideInInspector]
	public List<Card> playerDeck = new List<Card>();//holds the players deck
	[HideInInspector]
	public List<Card> enemyDeck = new List<Card>();//holds the opponents deck
	[HideInInspector]
	public Card[] pBoard = new Card[7]; //holds the players side of the board
	[HideInInspector]
	public Card[] eBoard = new Card[7];//holds the opponents side of the board
	[HideInInspector]
	public List<Card> pHand = new List<Card>();//players hand
	[HideInInspector]
	public List<Card> eHand = new List<Card>();//opponents hand
	string line;
	// Use this for initialization
	void Start () {
		playerMana = 0;
		cardHolder = GameObject.Find ("cardDatabaseHolder");
		cardData = cardHolder.GetComponent<CardDatabase> ();
		tempHold = cardData.getCards ();
		PopulateDeck ();
	}

	void PopulateDeck(){ //Fill deck from file and draw an oppening hand
		string path = Application.dataPath + "/StreamingAssets/DeckOne.txt";
		StreamReader reader = new StreamReader(path);
		for (int i = 0; i < 30; i++) {
			line = reader.ReadLine ();
				if (line != null) {
				for (int j = 0; j < tempHold.Count; j++) {
					if (line == tempHold[j].CARDNAME) {
						playerDeck.Add (cardHolder.GetComponent<CardDatabase>().findCardsByName (line));
					}
				}

			}
		}
		string epath = Application.dataPath + "/StreamingAssets/AIDeck.txt";
		StreamReader readerTwo = new StreamReader(epath);
		for (int i = 0; i < 30; i++) {
			line = readerTwo.ReadLine ();
			if (line != null) {
				for (int j = 0; j < tempHold.Count; j++) {
					if (line == tempHold[j].CARDNAME) {
						enemyDeck.Add (cardHolder.GetComponent<CardDatabase>().findCardsByName (line));
					}
				}

			}
		}
		for (int i = 0; i < playerDeck.Count; i++) {
			Debug.Log (playerDeck[i].CARDNAME);
		}
		reader.Close();
		DrawCards (4,true);
		DrawCards (4,false);
	}

	public void DrawCards(int number, bool player){//Draw cards from deck
		int rand; 
		int numDraw = 0;
		if (player == true) {
			while (numDraw != number) {
				rand = Random.Range (0, playerDeck.Count);
				if (pHand.Count <= 6 && playerDeck.Count>0) {
					pHand.Add (playerDeck [rand]);
					if (hp1.GetComponent<HandPosData> ().empty == false) {
						hp1.GetComponent<HandPosData> ().empty = true;
						CardInstance = GameObject.Instantiate<GameObject> (iCard, hp1.transform);
						CardInstance.transform.position = new Vector3 (hp1.transform.position.x, hp1.transform.position.y);
						CardInstance.transform.SetParent (canvas.transform);
						CardInstance.GetComponent<CardDisplay> ().handPos = 1;
						CardInstance.GetComponent<CardDisplay> ().DisplayStats (playerDeck [rand]);
					} else if (hp2.GetComponent<HandPosData> ().empty == false) {
						hp2.GetComponent<HandPosData> ().empty = true;
						CardInstance = GameObject.Instantiate<GameObject> (iCard, hp2.transform);
						CardInstance.transform.position = new Vector3 (hp2.transform.position.x, hp2.transform.position.y);
						CardInstance.transform.SetParent (canvas.transform);
						CardInstance.GetComponent<CardDisplay> ().handPos = 2;
						CardInstance.GetComponent<CardDisplay> ().DisplayStats (playerDeck [rand]);
					} else if (hp3.GetComponent<HandPosData> ().empty == false) {
						hp3.GetComponent<HandPosData> ().empty = true;
						CardInstance = GameObject.Instantiate<GameObject> (iCard, hp3.transform);
						CardInstance.transform.position = new Vector3 (hp3.transform.position.x, hp3.transform.position.y);
						CardInstance.transform.SetParent (canvas.transform);
						CardInstance.GetComponent<CardDisplay> ().handPos = 3;
						CardInstance.GetComponent<CardDisplay> ().DisplayStats (playerDeck [rand]);
					} else if (hp4.GetComponent<HandPosData> ().empty == false) {
						hp4.GetComponent<HandPosData> ().empty = true;
						CardInstance = GameObject.Instantiate<GameObject> (iCard, hp4.transform);
						CardInstance.transform.position = new Vector3 (hp4.transform.position.x, hp4.transform.position.y);
						CardInstance.transform.SetParent (canvas.transform);
						CardInstance.GetComponent<CardDisplay> ().handPos = 4;
						CardInstance.GetComponent<CardDisplay> ().DisplayStats (playerDeck [rand]);
					} else if (hp5.GetComponent<HandPosData> ().empty == false) {
						hp5.GetComponent<HandPosData> ().empty = true;
						CardInstance = GameObject.Instantiate<GameObject> (iCard, hp5.transform);
						CardInstance.transform.position = new Vector3 (hp5.transform.position.x, hp5.transform.position.y);
						CardInstance.transform.SetParent (canvas.transform);
						CardInstance.GetComponent<CardDisplay> ().handPos = 5;
						CardInstance.GetComponent<CardDisplay> ().DisplayStats (playerDeck [rand]);
					} else if (hp6.GetComponent<HandPosData> ().empty == false) {
						hp6.GetComponent<HandPosData> ().empty = true;
						CardInstance = GameObject.Instantiate<GameObject> (iCard, hp6.transform);
						CardInstance.transform.position = new Vector3 (hp6.transform.position.x, hp6.transform.position.y);
						CardInstance.transform.SetParent (canvas.transform);
						CardInstance.GetComponent<CardDisplay> ().handPos = 6;
						CardInstance.GetComponent<CardDisplay> ().DisplayStats (playerDeck [rand]);
					}
				}
				playerDeck.Remove (playerDeck [rand]);
				numDraw += 1;
			}
			for (int i = 0; i < pHand.Count; i++) {
				Debug.Log ("Hand: " + pHand [i].CARDNAME);
			}
		} else {
			while (numDraw != number) {
				rand = Random.Range (0, enemyDeck.Count);
				if (eHand.Count <= 6 && enemyDeck.Count>0) {
					eHand.Add (enemyDeck [rand]);
					enemyDeck.Remove (enemyDeck [rand]);

				}
				numDraw += 1;
			}
			for (int i = 0; i < eHand.Count; i++) {
				Debug.Log ("EHand: " + eHand [i].CARDNAME);
			}
		}
	}

	public void addCardtoHand (bool player, Card card){//create and add cards from deck
		if (player == true) {
			if (pHand.Count <= 6) {
				pHand.Add (card);
				if (hp1.GetComponent<HandPosData> ().empty == false) {
					hp1.GetComponent<HandPosData> ().empty = true;
					CardInstance = GameObject.Instantiate<GameObject> (iCard, hp1.transform);
					CardInstance.transform.position = new Vector3 (hp1.transform.position.x, hp1.transform.position.y);
					CardInstance.transform.SetParent (canvas.transform);
					CardInstance.GetComponent<CardDisplay> ().handPos = 1;
					CardInstance.GetComponent<CardDisplay> ().DisplayStats (card);
				} else if (hp2.GetComponent<HandPosData> ().empty == false) {
					hp2.GetComponent<HandPosData> ().empty = true;
					CardInstance = GameObject.Instantiate<GameObject> (iCard, hp2.transform);
					CardInstance.transform.position = new Vector3 (hp2.transform.position.x, hp2.transform.position.y);
					CardInstance.transform.SetParent (canvas.transform);
					CardInstance.GetComponent<CardDisplay> ().handPos = 2;
					CardInstance.GetComponent<CardDisplay> ().DisplayStats (card);
				} else if (hp3.GetComponent<HandPosData> ().empty == false) {
					hp3.GetComponent<HandPosData> ().empty = true;
					CardInstance = GameObject.Instantiate<GameObject> (iCard, hp3.transform);
					CardInstance.transform.position = new Vector3 (hp3.transform.position.x, hp3.transform.position.y);
					CardInstance.transform.SetParent (canvas.transform);
					CardInstance.GetComponent<CardDisplay> ().handPos = 3;
					CardInstance.GetComponent<CardDisplay> ().DisplayStats (card);
				} else if (hp4.GetComponent<HandPosData> ().empty == false) {
					hp4.GetComponent<HandPosData> ().empty = true;
					CardInstance = GameObject.Instantiate<GameObject> (iCard, hp4.transform);
					CardInstance.transform.position = new Vector3 (hp4.transform.position.x, hp4.transform.position.y);
					CardInstance.transform.SetParent (canvas.transform);
					CardInstance.GetComponent<CardDisplay> ().handPos = 4;
					CardInstance.GetComponent<CardDisplay> ().DisplayStats (card);
				} else if (hp5.GetComponent<HandPosData> ().empty == false) {
					hp5.GetComponent<HandPosData> ().empty = true;
					CardInstance = GameObject.Instantiate<GameObject> (iCard, hp5.transform);
					CardInstance.transform.position = new Vector3 (hp5.transform.position.x, hp5.transform.position.y);
					CardInstance.transform.SetParent (canvas.transform);
					CardInstance.GetComponent<CardDisplay> ().handPos = 5;
					CardInstance.GetComponent<CardDisplay> ().DisplayStats (card);
				} else if (hp6.GetComponent<HandPosData> ().empty == false) {
					hp6.GetComponent<HandPosData> ().empty = true;
					CardInstance = GameObject.Instantiate<GameObject> (iCard, hp6.transform);
					CardInstance.transform.position = new Vector3 (hp6.transform.position.x, hp6.transform.position.y);
					CardInstance.transform.SetParent (canvas.transform);
					CardInstance.GetComponent<CardDisplay> ().handPos = 6;
					CardInstance.GetComponent<CardDisplay> ().DisplayStats (card);
				}
			}
		} else {
			if (eHand.Count <= 6) {
				eHand.Add (card);
			}
		}
	}

	public void removeFromHand(){//remove played card from hand
		switch (hpFocus) {
		case 1:
			hp1.GetComponent<HandPosData> ().empty = false;
			Destroy (cpFocus);
			pHand.Remove (playedCard);
			break;
		case 2:
			hp2.GetComponent<HandPosData> ().empty = false;
			Destroy (cpFocus);
			pHand.Remove (playedCard);
			break;
		case 3:
			hp3.GetComponent<HandPosData> ().empty = false;
			Destroy (cpFocus);
			pHand.Remove (playedCard);
			break;
		case 4:
			hp4.GetComponent<HandPosData> ().empty = false;
			Destroy (cpFocus);
			pHand.Remove (playedCard);
			break;
		case 5:
			hp5.GetComponent<HandPosData> ().empty = false;
			Destroy (cpFocus);
			pHand.Remove (playedCard);
			break;
		case 6:
			hp6.GetComponent<HandPosData> ().empty = false;
			Destroy (cpFocus);
			pHand.Remove (playedCard);
			break;
		default:
			hp1.GetComponent<HandPosData> ().empty = false;
			Destroy (cpFocus);
			pHand.Remove (playedCard);
			break;
		}
	}

}
