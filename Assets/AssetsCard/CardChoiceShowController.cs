using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardChoiceShowController : MonoBehaviour {
    /*==================Core===================*/
    [SerializeField] CardChoiceController cardChoice;
    [SerializeField] SummonCreatureController summon;

    [SerializeField] GameObject cardUpGroup;
    [SerializeField] GameObject cardMoveGroup;

    [SerializeField] Image card;
    [SerializeField] Button buttonYes;
    [SerializeField] Button buttonNo;
    [SerializeField] TextMeshProUGUI textBackGround;

    bool checkIndex = false;
    PlayerData player;

    /*
     * カードの内容を実行する処理どうしようかねえ
     */

    void Start() {
        buttonYes.onClick.AddListener(OnClickedYes);
        buttonNo.onClick.AddListener(OnClickedNo);
    }

    void Update() {

        player = TurnManager.Instance.CurrentPlayer;

        /*==============nullじゃない時の共通処理(大きく見せる)==============*/
        if (cardChoice.playerChoiceCardIndex != null && !checkIndex) {
            cardUpGroup.SetActive(true);
            cardMoveGroup.SetActive(false);
            checkIndex = true;
            card.sprite = player.hand[(int)cardChoice.playerChoiceCardIndex].artworkCard;

            /*=================表示するテキストが状況によって違う==================*/
            if (player.checkCharMoveEnd) {

                textBackGround.text = "このクリーチャーを召喚しますか";
            } else if (player.checkCardDrow && !player.checkCardUsed) {

                textBackGround.text = "このソーサリーを使用しますか";
            }
        }

        if (cardChoice.playerChoiceCardIndex == null && checkIndex) {
            cardUpGroup.SetActive(false);
            cardMoveGroup.SetActive(true);
            checkIndex = false;
        }
    }

    void OnClickedYes() {
        if (player.checkCharMoveEnd) {
            summon.summonPlayerCreature();
        }
        player.hand.RemoveAt((int)cardChoice.playerChoiceCardIndex);
        cardChoice.playerChoiceCardIndex = null;
    }

    void OnClickedNo() {
        cardChoice.playerChoiceCardIndex = null;
    }
}