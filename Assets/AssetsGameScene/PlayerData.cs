using UnityEngine;

public class PlayerData : MonoBehaviour {

    public string playerName = "Player1";
    public int sanity = 100;
    public int corruptionLevel = 0;

    public bool turnEnd = false;

    void Update() {

        sanity = Mathf.Min(sanity, 100);
        corruptionLevel = Mathf.Min(corruptionLevel, 100);
        sanity = Mathf.Max(sanity, 0);
        corruptionLevel = Mathf.Max(corruptionLevel, 0);
    }
}
