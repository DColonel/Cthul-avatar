using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleBGMController : MonoBehaviour {

    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0) && !audioSource.isPlaying) {
            audioSource.Play();
        }
    }
}
