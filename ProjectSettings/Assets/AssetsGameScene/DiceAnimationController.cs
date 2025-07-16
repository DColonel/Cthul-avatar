using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DiceAnimationController : MonoBehaviour
{
    /*===============Core================*/
    [SerializeField] GameObject diceImage;
    [SerializeField] TextMeshProUGUI diceText;
    [SerializeField] GraphicRaycaster diceRaycaster;
    [SerializeField] AudioSource diceAudioSource;
    [SerializeField] public Animator diceAnimation;
    [SerializeField] public Image diceImageResult;
    [SerializeField] Sprite[] diceSprites;
    [SerializeField] GameObject cardMoveGroup;
    [SerializeField] GameObject cardHideGroup;
    [SerializeField] EventSystem eventSystem;

    global::RayCaster rayCaster;
    bool mouseOnDice = false;
    PlayerData player;

    //キャラクターを動かすcontrollerに受け渡すための変数
    public int diceResult;

    // Start is called before the first frame update
    void Start()
    {
        player = TurnManager.Instance.CurrentPlayer;
        rayCaster = new RayCaster(eventSystem);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != TurnManager.Instance.CurrentPlayer) {
            player = TurnManager.Instance.CurrentPlayer;
        }

        //DiceTextにマウスを合わせてたら
        var results = rayCaster.RayCastResults(diceRaycaster);
        if (results.Count > 0 && results[0].gameObject == diceText.gameObject) {
            diceImage.SetActive(true);//DiceImageが見えるように
            cardMoveGroup.SetActive(false);
            cardHideGroup.SetActive(false);
            mouseOnDice = true;

            if (Input.GetMouseButtonDown(0) && !player.checkDiceRoll) {
                StartCoroutine(RollDice());
                player.checkDiceRoll = true;
            }
        }
        if (results.Count > 0 && results[0].gameObject != diceText.gameObject && mouseOnDice && !player.checkDiceRoll) {
            diceImage.SetActive(false);//見えないように
            cardMoveGroup.SetActive(true);
            cardHideGroup.SetActive(true);
            mouseOnDice = false;
        }

        if (player.checkCharMoveEnd) {
            diceText.gameObject.SetActive(false);
            diceImage.SetActive(false);
        }

        if (player.checkTurnStart && !player.checkCardOver) {
            diceText.gameObject.SetActive(true);
        }
    }

    IEnumerator RollDice() {

        diceAudioSource.Play();
        yield return new WaitForSeconds(1.6f); // 2秒待つ
        diceResult = Random.Range(1, 7);
        diceImageResult.gameObject.SetActive(true);
        diceImageResult.sprite = diceSprites[diceResult - 1];
    }
}
