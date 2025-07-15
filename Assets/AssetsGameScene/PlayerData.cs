using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerData : MonoBehaviour {

    /*=================Core===================*/
    public string playerName = "Player1";
    public int sanity = 100;
    public int corruptionLevel = 0;

    /*===============行動管理用bool===============*/
    public bool checkGameStart = false;
    public bool checkTurnStart = false;
    public bool checkCardDrow = false;
    public bool checkCardOver = false;
    public bool checkCardUsed = false;
    public bool checkDiceRoll = false;
    public bool checkCharMoveEnd = false;
    public bool creatCreature = false;
    public bool checkMoveAfter = false;
    public bool checkLostSanity = false;
    public bool checkTurnEnd = false;

    /*================手札とデッキ===============*/
    public List<CardData> deckList = new();
    public List<CardData> hand = new();

    public GameObject stayMapTile;

    void Update() {

        sanity = Mathf.Min(sanity, 100);
        corruptionLevel = Mathf.Min(corruptionLevel, 100);
        sanity = Mathf.Max(sanity, 0);
        corruptionLevel = Mathf.Max(corruptionLevel, 0);
    }

    public void BoolCheck() {

        checkTurnStart = true;
        checkCardDrow = false;
        checkCardOver = false;
        checkCardUsed = false;
        checkDiceRoll = false;
        checkCharMoveEnd = false;
        creatCreature = false;
        checkMoveAfter = false;
        checkLostSanity = false;
        checkTurnEnd = false;
    }
}
