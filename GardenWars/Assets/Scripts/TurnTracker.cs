using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TurnTracker : MonoBehaviour {
	DeckData manaManager;
	CardEffects VPm;
	int turnTracker;
	public GameObject win, lose;
	public GameObject pMana, eMana, pVP, eVP;
	int winThreshold = 25;
	int turnNumber = 1;
	// Use this for initialization
	void Start () {
		manaManager = GameObject.Find ("Game Manager").GetComponent<DeckData>();

	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("Other") != null) {
			VPm = GameObject.FindWithTag ("Other").GetComponent<CardEffects> ();
		} else if (GameObject.FindGameObjectWithTag ("Action") != null) {
			VPm = GameObject.FindWithTag ("Action").GetComponent<CardEffects> ();
		}
		if (manaManager.enemyMana < 0) {
			manaManager.enemyMana = 0;
		}
		//Update mana
		pVP.GetComponent<InputField> ().text = manaManager.pVP + "/" + winThreshold;
		eVP.GetComponent<InputField> ().text = manaManager.eVP + "/" + winThreshold;
		pMana.GetComponent<InputField> ().text = manaManager.playerMana + "/" + manaManager.playerMaxMana;
		eMana.GetComponent<InputField> ().text = manaManager.enemyMana + "/" + manaManager.enemyMaxMana;
		switch (turnTracker) {//Turn logic
		case 0:
			if (Random.value > 0.5) {
				turnTracker = 1;
			} else {
				turnTracker = 4;
			}
			break;
		case 1:
			if (turnNumber != 1) {
				manaManager.DrawCards (1, true);
			}
			manaManager.playerMaxMana += 1;
			manaManager.playerMana = manaManager.playerMaxMana;
			turnTracker++;

			break;
		case 2:
			gameObject.GetComponentInChildren<Text> ().text = "End Turn";
			break;
		case 3:
			gameObject.GetComponent<Button> ().interactable = false;
			turnNumber++;
			manaManager.eVP += VPm.CalcVP (false);
			if (manaManager.eVP >= 25) {
				SceneManager.LoadScene ("Lose");
			}
			turnTracker = 4;

			break;
		case 4:
			if (turnNumber != 1) {
				manaManager.DrawCards (1, false);
			}
			gameObject.GetComponent<Button> ().interactable = false;
			manaManager.enemyMaxMana += 1;
			manaManager.enemyMana = manaManager.enemyMaxMana;
			turnTracker++;
			Debug.Log(turnTracker);
			break;
		case 5:
			gameObject.GetComponentInChildren<Text> ().text = "Oppenent Turn";//AI turn logic
			for (int i = 0; i < manaManager.eHand.Count; i++) {
				if (manaManager.eHand[i].CARDCOST <= manaManager.enemyMana && manaManager.enemyMana > 0 && manaManager.eHand[i] != null ) {
					if (manaManager.eHand [i].CARDSUBTYPE == "Action") {
						if (manaManager.eHand [i].CARDNAME == "Extra Sercurity" || manaManager.eHand [i].CARDNAME == "Extra Sercurity") {
							bool played = false;
							int rand;
							int attempts = 0;
							if (VPm.b8.GetComponent<BoardLogic> ().card != null && VPm.b9.GetComponent<BoardLogic> ().card != null && VPm.b10.GetComponent<BoardLogic> ().card != null && VPm.b11.GetComponent<BoardLogic> ().card != null && VPm.b12.GetComponent<BoardLogic> ().card != null && VPm.b13.GetComponent<BoardLogic> ().card != null && VPm.b14.GetComponent<BoardLogic> ().card != null) {
								turnTracker = 6;
							} else {
								while (played == false) {
									rand = Random.Range (0, 6);
									if (VPm.b8.GetComponent<BoardLogic> ().card != null) {
										VPm.b8.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
										VPm.b8.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
										manaManager.eHand.Remove (manaManager.eHand [i]);

										played = true;
									} else if (VPm.b9.GetComponent<BoardLogic> ().card != null) {
										VPm.b9.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
										VPm.b9.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
										manaManager.eHand.Remove (manaManager.eHand [i]);

										played = true;
									} else if (VPm.b10.GetComponent<BoardLogic> ().card != null) {
										VPm.b10.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
										VPm.b10.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
										manaManager.eHand.Remove (manaManager.eHand [i]);

										played = true;
									} else if (VPm.b11.GetComponent<BoardLogic> ().card != null) {
										VPm.b11.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
										VPm.b11.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
										manaManager.eHand.Remove (manaManager.eHand [i]);

										played = true;
									} else if (VPm.b12.GetComponent<BoardLogic> ().card != null) {
										VPm.b12.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
										VPm.b12.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
										manaManager.eHand.Remove (manaManager.eHand [i]);

										played = true;
									} else if (VPm.b13.GetComponent<BoardLogic> ().card != null) {
										VPm.b13.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
										VPm.b13.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
										manaManager.eHand.Remove (manaManager.eHand [i]);

										played = true;
									} else if (VPm.b14.GetComponent<BoardLogic> ().card != null) {
										VPm.b14.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
										VPm.b14.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
										manaManager.eHand.Remove (manaManager.eHand [i]);

										played = true;
									}
									attempts++;
									if (attempts > 5) {
										Debug.Log (attempts);
										played = true;
									}
							
								}
							}
						} else {
							bool played = false;
							int rand;
							int attempts = 0;
							if (VPm.b1.GetComponent<BoardLogic> ().card != null && VPm.b2.GetComponent<BoardLogic> ().card != null && VPm.b3.GetComponent<BoardLogic> ().card != null && VPm.b4.GetComponent<BoardLogic> ().card != null && VPm.b5.GetComponent<BoardLogic> ().card != null && VPm.b6.GetComponent<BoardLogic> ().card != null && VPm.b7.GetComponent<BoardLogic> ().card != null) {
								turnTracker = 6;
							} else {
								while (played == false) {
									rand = Random.Range (0, 6);
									if (VPm.b1.GetComponent<BoardLogic> ().card != null) {
										VPm.b1.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
										VPm.b1.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
										manaManager.eHand.Remove (manaManager.eHand [i]);

										played = true;
									} else if (VPm.b2.GetComponent<BoardLogic> ().card != null) {
										VPm.b2.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
										VPm.b2.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
										manaManager.eHand.Remove (manaManager.eHand [i]);

										played = true;
									} else if (VPm.b3.GetComponent<BoardLogic> ().card != null) {
										VPm.b3.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
										VPm.b3.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
										manaManager.eHand.Remove (manaManager.eHand [i]);

										played = true;
									} else if (VPm.b4.GetComponent<BoardLogic> ().card != null) {
										VPm.b4.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
										VPm.b4.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
										manaManager.eHand.Remove (manaManager.eHand [i]);

										played = true;
									} else if (VPm.b5.GetComponent<BoardLogic> ().card != null) {
										VPm.b5.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
										VPm.b5.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
										manaManager.eHand.Remove (manaManager.eHand [i]);

										played = true;
									} else if (VPm.b6.GetComponent<BoardLogic> ().card != null) {
										VPm.b6.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
										VPm.b6.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
										manaManager.eHand.Remove (manaManager.eHand [i]);

										played = true;
									} else if (VPm.b7.GetComponent<BoardLogic> ().card != null) {
										VPm.b7.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
										VPm.b7.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
										manaManager.eHand.Remove (manaManager.eHand [i]);

										played = true;
									}
									attempts++;
									if (attempts > 5) {
										Debug.Log (attempts);
										played = true;
									}

								}
							}

						}

					} else {
						if (VPm.b8.GetComponent<BoardLogic> ().card != null && VPm.b9.GetComponent<BoardLogic> ().card != null && VPm.b10.GetComponent<BoardLogic> ().card != null && VPm.b11.GetComponent<BoardLogic> ().card != null && VPm.b12.GetComponent<BoardLogic> ().card != null && VPm.b13.GetComponent<BoardLogic> ().card != null && VPm.b14.GetComponent<BoardLogic> ().card == null) {
							turnTracker = 6;
						}else{
						if (VPm.b8.GetComponent<BoardLogic> ().card == null) {
							VPm.b8.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
							VPm.b8.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
							manaManager.eHand.Remove (manaManager.eHand [i]);

						} else if (VPm.b9.GetComponent<BoardLogic> ().card == null) {
							VPm.b9.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
							VPm.b9.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
							manaManager.eHand.Remove (manaManager.eHand [i]);

						} else if (VPm.b10.GetComponent<BoardLogic> ().card == null) {
							VPm.b10.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
							VPm.b10.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
							manaManager.eHand.Remove (manaManager.eHand [i]);

						} else if (VPm.b11.GetComponent<BoardLogic> ().card == null) {
							VPm.b11.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
							VPm.b11.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
							manaManager.eHand.Remove (manaManager.eHand [i]);

						} else if (VPm.b12.GetComponent<BoardLogic> ().card == null) {
							VPm.b12.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
							VPm.b12.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
							manaManager.eHand.Remove (manaManager.eHand [i]);

						} else if (VPm.b13.GetComponent<BoardLogic> ().card == null) {
							VPm.b13.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
							VPm.b13.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
							manaManager.eHand.Remove (manaManager.eHand [i]);

						} else if (VPm.b14.GetComponent<BoardLogic> ().card == null) {
							VPm.b14.GetComponent<BoardLogic> ().addECard (manaManager.eHand [i]);
							VPm.b14.GetComponent<BoardLogic> ().AICard (manaManager.eHand [i]);
							manaManager.eHand.Remove (manaManager.eHand [i]);
						
						}
					}
				}

				}
			}
			turnTracker = 6;
			break;
		case 6:
			manaManager.pVP += VPm.CalcVP (true);//Calculate player points
			if (manaManager.pVP >= 25) {
				Instantiate (win,new Vector3(0,0),Quaternion.identity);
				SceneManager.LoadScene ("Win");
			}
			gameObject.GetComponent<Button> ().interactable = true;
			turnNumber++;
			turnTracker = 1;
			break;
		default:
			break;
		}
	}

	public void EndTurn(){
		turnTracker = 3;
	}



}
