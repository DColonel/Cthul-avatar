using System;
using UnityEngine;

public class GameEvents : MonoBehaviour {
    public static GameEvents Instance { get; private set; }

    public event Action<PlayerData> OnTurnStart;
    public event Action<PlayerData> OnTurnEnd;
    public event Action<CardData> OnCardPlayed;
    public event Action<int> OnDiceRolled;

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // ƒV[ƒ“‚Ü‚½‚¬‚½‚¢Žž—p
    }

    public void RaiseTurnStart(PlayerData player) => OnTurnStart?.Invoke(player);
    public void RaiseTurnEnd(PlayerData player) => OnTurnEnd?.Invoke(player);
    public void RaiseCardPlayed(CardData card) => OnCardPlayed?.Invoke(card);
    public void RaiseDiceRolled(int dice) => OnDiceRolled?.Invoke(dice);
}
