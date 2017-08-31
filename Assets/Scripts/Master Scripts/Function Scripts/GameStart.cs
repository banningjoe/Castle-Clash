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
