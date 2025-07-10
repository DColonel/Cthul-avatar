using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMoveController : MonoBehaviour {
    [SerializeField] GameObject mapTileGroup;
    [SerializeField] DiceAnimationController diceAnimation;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject diceImageResult;
    [SerializeField] PlayerData player1;

    float moveSpeed = 5f;
    List<GameObject> MapTiles = new List<GameObject>();
    int currentTileIndex = 0;
    int nextIndex = 0;
    bool isMoving = false;
    Vector3 targetPos;
    Vector3 moveDir;


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
        if (diceImageResult.activeSelf && !isMoving) {
            StartCoroutine(MovePlayer(diceAnimation.diceResult));
            diceAnimation.diceRolled = false;
        }
    }

    IEnumerator MovePlayer(int steps) {
        isMoving = true;
        for (int i = 1; i <= steps; i++) {
            int nextIndex = (currentTileIndex + i) % MapTiles.Count;
            Transform walkPoint = MapTiles[nextIndex].transform.Find("WalkPoint");

            if (walkPoint != null) {
                targetPos = walkPoint.position + new Vector3(0, 0.4f, 0);
                moveDir = (targetPos - transform.position).normalized;

                // X成分の符号で回転を決める（例：右向きが180度、左向きが0度）
                if (moveDir.x < 0) {
                    player1.transform.rotation = Quaternion.Euler(0, 0, 0);
                } else {
                    player1.transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                yield return StartCoroutine(MoveTile(targetPos));
            }
        }
        currentTileIndex = (currentTileIndex + steps) % MapTiles.Count;

        diceAnimation.diceResult = 0;
        diceAnimation.diceImageResult.gameObject.SetActive(false);
        diceAnimation.diceAnimation.speed = 1;
        isMoving = false;
        player1.turnEnd = true;
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