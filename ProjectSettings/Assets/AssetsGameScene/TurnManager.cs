using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }

    [SerializeField] PlayerData[] player;

    public int currentTurn = 0;
    int currentPlayerIndex = 0;

    public PlayerData CurrentPlayer => player[currentPlayerIndex];

    // Start is called before the first frame update
    void Start(){

        StartCoroutine(TurnLoop());
    }

    IEnumerator TurnLoop() {
        while (true) {
            player[currentPlayerIndex].checkTurnStart = true;
            player[currentPlayerIndex].checkTurnEnd = false;
            GameEvents.Instance.RaiseTurnStart(CurrentPlayer);

            yield return new WaitUntil(() => player[currentPlayerIndex].checkTurnEnd == true);

            player[currentPlayerIndex].BoolCheck();
            currentPlayerIndex = (currentPlayerIndex + 1) % player.Length;

                if (currentPlayerIndex == 0) {
                currentTurn += 1;
            }
        }
    }
}