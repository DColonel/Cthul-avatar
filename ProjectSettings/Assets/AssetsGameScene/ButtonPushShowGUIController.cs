using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPushShowGUIController : MonoBehaviour{

    /*=================Core======================*/
    [SerializeField] GameObject button;
    [SerializeField] GameObject hideGroup;
    [SerializeField] GraphicRaycaster raycaster;
    [SerializeField] EventSystem eventSystem;

    PointerEventData pointerData;
    List<RaycastResult> results = new List<RaycastResult>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        /*===============�N���b�N���ꂽ����GUI�̕\����؂�ւ���===================*/
        if (Input.GetMouseButtonDown(0)) {
            pointerData = new PointerEventData(eventSystem);
            pointerData.position = Input.mousePosition;

            results.Clear();
            raycaster.Raycast(pointerData, results);

            /*=====================�\���ς݂Ȃ��\���ɁB���΂�========================*/
            if (results.Count > 1 && results[1].gameObject == button.gameObject && !hideGroup.activeSelf) {
                hideGroup.SetActive(true);
            }else if (results.Count > 1 && results[1].gameObject == button.gameObject && hideGroup.activeSelf) {
                hideGroup.SetActive(false);
            }
        }
    }
}
