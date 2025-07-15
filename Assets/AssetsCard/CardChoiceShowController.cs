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
     * �J�[�h�̓��e�����s���鏈���ǂ����悤���˂�
     */

    void Start() {
        buttonYes.onClick.AddListener(OnClickedYes);
        buttonNo.onClick.AddListener(OnClickedNo);
    }

    void Update() {

        player = TurnManager.Instance.CurrentPlayer;

        /*==============null����Ȃ����̋��ʏ���(�傫��������)==============*/
        if (cardChoice.playerChoiceCardIndex != null && !checkIndex) {
            cardUpGroup.SetActive(true);
            cardMoveGroup.SetActive(false);
            checkIndex = true;
            card.sprite = player.hand[(int)cardChoice.playerChoiceCardIndex].artworkCard;

            /*=================�\������e�L�X�g���󋵂ɂ���ĈႤ==================*/
            if (player.checkCharMoveEnd) {

                textBackGround.text = "���̃N���[�`���[���������܂���";
            } else if (player.checkCardDrow && !player.checkCardUsed) {

                textBackGround.text = "���̃\�[�T���[���g�p���܂���";
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