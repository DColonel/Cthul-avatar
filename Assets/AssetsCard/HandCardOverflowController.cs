using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandCardOverflowController : GameStartEventFinishedController
{
    /*==============Core===============*/
    [SerializeField] CanvasGroup otherUIGroup;
    [SerializeField] CanvasGroup cardHandUIGroup;

    PlayerData player;

    void OnGameStartCompleteHandler() {

        player = TurnManager.Instance.CurrentPlayer;
    }

    // Update is called once per frame
    void Update() {

        if (player != TurnManager.Instance.CurrentPlayer) {
            player = TurnManager.Instance.CurrentPlayer;
        }

        if (player.hand.Count > 7) {
            /*===========他UIを無効化============*/
            otherUIGroup.interactable = false;
            otherUIGroup.blocksRaycasts = false;
        }

        if (player.hand.Count < 7) {
            /*===========他UIを有効化============*/
            otherUIGroup.interactable = true;
            otherUIGroup.blocksRaycasts = true;
        }
    }
}
