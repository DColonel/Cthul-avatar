using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleMenuController : MonoBehaviour{

    [SerializeField] GameObject uiGroup;

    void Start() {

    }

    //画面をクリックしたら暗転を解く動作
    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            uiGroup.SetActive(true);
        }
    }
}
