using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleMenuController : MonoBehaviour{

    [SerializeField] GameObject uiGroup;

    void Start() {

    }

    //��ʂ��N���b�N������Ó]����������
    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            uiGroup.SetActive(true);
        }
    }
}
