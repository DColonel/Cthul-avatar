using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : GameStartEventFinishedController {

    Vector3 offset;
    bool isInitialized = false;

    void OnGameStartCompleteHandler() {

        var currentPlayer = TurnManager.Instance?.CurrentPlayer;
        if (currentPlayer == null) { return; }
        offset = transform.position - currentPlayer.transform.position;
        isInitialized = true;
    }

    void LateUpdate() {

        if (!isInitialized) return;

        var currentPlayer = TurnManager.Instance?.CurrentPlayer;
        if (currentPlayer == null) return;

        transform.position = currentPlayer.transform.position + offset;
    }
}