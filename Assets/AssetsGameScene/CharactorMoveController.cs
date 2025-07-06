using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMoveController : MonoBehaviour {
    [SerializeField] GameObject mapTileGroup;
    [SerializeField] DiceAnimationController diceAnimation;
    [SerializeField] GameObject playerObject;

    float moveSpeed = 5f;
    List<GameObject> MapTiles = new List<GameObject>();
    int currentTileIndex = 0;
    List<Transform> walkRoute = new List<Transform>();

    // Start is called before the first frame update
    void Start() {
        for (int x = 0; x < mapTileGroup.transform.childCount; x++) {
            Transform mapTileChild = mapTileGroup.transform.GetChild(x);
            MapTiles.Add(mapTileChild.gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        if (diceAnimation.diceRolled) {
            int diceResult = diceAnimation.diceResult;
            diceAnimation.diceRolled = false;
            StartCoroutine(MovePlayer(diceResult));
        }
    }

    IEnumerator MovePlayer(int steps) {

        walkRoute.Clear();
        int nextIndex = 0;

        for (int i = 1; i <= steps; i++) {
            nextIndex = (currentTileIndex + i) % MapTiles.Count;
            Transform walkPoint = MapTiles[nextIndex].transform.Find("WalkPoint");

            if (walkPoint != null) {
                yield return StartCoroutine(MoveTile(walkPoint));
            }
        }
        currentTileIndex = nextIndex;
    }

    public IEnumerator MoveTile(Transform walkRoute) {
        Vector3 targetPos = walkRoute.position;
        while (Vector3.Distance(playerObject.transform.position, targetPos) > 0.05f) {
            playerObject.transform.position = Vector3.MoveTowards(
                playerObject.transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
            yield return null; // éüÇÃÉtÉåÅ[ÉÄÇ‹Ç≈ë“Ç¬
        }
        yield return new WaitForSeconds(0.3f); // ÇøÇÂÇ¡Ç∆é~Ç‹ÇÈ
        
    }
}