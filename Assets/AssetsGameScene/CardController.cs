using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] GameObject diceImage;
    [SerializeField] GameObject diceImageResult;
    [SerializeField] RectTransform cardGroup;
    Vector2 originalCanvasPos;

    // Start is called before the first frame update
    void Start()
    {
        originalCanvasPos = cardGroup.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rect = cardGroup.GetComponent<RectTransform>();

        if (diceImage.activeSelf || diceImageResult.activeSelf) {
            cardGroup.anchoredPosition = originalCanvasPos + new Vector2(0f, -110f);
        } else {
            cardGroup.anchoredPosition = originalCanvasPos;
        }
    }
}
