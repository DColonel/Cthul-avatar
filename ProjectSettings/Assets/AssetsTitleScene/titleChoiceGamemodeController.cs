using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class titleChoiceController : MonoBehaviour
{

    //△を動かしてどのゲームモードを選んでるのかわかりやすくするためのscript
    [SerializeField] GraphicRaycaster graphicRaycaster;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] GameObject Titlename;
    GameObject topUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){

        //マウスポジションの下のUIにray飛ばしてる
        PointerEventData pointerData = new PointerEventData(eventSystem) {
            position = Input.mousePosition
        };

        //空List宣言
        List<RaycastResult> results = new List<RaycastResult>();
        //RaycastがpointerDataの位置のUIをresultsに格納
        graphicRaycaster.Raycast(pointerData, results);
        //resultsの0番目をtopUIへ
        if (results.Count > 0) {
            topUI = results[0].gameObject;
        }

        if (topUI != null && topUI != Titlename) {
            //現在位置の保存
            Vector2 pos = textMeshPro.rectTransform.anchoredPosition;
            //新規の座標を代入
            pos.y = topUI.GetComponent<RectTransform>().anchoredPosition.y;
            textMeshPro.rectTransform.anchoredPosition = pos;
        }
    }
}
