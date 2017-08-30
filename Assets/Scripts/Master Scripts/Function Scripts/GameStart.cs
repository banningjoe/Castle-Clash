using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {
    public Class_GameBoard.GameBoard board;
    public Class_GameSettings.GameSettings settings;
	// Use this for initialization
	void Start () {
        board = gameObject.GetComponent<JsonReader>().LoadMap();//load in board with no units
        settings = gameObject.GetComponent<JsonReader>().LoadSettings();//load in settings that accompany board
        setStartLocations();
        //board.AddUnits(settings.p1StartLocation, true, 1, settings.startUnits);//Add to p1 (true)
        //board.AddUnits(settings.p2StartLocation, true, 2, settings.startUnits);//Add to p2 (false)
        board.AddUnits(board.grid[4], true, 2, settings.startUnits);
        board.AddUnits(board.grid[1], true, 1, settings.startUnits);
        board.AddUnits(board.grid[3], true, 1, settings.startUnits);
        board.AddUnits(board.grid[5], true, 1, settings.startUnits);
        board.AddUnits(board.grid[7], true, 1, settings.startUnits);
        board.SetOwner();
        board.Attack(board.grid[4], board.grid[4].boardSquareNeighbours);
        ShowBoard();

    }
    void setStartLocations()
    {
        settings.p1StartLocation = board.grid[settings.p1StartLocationInt];
        settings.p2StartLocation = board.grid[settings.p2StartLocationInt];
    }
    void ShowBoard()
    {
        Debug.Log(board.ToString() + "  [Warrior,Villager]");
    }
}
