using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DebugController : MonoBehaviour {
    [SerializeField] GraphicRaycaster raycaster;
    [SerializeField] Image[] images;

    [SerializeField] EventSystem eventSystem;

    PointerEventData pointerData;
    List<RaycastResult> results;
    PlayerData player;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        player = TurnManager.Instance.CurrentPlayer;

        if (Input.GetMouseButtonDown(0)) {
            if (ImageClicked(images[0])) { player.sanity += 5; }
            if (ImageClicked(images[1])) { player.sanity -= 5; }
            if (ImageClicked(images[2])) { player.corruptionLevel += 5; }
            if (ImageClicked(images[3])) { player.corruptionLevel -= 5; }
        }
    }

    public bool ImageClicked(Image image) {

        pointerData = new PointerEventData(eventSystem) {
            position = Input.mousePosition
        };

        results = new List<RaycastResult>();
        raycaster.Raycast(pointerData, results);

        if (results.Count > 1 && results[1].gameObject == image.gameObject){
            Debug.Log(player.sanity);
            return true;
        }
        return false;
    }
}
