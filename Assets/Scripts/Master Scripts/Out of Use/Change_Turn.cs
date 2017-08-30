using UnityEngine;
using System.Collections;

public class Change_Turn : MonoBehaviour {
	public bool Turn = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 
		if (Input.GetKeyDown (KeyCode.Space)) {
			Turn = !Turn;
			print ("Changed turn!");
		}
	}
}
