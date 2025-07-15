using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CardChoiceController : MonoBehaviour {

    /*================Core================*/
    [SerializeField] List<Image> cardImages;// 監視対象カード
    [SerializeField] GraphicRaycaster uiRaycaster; // カードが乗っている Canvas の Raycaster
    [SerializeField] EventSystem eventSystem;

    [SerializeField] float hoverOffset = 40f;// 何 px 浮かせるか

    Image hovered;// 今ホバー中のカード
    Vector2 originalPos;//そのカードの元位置

    public int? playerChoiceCardIndex;

    PointerEventData pointerEvent;
    List<RaycastResult> results = new List<RaycastResult>();

    void Update() {
        /*==============マウスの位置をraycast================*/
        pointerEvent = new PointerEventData(eventSystem) {
            position = Input.mousePosition
        };
        results.Clear();
        uiRaycaster.Raycast(pointerEvent, results);

        /*==============UIを獲得================*/
        Image hitImage = null;
        if (results.Count > 0)
            hitImage = results[0].gameObject.GetComponent<Image>();

        /*=============手札Listを参照して対象のカードを浮上==============*/
        if (hitImage != null && cardImages.Contains(hitImage)) {

            /*==================対象が変わったら=================*/
            if (hovered != hitImage) {

                /*================前回のカードを元に戻す===============*/
                ResetHover();

                /*=================対象のカードを指定の数値分浮かす=================*/
                hovered = hitImage;
                originalPos = hovered.rectTransform.anchoredPosition;
                hovered.rectTransform.anchoredPosition = originalPos + new Vector2(0, hoverOffset);
            }

            /*=================クリックしたらint番目のカードを格納================*/
            if (hovered != null && Input.GetMouseButtonDown(0)) {
                playerChoiceCardIndex = cardImages.IndexOf(hovered);
            }

        } else {
            /*================カードを元に戻す===============*/
            ResetHover();
        }
    }

    /*================カードを元に戻す===============*/
    void ResetHover() {
        if (hovered != null) {
            hovered.rectTransform.anchoredPosition = originalPos;
            hovered = null;
        }
    }
}