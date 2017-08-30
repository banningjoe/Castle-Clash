using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Class_GameBoard : MonoBehaviour
{

    [System.Serializable]
    public class GameBoard
    {
        public Class_BoardSquare.BoardSquare[] grid;

        public void ConvertNeighbours()
        //Maps the string elements in IntNeighbours[x] into their 
        //corresponding BoardSquare object in BoardSquareNeighbors
        {
            for (int i = 0; i < this.grid.Length; i++)  //Outer for loop iterates through BoardSquares
            {
                this.grid[i].boardSquareNeighbours = new Class_BoardSquare.BoardSquare[this.grid[i].intNeighbours.Length]; //Sets size of array BoardSquareNeighbours to be equal to the size of list of IntNeighbours
                for (int j = 0; j < this.grid[i].intNeighbours.Length; j++) //Inner for loop iterates through Neighbours
                {
                    int placeHolderInt = this.grid[i].intNeighbours[j]; //holds the int value of the BoardSquare to be swapped
                    this.grid[i].boardSquareNeighbours[j] = this.grid[placeHolderInt];
                }
            }
        }

        public void AddUnits(Class_BoardSquare.BoardSquare location, bool type, int owner)
        //Adds a new unit to the units array of a boardsquare, and sets the units location as that boardsquare
        {
            Class_Unit.Unit temp = new Class_Unit.Unit(location, type, owner);
            location.units[type].Add(temp);
        }

        public void AddUnits (Class_BoardSquare.BoardSquare location, bool type, int owner, int howMany)
        {
            for (int i = 0; i < howMany; i++)
            {
                Class_Unit.Unit temp = new Class_Unit.Unit(location, type, owner);
                location.units[type].Add(temp);
            }
        }

        public string ToString()
        {
            string s = "";
            for (int i = 0; i < grid.Length; i++)
            {
                s = s + grid[i].ToString();
            }
            return s;
        }
        public void MoveUnits(Class_BoardSquare.BoardSquare start, Class_BoardSquare.BoardSquare finish, bool type, int howMany)
        {
            if (start.units[type].Count >= howMany && ((start.owner == finish.owner) || (finish.owner == 0) ))
            {
                finish.units[type].AddRange(start.units[type].GetRange(0,howMany));
                start.units[type].RemoveRange(0,howMany);
            }
            else
            {
                Debug.Log("Either too many units were chosen or that is not a valid movement");
            }
                
        }
        public void SetOwner()
        {
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i].SetOwner();
            }
        }
        public void Attack(Class_BoardSquare.BoardSquare defense, Class_BoardSquare.BoardSquare[] attackers)
            //1 attack sequence. Checks to see if square is a castle (2 dice) or not (1 die), 
            //and how many of the surrounding squares are owned by the other team to calculate dice.
            // attackers is a list of boardsquares which are owned by the attacker,
            //which are all adjacent to the defense square, and which are in the order from which the attacker would like to use units.
        {
            //setup dice scores
            int defenseDice = 1;
            int attackDice = 0;
            List<int> defenseRolls = new List<int>();
            List<int> attackRolls = new List<int>();
            System.Random rnd = new System.Random();
            for (int i = 0; i < defense.boardSquareNeighbours.Length; i++)
            {
                if (defense.boardSquareNeighbours[i].OppositeOwner(defense))
                {
                    attackDice++;
                }
            }
            if (defense.type == "Castle")
            {
                defenseDice++;
            }
            //setup rolls
            for (int i = 0; i < defenseDice; i++)
            {
                defenseRolls.Add(rnd.Next(1,7));
            }
            for (int i = 0; i < attackDice; i++)
            {
                attackRolls.Add(rnd.Next(1, 7));
            }
            defenseRolls.Sort();
            defenseRolls.Reverse();
            attackRolls.Sort();
            attackRolls.Reverse();
            string x = "";
            string y = "";
            for (int i = 0; i < defenseRolls.Count; i++)
            {
                x = x + defenseRolls[i].ToString() + ", ";
            }
            for (int i = 0; i < attackRolls.Count; i++)
            {
                y = y + attackRolls[i].ToString() + ", ";
            }
            Debug.Log("Defense: " + x);
            Debug.Log("Attack: " + y);
            if (defenseRolls.Count < attackRolls.Count)
            {
                for (int i = 0; i < defenseRolls.Count; i++)
                {
                    if (defenseRolls[i] < attackRolls[i])
                    {
                        defense.units[true].RemoveAt(defense.units[true].Count - 1);
                    }
                    if (defenseRolls[i] > attackRolls[i])
                    {
                        for (int j = 0; j < attackers.Length; j++)
                        {
                            if (attackers[j].units[true].Count > 0)
                            {
                                attackers[j].units[true].RemoveAt(0);
                                break;
                            }
                        }
                    }
                    if (defenseRolls[i] == attackRolls[i])
                    {
                        defense.units[true].RemoveAt(0);
                        for (int j = 0; j < attackers.Length; j++)
                        {
                            if (attackers[j].units[true].Count > 0)
                            {
                                attackers[j].units[true].RemoveAt(0);
                                break;
                            }
                        }
                    }
                    
                }

            }
            else
            {
                for (int i = 0; i < attackRolls.Count; i++)
                {
                    if (defenseRolls[i] < attackRolls[i])
                    {
                        defense.units[true].RemoveAt(0);
                    }
                    if (defenseRolls[i] > attackRolls[i])
                    {
                        for (int j = 0; j < attackers.Length; j++)
                        {
                            if (attackers[j].units[true].Count > 0)
                            {
                                attackers[j].units[true].RemoveAt(0);
                                break;
                            }
                        }
                    }
                    if (defenseRolls[i] == attackRolls[i])
                    {
                        defense.units[true].RemoveAt(0);
                        for (int j = 0; j < attackers.Length; j++)
                        {
                            if (attackers[j].units[true].Count > 0)
                            {
                                attackers[j].units[true].RemoveAt(0);
                                break;
                            }
                        }
                    }

                }
            }
        }
        
    }
}