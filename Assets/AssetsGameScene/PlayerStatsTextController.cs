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

    PlayerData player;

    int lastSanity = -99999;
    int lastCorruptionLevel = -99999;

    // Start is called before the first frame update
    void Start() {
        playerName.text = player.playerName;
        corruptionLevelSlider.minValue = 0;
        corruptionLevelSlider.maxValue = 100;
    }

    // Update is called once per frame
    void Update() {

        player = TurnManager.Instance.CurrentPlayer;

        if (player.sanity != lastSanity) {
            sanityNum.text = player.sanity.ToString();
            lastSanity = player.sanity;
        }

        if (player.corruptionLevel != lastCorruptionLevel) {
            corruptionLevelSlider.value = (float)player.corruptionLevel;
            lastCorruptionLevel = player.corruptionLevel;
        }

        if (player.corruptionLevel > 49) {
            handleImage.sprite = warningSprite;
        } else {
            handleImage.sprite = normalSprite;
        }
    }
}
