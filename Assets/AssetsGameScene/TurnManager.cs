using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    public static TurnManager Instance { get; private set; }

    PlayerData[] player;
    public int currentTurn = 0;
    int currentPlayerIndex = 0;

    public PlayerData CurrentPlayer => player[currentPlayerIndex];

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    /*=========プレイヤー登録用メソッド============*/
    public void SetupPlayers(PlayerData p1, PlayerData p2) {
        player = new PlayerData[2] { p1, p2 };
    }

    /*==========スタート処理を受けてから稼働==========*/
    public void StartTurnLoop() {
        StartCoroutine(TurnLoop());
    }

    IEnumerator TurnLoop() {
        while (true) {
            player[currentPlayerIndex].checkTurnStart = true;
            player[currentPlayerIndex].checkTurnEnd = false;

            yield return new WaitUntil(() => player[currentPlayerIndex].checkTurnEnd == true);

            player[currentPlayerIndex].BoolCheck();
            currentPlayerIndex = (currentPlayerIndex + 1) % player.Length;

            if (currentPlayerIndex == 0) {
                currentTurn += 1;
            }
        }
    }
}