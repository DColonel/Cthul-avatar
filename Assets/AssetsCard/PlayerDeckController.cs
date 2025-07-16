using System.Collections.Generic;
using UnityEngine;

public class PlayerDeckManager : MonoBehaviour {
    [Header("�f�o�b�O�f�b�L�p�J�[�h")]
    [SerializeField] CardData test1;
    [SerializeField] CardData test2;
    [SerializeField] CardData test3;
    [SerializeField] CardData test4;

    Dictionary<CardData, int> deck = new();

    public void CreateDeckFor(PlayerData player) {

        /*===============�J�[�h�o�^==================*/
        var deck = new Dictionary<CardData, int> {
            [test1] = 7,
            [test2] = 7,
            [test3] = 8,
            [test4] = 8
        };

        List<CardData> deckList = ConvertDictToList(deck);
        ShuffleDeck(deckList);
        player.deckList = deckList;
    }

    List<CardData> ConvertDictToList(Dictionary<CardData, int> dict) {
        List<CardData> result = new();
        foreach (var pair in dict) {
            for (int i = 0; i < pair.Value; i++) {
                result.Add(pair.Key);
            }
        }
        return result;
    }

    void ShuffleDeck(List<CardData> deck) {
        for (int i = 0; i < deck.Count; i++) {
            int rand = Random.Range(i, deck.Count);
            (deck[i], deck[rand]) = (deck[rand], deck[i]);
        }
    }
}
