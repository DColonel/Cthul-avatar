using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeckManager : MonoBehaviour {

    /*==============Core=============*/
    [Header("�f�o�b�O�f�b�L�p�J�[�h")]
    [SerializeField] CardData test1;
    [SerializeField] CardData test2;
    [SerializeField] CardData test3;
    [SerializeField] CardData test4;

    Dictionary<CardData, int> deck = new();
    List<CardData> deckList = new();
    PlayerData player;

    void Start() {

        player = TurnManager.Instance.CurrentPlayer;

        // �f�o�b�O�p�J�[�h������o�^
        deck[test1] = 7;
        deck[test2] = 7;
        deck[test3] = 8;
        deck[test4] = 8;

        // �R�D��W�J���V���b�t�����h���[
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

        /*=========List�W�J=========*/
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

    /*=========�R�D�V���b�t��=========*/
    void ShuffleDeck() {
        for (int i = 0; i < deckList.Count; i++) {
            int rand = Random.Range(i, deckList.Count);
            (deckList[i], deckList[rand]) = (deckList[rand], deckList[i]);
        }
    }
}