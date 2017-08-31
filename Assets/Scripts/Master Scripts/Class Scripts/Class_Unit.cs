using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class_Unit : MonoBehaviour {
	
    [System.Serializable]
	public class Unit
    {
        public Class_BoardSquare.BoardSquare location;
        public bool type;
        public int owner;
		public GameObject figure;
        //Methods: ChangeLocation, Die (Also, a method which instantiates model)
        public Unit(Class_BoardSquare.BoardSquare location, bool type, int owner)
        {
            this.location = location;
            this.type = type;
            this.owner = owner;
        }

        public void ChangeType()
        {
            this.type = !this.type;
            Debug.Log("Type changed to " + this.type.ToString());
        }

        public void ChangeLocation(Class_BoardSquare.BoardSquare newLocation)
        {
            this.location = newLocation;
        }
    } 
}
