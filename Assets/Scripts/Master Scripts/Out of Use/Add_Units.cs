using UnityEngine;
using System.Collections;

public class Add_Units : MonoBehaviour {
	public int Player_1_Units = 4;
	public int Player_2_Units = 4;
	public ArrayList P1_Array = new ArrayList();
	public ArrayList P2_Array = new ArrayList();
	public GameObject P1_Unit_GameObject;
	public GameObject P2_Unit_GameObject;
	public GameObject P1;
    public GameObject P2;
	// Use this for initialization
	void Start () {
        Starting_Units();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			Change_Units (1);
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			Change_Units (-1);
		}

		Instantiate_Units ();
	}

	public void Starting_Units() {
		GameObject test_unit;
		for (var x = 0; x < 4; x++) {
			P1_Array.Add (Instantiate (P1_Unit_GameObject, new Vector3 (0, 0, (P1_Array.Count * 2)), Quaternion.identity));
			test_unit = (GameObject)P1_Array [P1_Array.Count - 1];
			test_unit.transform.parent = P1.transform;
			P2_Array.Add (Instantiate (P2_Unit_GameObject, new Vector3 (2, 0, (P2_Array.Count * 2)), Quaternion.identity));
			test_unit = (GameObject)P2_Array [P2_Array.Count - 1];
			test_unit.transform.parent = P2.transform;
		}	
	}

	public bool Check_Turn () {
		Change_Turn change_turn = GetComponent<Change_Turn> ();
		return change_turn.Turn;
	}

	public int Change_Units (int Amount) {
		bool turn = Check_Turn ();
		if (turn) {
			if (!(Amount < 1 & Player_1_Units < 1)) {
				Player_1_Units += Amount;
				print ("P1 = " + Player_1_Units.ToString ());
				}
			return Player_1_Units;
		}

		else {
			if (!(Amount < 1 & Player_2_Units < 1)) {
				Player_2_Units += Amount;
				print ("P2 = " + Player_2_Units.ToString());
			}
			return Player_2_Units;
		}
	}

	public void Instantiate_Units () {
		bool turn = Check_Turn ();
		if (turn) {
			if (Player_1_Units > P1_Array.Count) {
				P1_Array.Add (Instantiate (P1_Unit_GameObject, new Vector3 (0, 0, (P1_Array.Count * 2)), Quaternion.identity));
				GameObject temp_unit = (GameObject)P1_Array [P1_Array.Count - 1];
				temp_unit.transform.parent = P1.transform;

			}
			if (Player_1_Units < P1_Array.Count) {
				GameObject temp_unit = (GameObject)P1_Array [P1_Array.Count - 1];
				temp_unit.SetActive (false);
				P1_Array.RemoveAt (P1_Array.Count - 1);
				Destroy (temp_unit);

			}
		}
		else {
			if (Player_2_Units > P2_Array.Count) {
				P2_Array.Add (Instantiate (P2_Unit_GameObject, new Vector3 (2, 0, (P2_Array.Count * 2)), Quaternion.identity));
				GameObject temp_unit = (GameObject)P2_Array [P2_Array.Count - 1];
				temp_unit.transform.parent = P2.transform;

			}
			if (Player_2_Units < P2_Array.Count) {
				GameObject temp_unit = (GameObject)P2_Array [P2_Array.Count - 1];
				temp_unit.SetActive (false);
				P2_Array.RemoveAt (P2_Array.Count - 1);
				Destroy (temp_unit);

			}
		}
	}

}	

