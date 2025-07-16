using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeckManager : MonoBehaviour {

    /*==============Core=============*/
    [Header("デバッグデッキ用カード")]
    [SerializeField] CardData test1;
    [SerializeField] CardData test2;
    [SerializeField] CardData test3;
    [SerializeField] CardData test4;

    Dictionary<CardData, int> deck = new();
    List<CardData> deckList = new();
    PlayerData player;

    void Start() {

        player = TurnManager.Instance.CurrentPlayer;

        // デバッグ用カード枚数を登録
        deck[test1] = 7;
        deck[test2] = 7;
        deck[test3] = 8;
        deck[test4] = 8;

        // 山札を展開→シャッフル→ドロー
        ConvertDictToList(deck);
        ShuffleDeck();
        player.deckList = deckList;
    }

    void Update() {

        if (player != TurnManager.Instance.CurrentPlayer) {
            player = TurnManager.Instance.CurrentPlayer;
        }

        if (player.deckList == null) {
            Start();
        }
    }

        /*=========List展開=========*/
    void ConvertDictToList(Dictionary<CardData, int> dict) {

        CardData[] keys = new CardData[dict.Count];
        dict.Keys.CopyTo(keys, 0);

        for (int i = 0; i < keys.Length; i++) {
            CardData key = keys[i];
            int count = dict[key];

            for (int j = 0; j < count; j++) {
                deckList.Add(key);
            }
        }
    }

    /*=========山札シャッフル=========*/
    void ShuffleDeck() {
        for (int i = 0; i < deckList.Count; i++) {
            int rand = Random.Range(i, deckList.Count);
            (deckList[i], deckList[rand]) = (deckList[rand], deckList[i]);
        }
    }
}