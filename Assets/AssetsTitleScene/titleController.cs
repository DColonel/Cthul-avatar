using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class titleController : MonoBehaviour{

    [SerializeField] TextMeshProUGUI tmpText;//Text
    [SerializeField] Image blackoutImage;//画像
    int blinkDuration = 1;//文字の明滅に必要な秒数

    void Start(){

        StartCoroutine(BlinkText());
    }

    //画面をクリックしたら暗転を解く動作
    void Update(){

        if (Input.GetMouseButtonDown(0)) {
            blackoutImage.gameObject.SetActive(false);
            tmpText.gameObject.SetActive(false);
        }
    }

    //明滅を繰り返す動作。IEnumeratorは未だに理解できない
    //Time.deltaTimeは現在のフレーム数に対して1フレームが何秒か教えてくれるらしい
    IEnumerator BlinkText(){

        while (true) {
            for (float t = 0; t <= 1; t += Time.deltaTime / blinkDuration) {
                SetAlpha(t);
                yield return null;
            }
            for (float t = 1; t >= 0; t -= Time.deltaTime / blinkDuration) {
                SetAlpha(t);
                yield return null;
            }
        }
    }

    void SetAlpha(float alpha) {
        Color c = tmpText.color;
        c.a = alpha;
        tmpText.color = c;
    }
}
