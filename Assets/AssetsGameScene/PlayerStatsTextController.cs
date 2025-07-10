using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsTextController : MonoBehaviour {
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] TextMeshProUGUI sanityNum;
    [SerializeField] Slider corruptionLevelSlider;

    [SerializeField] Image handleImage;
    [SerializeField] Sprite warningSprite;
    [SerializeField] Sprite normalSprite;

    [SerializeField] PlayerData player1;

    int lastSanity = -99999;
    int lastCorruptionLevel = -99999;

    // Start is called before the first frame update
    void Start() {
        playerName.text = player1.playerName;
        corruptionLevelSlider.minValue = 0;
        corruptionLevelSlider.maxValue = 100;
    }

    // Update is called once per frame
    void Update() {
        if (player1.sanity != lastSanity) {
            sanityNum.text = player1.sanity.ToString();
            lastSanity = player1.sanity;
        }

        if (player1.corruptionLevel != lastCorruptionLevel) {
            corruptionLevelSlider.value = (float)player1.corruptionLevel;
            lastCorruptionLevel = player1.corruptionLevel;
        }

        if (player1.corruptionLevel > 49) {
            handleImage.sprite = warningSprite;
        } else {
            handleImage.sprite = normalSprite;
        }
    }
}
