using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {

	public enum XO{X,O};
	public XO turn;
	public Button[] buttons;
	public int a, b, d, mC;
	public Button BackB, BackPanel, ConB;
	System.Random RandB = new System.Random ();
	int[]arr = new int[]{0,2,6,8};
	public static int PointX, PointO, PointD;
	public Text pTX, pTO, pTD, WinText;
	public static bool XorO;
	public GameObject panel;
	public bool Win;

	void Start(){
		panel.SetActive (false);
		a=RandB.Next (0, 9);
		b = arr [RandB.Next (arr.Length)];
		switch (XorO) {
		case true:
			turn = XO.O;
			break;
		case false:
			turn = XO.X;
			break;
		default:
			turn = XO.X;
			break;
		}
	}

	void toNull(){
		MainScript.PointX = 0;
		MainScript.PointO = 0;
		XorO = false;
	}

	public void GoToMenu(){
		SceneManager.LoadScene ("Menu");
		toNull ();
	}

	public void Set(int d){
		mC++;
		buttons [d].GetComponent<UnityEngine.UI.Button> ().interactable = false;
		a=RandB.Next (0, 9);
		if (turn == XO.X) {
			buttons [d].GetComponent<UnityEngine.UI.Image> ().color = Color.white;
			turn = XO.O;
		}
	}

	public Color B(int i){
		return buttons [i].GetComponent<UnityEngine.UI.Image> ().color;
	}
	public bool BI(int i){
		return buttons [i].GetComponent<UnityEngine.UI.Button> ().interactable;
	}

	public void WinMethod(){
		if ((B (0) == Color.black && B (1) == Color.black && B (2) == Color.black) || (B (3) == Color.black && B (4) == Color.black && B (5) == Color.black) || (B (6) == Color.black && B (7) == Color.black && B (8) == Color.black) || (B (2) == Color.black && B (4) == Color.black && B (6) == Color.black) || (B (0) == Color.black && B (4) == Color.black && B (8) == Color.black) || (B (0) == Color.black && B (5) == Color.black && B (6) == Color.black) || (B (1) == Color.black && B (4) == Color.black && B (7) == Color.black) || (B (2) == Color.black && B (3) == Color.black && B (8) == Color.black)) {
			panel.SetActive (true);
			WinText.text = "BLACK WIN!";
			Win = true;
			if (ConB.GetComponent<UnityEngine.UI.Button> ().interactable == false) {
				SceneManager.LoadScene ("Game");
				mC = 0;
				MainScript.PointO++;
				XorO = true;
				panel.SetActive (false);
			}
			if (BackPanel.GetComponent<UnityEngine.UI.Button> ().interactable == false) {
				GoToMenu ();
			}
		}
		if ((B (0) == Color.white && B (1) == Color.white && B (2) == Color.white) || (B (3) == Color.white && B (4) == Color.white && B (5) == Color.white) || (B (6) == Color.white && B (7) == Color.white && B (8) == Color.white) || (B (2) == Color.white && B (4) == Color.white && B (6) == Color.white) || (B (0) == Color.white && B (4) == Color.white && B (8) == Color.white) || (B (0) == Color.white && B (5) == Color.white && B (6) == Color.white) || (B (1) == Color.white && B (4) == Color.white && B (7) == Color.white) || (B (2) == Color.white && B (3) == Color.white && B (8) == Color.white)) {
			panel.SetActive (true);
			WinText.text = "WHITE WIN!";
			Win = true;
			if (ConB.GetComponent<UnityEngine.UI.Button> ().interactable == false) {
				SceneManager.LoadScene ("Game");
				mC = 0;
				MainScript.PointX++;
				XorO = false;
				panel.SetActive (false);
			}
			if (BackPanel.GetComponent<UnityEngine.UI.Button> ().interactable == false) {
				GoToMenu ();
			}
		} 
		if (XorO) {
			if (mC == 4 && Win==false) {
				panel.SetActive (true);
				WinText.text = "DRAW!";
				if (ConB.GetComponent<UnityEngine.UI.Button> ().interactable == false) {
					SceneManager.LoadScene ("Game");
					XorO = false;
					PointD++;
				}
				if (BackPanel.GetComponent<UnityEngine.UI.Button> ().interactable == false) {
					GoToMenu ();
				}
			}
		} else {
			if (mC == 5 && Win==false) {
				panel.SetActive (true);
				WinText.text = "DRAW!";
				if (ConB.GetComponent<UnityEngine.UI.Button> ().interactable == false) {
					SceneManager.LoadScene ("Game");
					XorO = false;
					PointD++;
				}
				if (BackPanel.GetComponent<UnityEngine.UI.Button> ().interactable == false) {
					GoToMenu ();
				}
			}
		}
	}

	void PC(){
		switch (Menu.Level) {
		case "Easy":
			if (turn == XO.O) {
				if (BI (a) == true) {
					buttons [a].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
					buttons [a].GetComponent<UnityEngine.UI.Button> ().interactable = false;
					turn = XO.X;
				} else {
					a = RandB.Next (0, 9);
				}
			}
			break;
		case "Normal":
			if (turn == XO.O) {
				if (buttons [4].GetComponent<UnityEngine.UI.Button> ().interactable == true) {
					buttons [4].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
					buttons [4].GetComponent<UnityEngine.UI.Button> ().interactable = false;
					turn = XO.X;
				} else if (BI (0) == false && BI (1) == false && BI (2) == true) {
					buttons [2].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
					buttons [2].GetComponent<UnityEngine.UI.Button> ().interactable = false;
					turn = XO.X;
				} else if (BI (0) == false && BI (5) == false && BI (6) == true) {
					buttons [6].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
					buttons [6].GetComponent<UnityEngine.UI.Button> ().interactable = false;
					turn = XO.X;
				} else if (BI (6) == false && BI (7) == false && BI (8) == true) {
					buttons [8].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
					buttons [8].GetComponent<UnityEngine.UI.Button> ().interactable = false;
					turn = XO.X;
				} else if (BI (8) == false && BI (3) == false && BI (2) == true) {
					buttons [2].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
					buttons [2].GetComponent<UnityEngine.UI.Button> ().interactable = false;
					turn = XO.X;
				} else if (BI (4) == false && BI (8) == false && BI (0) == true) {
					buttons [0].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
					buttons [0].GetComponent<UnityEngine.UI.Button> ().interactable = false;
					turn = XO.X;
				} else if (BI (2) == false && BI (4) == false && BI (6) == true) {
					buttons [6].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
					buttons [6].GetComponent<UnityEngine.UI.Button> ().interactable = false;
					turn = XO.X;
				} else {
					if (BI (a) == true) {
						buttons [a].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [a].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else {
						a = RandB.Next (0, 9);
					}
				}
			}
			break;
		case "Hard":
			if (turn == XO.O) {
				if (XorO) {
					if (buttons [4].GetComponent<UnityEngine.UI.Button> ().interactable == true) {
						buttons [4].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [4].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (0) == false && BI (4) == false && BI (2) == true) {
						buttons [2].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [2].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (0) == false && BI (5) == false && BI (6) == true) {
						buttons [6].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [6].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (0) == false && BI (1) == false && BI (2) == true) {
						buttons [2].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [2].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (0) == false && BI (5) == false && BI (6) == true) {
						buttons [6].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [6].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (5) == false && BI (6) == false && BI (0) == true) {
						buttons [0].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [0].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (6) == false && BI (7) == false && BI (8) == true) {
						buttons [8].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [8].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (7) == false && BI (8) == false && BI (6) == true) {
						buttons [6].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [6].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (8) == false && BI (3) == false && BI (2) == true) {
						buttons [2].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [2].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (3) == false && BI (2) == false && BI (8) == true) {
						buttons [8].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [8].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (2) == false && BI (1) == false && BI (0) == true) {
						buttons [0].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [0].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (4) == false && BI (5) == false && BI (3) == true) {
						buttons [3].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [3].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (4) == false && BI (7) == false && BI (1) == true) {
						buttons [1].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [1].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (4) == false && BI (3) == false && BI (5) == true) {
						buttons [5].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [5].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (4) == false && BI (1) == false && BI (7) == true) {
						buttons [7].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [7].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else {
						if (BI (a) == true) {
							buttons [a].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
							buttons [a].GetComponent<UnityEngine.UI.Button> ().interactable = false;
							turn = XO.X;
						} else {
							a = RandB.Next (0, 9);
						}
					}
				} else {
					if (buttons [4].GetComponent<UnityEngine.UI.Button> ().interactable == true) {
						buttons [4].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [4].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (0) == false && BI (1) == false && BI (2) == true) {
						buttons [2].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [2].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (0) == false && BI (5) == false && BI (6) == true) {
						buttons [6].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [6].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (5) == false && BI (6) == false && BI (0) == true) {
						buttons [0].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [0].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (6) == false && BI (7) == false && BI (8) == true) {
						buttons [8].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [8].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (7) == false && BI (8) == false && BI (6) == true) {
						buttons [6].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [6].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (8) == false && BI (3) == false && BI (2) == true) {
						buttons [2].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [2].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (3) == false && BI (2) == false && BI (8) == true) {
						buttons [8].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [8].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (2) == false && BI (1) == false && BI (0) == true) {
						buttons [0].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [0].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (4) == false && BI (5) == false && BI (3) == true) {
						buttons [3].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [3].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (4) == false && BI (7) == false && BI (1) == true) {
						buttons [1].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [1].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (4) == false && BI (3) == false && BI (5) == true) {
						buttons [5].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [5].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (4) == false && BI (1) == false && BI (7) == true) {
						buttons [7].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
						buttons [7].GetComponent<UnityEngine.UI.Button> ().interactable = false;
						turn = XO.X;
					} else if (BI (0) == false && BI (2) == false && BI (6) == false && BI (8) == false) {
						if (BI (a) == true) {
							buttons [a].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
							buttons [a].GetComponent<UnityEngine.UI.Button> ().interactable = false;
							turn = XO.X;
						} else {
							a = RandB.Next (0, 9);
						}
					} else {
						if (BI (b) == true) {
							buttons [b].GetComponent<UnityEngine.UI.Image> ().color = Color.black;
							buttons [b].GetComponent<UnityEngine.UI.Button> ().interactable = false;
							turn = XO.X;
						} else {
							b = arr [RandB.Next (arr.Length)];
						}
					}
				}
			}
			break;
		}
	}

	public void Update(){
		WinMethod ();
		PC();
		pTX.text = PointX.ToString();
		pTO.text = PointO.ToString();
		pTD.text = PointD.ToString ();
	}
}
