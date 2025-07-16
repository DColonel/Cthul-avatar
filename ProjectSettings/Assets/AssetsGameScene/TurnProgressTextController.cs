using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurnProgressTextController : MonoBehaviour {

    [Header("UI Components")]
    [SerializeField] TMP_Text currentText;
    [SerializeField] TMP_Text nextText;
    [SerializeField] Image BackGround;
    [SerializeField] GameObject TurnProgressGroup;

    [Header("Animation Settings")]
    [SerializeField] float animTime = 2f;
    [SerializeField] float moveY = 200f;
    [SerializeField] float fadeStart = 0.6f;
    [SerializeField] float fadeEnd = 0.6f;

    [SerializeField] TurnManager turnManager;

    bool isAnimating = false;
    int lastTurn = -1;

    void Update() {
        if (!isAnimating && turnManager.currentTurn != lastTurn) {
            StartCoroutine(AnimateTurn());
            lastTurn = turnManager.currentTurn;
        }
    }

    IEnumerator AnimateTurn() {
        isAnimating = true;
        TurnProgressGroup.SetActive(true);

        Vector2 basePos = currentText.rectTransform.anchoredPosition;

        // nextTextに新しい数字をセットして上に配置
        nextText.text = turnManager.currentTurn.ToString();
        nextText.rectTransform.anchoredPosition = basePos + new Vector2(0, moveY);
        nextText.alpha = 0f;
        nextText.gameObject.SetActive(true);

        float t = 0f;
        while (t < animTime) {
            t += Time.deltaTime;
            float ratio = t / animTime;

            // currentText を下に動かしながらフェードアウト
            currentText.rectTransform.anchoredPosition = basePos - new Vector2(0, moveY) * ratio;
            currentText.alpha = Mathf.Lerp(fadeStart, fadeEnd, ratio);

            // nextText を上から定位置に移動しながらフェードイン
            nextText.rectTransform.anchoredPosition = basePos + new Vector2(0, moveY * (1 - ratio));
            nextText.alpha = Mathf.Lerp(fadeEnd, fadeStart, ratio);

            yield return null;
        }

        // 1秒待ってから最終処理
        yield return new WaitForSeconds(1f);

        // currentText を更新
        currentText.text = nextText.text;
        currentText.rectTransform.anchoredPosition = basePos;
        currentText.alpha = 1f;

        // nextText は1つ先の数字に更新しつつ非表示にする
        nextText.text = (turnManager.currentTurn + 1).ToString();
        nextText.rectTransform.anchoredPosition = basePos + new Vector2(0, moveY);
        nextText.alpha = 0f;
        nextText.gameObject.SetActive(false);

        TurnProgressGroup.SetActive(false);
        isAnimating = false;
    }
}
