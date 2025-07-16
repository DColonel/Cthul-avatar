using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartController : MonoBehaviour
{
    [Header("プレイヤープレハブ")]
    [SerializeField] GameObject playerPrefab;

    [Header("スタートに必要なクラス")]
    [SerializeField] PlayerDeckManager deckManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGameRoutine());
    }

    IEnumerator StartGameRoutine() {
        Vector3 pos = new Vector3(0f, 0.8f, 0f);
        var p1 = Instantiate(playerPrefab, pos, Quaternion.identity).GetComponent<PlayerData>();
        var p2 = Instantiate(playerPrefab, pos, Quaternion.identity).GetComponent<PlayerData>();

        deckManager.CreateDeckFor(p1);
        deckManager.CreateDeckFor(p2);

        TurnManager.Instance.SetupPlayers(p1, p2);

        /*========初期化待機=========*/
        yield return null;

        GameEvent.Instance.RaiseGameStartComplete();
        TurnManager.Instance.StartTurnLoop();
    }
}
