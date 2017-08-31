using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class_BoardSquare : MonoBehaviour {

    [System.Serializable]
    public class BoardSquare
    {
        public string name;
        public int number;
        public string type; // convert this to enum type maybe
        public int[] intNeighbours;
        public BoardSquare[] boardSquareNeighbours;
        public Dictionary<bool,List<Class_Unit.Unit>> units = new Dictionary<bool, List<Class_Unit.Unit>>();
        public int owner; // convert this to enum type
        
       public string ToString()
        {
            return "[" + this.units[true].Count.ToString() + "," + this.units[false].Count.ToString() + "]";
        }

        public void KillWarriors(int howMany)
        {
            if (this.units[true].Count > howMany)
            {
                this.units[true].RemoveRange(0, howMany);
            }
            else
            {
                this.units[true].Clear();
                this.units[true].TrimExcess();
            }
            
        }

        public void KillVillagers()
        {
            this.units[false].Clear();
            this.units[false].TrimExcess();
        }
        public void KillVillagers(int howMany)
        {
            if (this.units[false].Count > howMany)
            {
                this.units[false].RemoveRange(0,howMany);
            }
            else
            {
                this.units[false].Clear();
                this.units[false].TrimExcess();
            }
        }
        public void SetOwner()
        {
            if (this.units[true].Count > 0 || this.units[false].Count > 0)
            {
                if (this.units[true].Count > 0)
                {
                    this.owner = this.units[true][0].owner;
                }
                else
                {
                    this.owner = this.units[false][0].owner;
                }
            }
           
            else
            {
                this.owner = 0;
            }
        }
        public bool OppositeOwner(Class_BoardSquare.BoardSquare other)
        {
            if ((this.owner == 1 && other.owner == 2) || (this.owner == 2 && other.owner == 1))
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }
    }
}
