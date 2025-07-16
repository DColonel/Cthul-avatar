using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEventListener : MonoBehaviour
{
    protected virtual void OnEnable() {
        GameEvents.Instance.OnTurnStart += OnTurnStart;
    }

    protected virtual void OnDisable() {
        GameEvents.Instance.OnTurnStart -= OnTurnStart;
    }

    protected virtual void OnTurnStart(PlayerData player) {
        /*=======override‚µ‚Ä‚Ë======*/
    }
}
