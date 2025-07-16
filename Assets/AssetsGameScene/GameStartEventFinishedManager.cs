using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartEventFinishedController : MonoBehaviour
{

    void Start() {
        GameEvent.Instance.OnGameStartComplete += OnGameStartCompleteHandler;
    }

    void OnDestroy() {
        if (GameEvent.Instance != null) {
            GameEvent.Instance.OnGameStartComplete -= OnGameStartCompleteHandler;
        }
    }

    void OnGameStartCompleteHandler() {
        /*===========overrideしてね==========*/
    }
}