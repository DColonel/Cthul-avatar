using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour
{
    [SerializeField] GameObject diceImage;
    [SerializeField] GameObject diceImageResult;
    [SerializeField] RectTransform cardGroup;
    [SerializeField] Image settingCard;
    [SerializeField] GameObject debugMenu;

    [SerializeField] GraphicRaycaster cardRaycaster;
    [SerializeField] EventSystem eventSystem;

    Vector2 originalCanvasPos;
    RayCaster rayCaster;

    // Start is called before the first frame update
    void Start()
    {
        originalCanvasPos = cardGroup.anchoredPosition;
        rayCaster = new RayCaster(eventSystem);
    }

    // Update is called once per frame
    void Update() {
        RectTransform rect = cardGroup.GetComponent<RectTransform>();

        if (diceImage.activeSelf || diceImageResult.activeSelf) {
            cardGroup.anchoredPosition = originalCanvasPos + new Vector2(0f, -110f);
        } else {
            cardGroup.anchoredPosition = originalCanvasPos;
        }

        var results = rayCaster.RayCastResults(cardRaycaster);
        if (Input.GetMouseButtonDown(0)) {
            if (results.Count > 0 && results[0].gameObject == settingCard.gameObject && !debugMenu.gameObject.activeSelf) {
                debugMenu.gameObject.SetActive(true);
            }else if(results.Count > 0 && results[0].gameObject == settingCard.gameObject && debugMenu.gameObject.activeSelf) {
                debugMenu.gameObject.SetActive(false);
            }
        }
    }
}
