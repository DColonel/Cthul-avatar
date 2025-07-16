using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandCardOverflowController : MonoBehaviour
{
    /*==============Core===============*/
    [SerializeField] CanvasGroup otherUIGroup;
    [SerializeField] CanvasGroup cardHandUIGroup;

    PlayerData player;

    void Start() {
        player = TurnManager.Instance.CurrentPlayer;
    }

    void Update() {

        if (player != TurnManager.Instance.CurrentPlayer) {
            player = TurnManager.Instance.CurrentPlayer;
        }

        if (player.hand.Count > 7) {
            /*===========‘¼UI‚ð–³Œø‰»============*/
            otherUIGroup.interactable = false;
            otherUIGroup.blocksRaycasts = false;
        }

        if (player.hand.Count < 7) {
            /*===========‘¼UI‚ð—LŒø‰»============*/
            otherUIGroup.interactable = true;
            otherUIGroup.blocksRaycasts = true;
        }
    }
}
