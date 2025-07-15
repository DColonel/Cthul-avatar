using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleMenuController : MonoBehaviour{

    [SerializeField] GameObject uiGroup;

    void Start() {

    }

    //‰æ–Ê‚ğƒNƒŠƒbƒN‚µ‚½‚çˆÃ“]‚ğ‰ğ‚­“®ì
    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            uiGroup.SetActive(true);
        }
    }
}
