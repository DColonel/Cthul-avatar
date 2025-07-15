using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class titleMesseageClickController : MonoBehaviour
{
    //�^�C�g���ɂ��郁�b�Z�\�W
    [SerializeField] GameObject titleOptionMesseage;
    [SerializeField] GameObject titleCreditsMesseage;

    //��(�I��ł鍀�ڂ�������z)
    [SerializeField] GameObject titleChoiceViewer;

    //�����A�܂��͏����������ڃO���[�v
    [SerializeField] GameObject optionSettingGroup;
    [SerializeField] GameObject CreditsGroup;
    [SerializeField] GameObject titleMesseageGroup;

    //BackText
    [SerializeField] GameObject optionBackText;
    [SerializeField] GameObject creditsBackText;

    [SerializeField] GraphicRaycaster titleRayCaster;
    [SerializeField] GraphicRaycaster optionRayCaster;
    [SerializeField] GraphicRaycaster creditsRayCaster;
    [SerializeField] EventSystem eventSystem;

    RayCaster rayCaster;

    // Start is called before the first frame update
    void Start()
    {
        rayCaster = new RayCaster(eventSystem);
    }

    // Update is called once per frame
    void Update() {

        HideMainUI(titleMesseageGroup, optionSettingGroup, titleChoiceViewer, titleOptionMesseage);//Show�I�v�V����
        HideMainUI(titleMesseageGroup, CreditsGroup, titleChoiceViewer, titleCreditsMesseage);//Show�N���W�b�g
        ShowMainUI(titleMesseageGroup, optionSettingGroup, optionBackText, optionRayCaster);//Hide�I�v�V����
        ShowMainUI(titleMesseageGroup, CreditsGroup, creditsBackText, creditsRayCaster);//Hide�N���W�b�g
    }

    //HideGroup, ShowGroup, titleChoiceViewer, anyone.position.y
    void HideMainUI(GameObject anyHideGroup, GameObject anyShowGroup, GameObject titleChoiceViewer, GameObject titleStartAnyone) {

        if (Input.GetMouseButtonDown(0) && titleChoiceViewer.transform.position.y == titleStartAnyone.transform.position.y) {
            anyHideGroup.GetComponent<CanvasGroup>().alpha = 0f;//alpha0
            anyHideGroup.GetComponent<CanvasGroup>().interactable = false; // UI����s��
            anyHideGroup.GetComponent<CanvasGroup>().blocksRaycasts = false; // ���͂��󂯕t���Ȃ�
            anyShowGroup.SetActive(true);//������������
        }
    }

    //HideGroup, ShowGroup, ShowGrouptoBackText, ShowGrouptoRayCaster
    void ShowMainUI(GameObject anyShowGroup, GameObject anyHideGroup, GameObject backText, GraphicRaycaster ShowtoRayCaster) {

        if (Input.GetMouseButtonDown(0)) {
            var results = rayCaster.RayCastResults(ShowtoRayCaster);
            if (results.Count > 0 && results[0].gameObject == backText.gameObject) {
                anyShowGroup.GetComponent<CanvasGroup>().alpha = 1f;
                anyShowGroup.GetComponent<CanvasGroup>().interactable = true;
                anyShowGroup.GetComponent<CanvasGroup>().blocksRaycasts = true;
                anyHideGroup.SetActive(false);
            }
        }
    }
}
