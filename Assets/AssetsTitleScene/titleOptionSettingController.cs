using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titleOptionSettingController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource bgmSource;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = bgmSource.volume;
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeVolume(float value) {
        bgmSource.volume = value;
    }
}
