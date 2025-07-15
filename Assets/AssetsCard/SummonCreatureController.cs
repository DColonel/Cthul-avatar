using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SummonCreatureController : MonoBehaviour {

    PlayerData player;
    [SerializeField] CardChoiceController cardChoice;

    private void Update() {

        player = TurnManager.Instance.CurrentPlayer;
    }

    public void summonPlayerCreature() {

        var mapTile = player.stayMapTile.GetComponent<HomeBaseCreatureData>();
        mapTile.creatureName = player.hand[(int)cardChoice.playerChoiceCardIndex].cardName;
        mapTile.HP = player.hand[(int)cardChoice.playerChoiceCardIndex].HP;
        mapTile.ST = player.hand[(int)cardChoice.playerChoiceCardIndex].ST;
        mapTile.player = player;

        var creaturePoint = player.stayMapTile.transform.Find("CreaturePoint").GetComponent<SpriteRenderer>();
        creaturePoint.color = new Color(1, 1, 1, 1);
        creaturePoint.sprite = player.hand[(int)cardChoice.playerChoiceCardIndex].artworkField;
        var textPoint = player.stayMapTile.GetComponentInChildren<TextMeshPro>();
        textPoint.color = new Color(1, 1, 1, 1);
        textPoint.text = "20";

        player.checkTurnEnd = true;
    }
}