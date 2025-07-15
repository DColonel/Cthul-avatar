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

    void Update() {

        player = TurnManager.Instance.CurrentPlayer;

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
