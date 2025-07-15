using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardHandUI : MonoBehaviour {
    [SerializeField] GameObject CardMoveGroup;
    [SerializeField] Image[] cardPoints;
    [SerializeField] Image[] cardHideImage;
    [SerializeField] GameObject CardUpGroup;

    PlayerData player;
    int handCardCount;
    bool showHideImage = false;

    void Start() {
        player = TurnManager.Instance.CurrentPlayer;
    }

    // Update is called once per frame
    void Update() {

        if (player != TurnManager.Instance.CurrentPlayer) {
            player = TurnManager.Instance.CurrentPlayer;
        }

        if (player.checkDiceRoll && !player.checkCharMoveEnd) {
            CardMoveGroup.gameObject.SetActive(false);
        }

        if (player.checkTurnStart && !player.checkCardDrow) {
            CreatHandGUI();
        }

        if (handCardCount != player.hand.Count) {
            HandGUICrear();
        }

        if (player.checkCharMoveEnd && !CardUpGroup.activeSelf) {
            CardMoveGroup.SetActive(true);
            CreatHandGUI();
        }
    }

    void HandGUICrear() {
        for (int i = 0; i < handCardCount; i++) {
            cardPoints[i].sprite = null;
            cardPoints[i].gameObject.SetActive(false);
        }
        CreatHandGUI();
    }

    void CreatHandGUI() {

        for (int i = 0; i < player.hand.Count; i++) {
            cardPoints[i].sprite = player.hand[i].artworkCard;
            cardPoints[i].gameObject.SetActive(true);
            var type = player.hand[i].cardType;

            if (!player.checkDiceRoll && type == CardData.CardType.Creature) {
                showHideImage = true;
            } else if (!player.creatCreature && type == CardData.CardType.Sorcery) {
                showHideImage = true;
            }

            cardHideImage[i].gameObject.SetActive(showHideImage);
        }

        handCardCount = player.hand.Count;
    }
}