using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class titleChoiceController : MonoBehaviour
{

    //���𓮂����Ăǂ̃Q�[�����[�h��I��ł�̂��킩��₷�����邽�߂�script
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

        //�}�E�X�|�W�V�����̉���UI��ray��΂��Ă�
        PointerEventData pointerData = new PointerEventData(eventSystem) {
            position = Input.mousePosition
        };

        //��List�錾
        List<RaycastResult> results = new List<RaycastResult>();
        //Raycast��pointerData�̈ʒu��UI��results�Ɋi�[
        graphicRaycaster.Raycast(pointerData, results);
        //results��0�Ԗڂ�topUI��
        if (results.Count > 0) {
            topUI = results[0].gameObject;
        }

        if (topUI != null && topUI != Titlename) {
            //���݈ʒu�̕ۑ�
            Vector2 pos = textMeshPro.rectTransform.anchoredPosition;
            //�V�K�̍��W����
            pos.y = topUI.GetComponent<RectTransform>().anchoredPosition.y;
            textMeshPro.rectTransform.anchoredPosition = pos;
        }
    }
}
