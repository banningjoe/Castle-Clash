using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class_GameSettings : MonoBehaviour {

    public class GameSettings
    {
       public int respawnNum;
       public int startUnits;
        public int p1StartLocationInt;
        public int p2StartLocationInt;
        public Class_BoardSquare.BoardSquare p1StartLocation;
        public Class_BoardSquare.BoardSquare p2StartLocation;
    }
    //GameObject master = GameObject.Find("Master"); (referencing a public object from another script)
    //JsonReader jsonReader = master.GetComponent<JsonReader>();
    //Debug.Log(jsonReader.finalBoard);
}
