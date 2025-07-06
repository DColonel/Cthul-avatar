using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DiceAnimationController : MonoBehaviour
{
    [SerializeField] GameObject diceImage;
    [SerializeField] TextMeshProUGUI diceText;
    [SerializeField] GraphicRaycaster diceRaycaster;
    [SerializeField] AudioSource diceAudioSource;
    [SerializeField] Animator diceAnimation;
    [SerializeField] Image diceImageResult;

    [SerializeField] Sprite[] diceSprites;
    [SerializeField] EventSystem eventSystem;

    global::RayCaster rayCaster;

    //キャラクターを動かすcontrollerに受け渡すための変数
    public int diceResult;
    public bool diceRolled = false;

    // Start is called before the first frame update
    void Start()
    {
        rayCaster = new RayCaster(eventSystem);

    }

    // Update is called once per frame
    void Update()
    {
        //DiceTextにマウスを合わせてたら
        var results = rayCaster.RayCastResults(diceRaycaster);
        if (results.Count > 0 && results[0].gameObject == diceText.gameObject) {
            diceImage.SetActive(true);//DiceImageが見えるように

            if (Input.GetMouseButtonDown(0) && !diceRolled) {
                StartCoroutine(RollDice());
            }
        } else if (!diceRolled) {
            diceImage.SetActive(false);//見えないように

        }
    }

    IEnumerator RollDice() {

        diceAudioSource.Play();
        diceRolled = true;
        yield return new WaitForSeconds(1.6f); // 2秒待つ
        diceResult = Random.Range(1, 7);
        diceAnimation.speed = 0;

        Debug.Log("出目は" + diceResult);

        diceImageResult.gameObject.SetActive(true);
        diceImageResult.sprite = diceSprites[diceResult - 1];
        diceRolled = true;
    }
}
