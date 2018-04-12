using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using LitJson;
using System.IO;
public class CardDatabase : MonoBehaviour {

	private List<Card> database = new List<Card>(); //Full database of cards
	private JsonData cardData; 
	private JsonData deckData;
	private Card error; //Error card incase card cannot be found

	public TextAsset asset;

	List<Card> deck = new List<Card>();
	[HideInInspector]
	public int deckSize = 0;
	string decktext;
	// Use this for initialization
	void Start () {
		cardData = JsonMapper.ToObject (File.ReadAllText (Application.dataPath + "/StreamingAssets/Cards.json"));//Find JSON file containing card data
		ConstructDatabase ();
	}
	public List<Card> getCards(){
		return database;
	}
	public List<Card> getDeck(){
		return deck;
	}
	void ConstructDatabase(){
		for (int i = 0; i < cardData.Count; i++) {
			database.Add (new Card ((int)cardData [i] ["ID"], cardData [i] ["cardName"].ToString(), cardData [i] ["SubType"].ToString(), (int)cardData [i] ["Cost"], cardData [i] ["Effect"].ToString(), (int)cardData [i] ["VP"], (int)cardData [i] ["Defence"]));
		}
	}
	void ConstructDeck(){
		deck.Clear();
		for (int i = 0; i < deckData.Count; i++) {
			deck.Add (new Card ((int)deckData [i] ["ID"], deckData [i] ["CARDNAME"].ToString(), deckData [i] ["CARDSUBTYPE"].ToString(), (int)deckData [i] ["CARDCOST"], deckData [i] ["CARDEFFECT"].ToString(), (int)deckData [i] ["VICTORYPOINTS"], (int)deckData [i] ["DEFENCE"]));
		}
	}
	public void findCardsByType(string Type){
		for (int i = 0; i < cardData.Count; i++) {
			if (Type == database[i].CARDSUBTYPE) {
				Debug.Log ("Name: " + database [i].CARDNAME + " Type: " + database[i].CARDSUBTYPE + " Costs: " + database [i].CARDCOST + " Effect: " + database [i].CARDEFFECT);
			}
		}
	}

	public Card findCardsByID(int ID){
		for (int i = 0; i < cardData.Count; i++) {
			if (ID == database[i].ID) {
				Debug.Log ("Name: " + database [i].CARDNAME + " Type: " + database[i].CARDSUBTYPE + " Costs: " + database [i].CARDCOST + " Effect: " + database [i].CARDEFFECT);
				return database [i];
			}

		}
		return error;
	}
	public Card findCardsByName(string Name){
		for (int i = 0; i < cardData.Count; i++) {
			if (Name == database[i].CARDNAME) {
					return database [i];
				}
			}

		return error;
	}

	public void addCardtoDeck(int cardID){//adds cards to deck
		string path = Application.dataPath + "/StreamingAssets/DeckOne.txt";
		if (deckSize < 31) {
			deck.Add(findCardsByID (cardID));
			StreamWriter writer = new StreamWriter(path, true);
			writer.WriteLine(findCardsByID (cardID).CARDNAME);
			writer.Close();

			deckSize++;
			decktext = " ";

			AssetDatabase.ImportAsset(path); 
			asset = Resources.Load("DeckOne") as TextAsset;

			for (int i = 0; i < deck.Count; i++) {
				decktext += deck [i].CARDNAME + ", ";
			}
			Debug.Log (decktext);
		} else {
			Debug.Log ("Deck is full");
			for (int i = 0; i < deck.Count; i++) {
				decktext += deck [i].CARDNAME + ", ";
			}
			Debug.Log (decktext);
		}
	}

	public void RemoveCards(){//Remove all cards from the deck
		DeckSizeZero ();
		string path = Application.dataPath + "/StreamingAssets/DeckOne.txt";
		System.IO.File.WriteAllText(path,string.Empty);

	}

	public void DeckSizeZero(){
		deckSize = 0;
		deck.Clear();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
public class Card{//Class for all Cards
	public int ID{ get; set; }
	public string CARDNAME{ get; set; }
	public string CARDSUBTYPE{ get; set; }
	public string CARDEFFECT{ get; set; }
	public int CARDCOST{ get; set; }
	public int VICTORYPOINTS{ get; set; }
	public int DEFENCE{ get; set; }


	public Card (int id, string cardName, string cardSubtype, int cardCost, string cardEffect, int victoryPoints, int Defence)
	{
		this.ID = id;
		this.CARDNAME = cardName;
		this.CARDSUBTYPE = cardSubtype;
		this.CARDCOST = cardCost;
		this.CARDEFFECT = cardEffect;
		this.VICTORYPOINTS = victoryPoints;
		this.DEFENCE = Defence;

	}
	public Card (){
		this.ID = -1;
	}
}