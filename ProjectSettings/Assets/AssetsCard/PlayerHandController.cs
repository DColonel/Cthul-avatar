using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerHandController : MonoBehaviour
{
    /*==============Core================*/
    PlayerData player;

    void Start() {
        player = TurnManager.Instance.CurrentPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != TurnManager.Instance.CurrentPlayer) {
            player = TurnManager.Instance.CurrentPlayer;
        }

        if (player.checkTurnStart && !player.checkCardDrow) {
            Draw(1);
            player.checkCardDrow = true;
        }

        if (!player.checkGameStart) {
            Draw(5);
            player.checkGameStart = true;
        }
    }

    /*=========ÉhÉçÅ[èàóù=========*/
    public void Draw(int count) {
        for (int i = 0; i < count; i++) {
            if (player.deckList.Count == 0) return;

            player.hand.Add(player.deckList[0]);
            player.deckList.RemoveAt(0);
        }
    }
}
