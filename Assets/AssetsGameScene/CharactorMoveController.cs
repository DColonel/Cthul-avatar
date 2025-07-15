using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMoveController : MonoBehaviour {
    [SerializeField] GameObject mapTileGroup;
    [SerializeField] DiceAnimationController diceAnimation;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject diceImageResult;

    float moveSpeed = 5f;
    List<GameObject> MapTiles = new List<GameObject>();
    int currentTileIndex = 0;
    int nextIndex = 0;
    bool isMoving = false;
    Vector3 targetPos;
    Vector3 moveDir;

    PlayerData player;

    //領域の数の取得
    void Start() {
        //for文でぶん回して領域をListに格納
        for (int x = 0; x < mapTileGroup.transform.childCount; x++) {
            Transform mapTileChild = mapTileGroup.transform.GetChild(x);
            MapTiles.Add(mapTileChild.gameObject);
        }
    }

    // Update is called once per frame
    void Update() {

        player = TurnManager.Instance.CurrentPlayer;

        if (diceImageResult.activeSelf && !isMoving) {
            StartCoroutine(MovePlayer(diceAnimation.diceResult));
        }
    }

    IEnumerator MovePlayer(int steps) {
        isMoving = true;
        for (int i = 1; i <= steps; i++) {
            nextIndex = (currentTileIndex + i) % MapTiles.Count;
            Transform walkPoint = MapTiles[nextIndex].transform.Find("WalkPoint");

            if (walkPoint != null) {
                targetPos = walkPoint.position;
                moveDir = (targetPos - transform.position).normalized;

                // X成分の符号で回転を決める（例：右向きが180度、左向きが0度）
                if (moveDir.x < 0) {
                    player.transform.rotation = Quaternion.Euler(0, 0, 0);
                } else {
                    player.transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                yield return StartCoroutine(MoveTile(targetPos));
            }
        }
        currentTileIndex = (currentTileIndex + steps) % MapTiles.Count;

        diceAnimation.diceResult = 0;
        diceAnimation.diceImageResult.gameObject.SetActive(false);
        player.checkCharMoveEnd = true;
        player.stayMapTile = MapTiles[nextIndex];
        isMoving = false;
    }

    public IEnumerator MoveTile(Vector3 walkRoute) {
        while (Vector3.Distance(playerObject.transform.position, targetPos) > 0.06f) {
            playerObject.transform.position = Vector3.MoveTowards(
                playerObject.transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
    }
}