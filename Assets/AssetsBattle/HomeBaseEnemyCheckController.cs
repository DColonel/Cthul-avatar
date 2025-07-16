using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HomeBaseEnemyCheckController : GameStartEventFinishedController {

    PlayerData player;

    HomeBaseCreatureData creatureData;

    void OnGameStartCompleteHandler() {

        player = TurnManager.Instance.CurrentPlayer;
    }

    // Update is called once per frame
    void Update() {

        if (player == null) return;
        if (player != TurnManager.Instance.CurrentPlayer) {
            player = TurnManager.Instance.CurrentPlayer;
        }

        if (player.checkCharMoveEnd && !player.creatCreature) {
            creatureData = player.stayMapTile.GetComponent<HomeBaseCreatureData>();
            if (creatureData.player != null) {
                if (creatureData.player != player) {

                    /*
                     �퓬�J�n�p�̏����������BcreatureData.player��player��n���l�ɂ��Ď��s�B
                     */
                }
            }
        }
    }
}
