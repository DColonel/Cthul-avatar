using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HomeBaseEnemyCheckController : MonoBehaviour{

    PlayerData player;

    HomeBaseCreatureData creatureData;

    // Update is called once per frame
    void Update(){

        player = TurnManager.Instance.CurrentPlayer;

        if (player.checkCharMoveEnd && !player.creatCreature) {
            creatureData = player.stayMapTile.GetComponent<HomeBaseCreatureData>();
            if (creatureData.player != null) {
                if (creatureData.player != player) {

                    /*
                     戦闘開始用の処理を書く。creatureData.playerとplayerを渡し値にして実行。
                     */
                }
            }
        }
    }
}
