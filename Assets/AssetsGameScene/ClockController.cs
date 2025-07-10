using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockController : MonoBehaviour
{
    [SerializeField] PlayerData player1;
    [SerializeField] TextMeshProUGUI TurnText;
    [SerializeField] Transform clock2;

    int ClockText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlipClockLoop());
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.turnEnd) {
            ClockText = int.Parse(TurnText.text) + 1;
            TurnText.text = ClockText.ToString();
            player1.turnEnd = false;
        }


    }

    IEnumerator FlipClockLoop() {
        while (true) {
            // 0.8秒待機
            yield return new WaitForSeconds(0.9f);

            // z軸を180度に（瞬間 or アニメーション）
            Vector3 rot = clock2.eulerAngles;
            rot.z = 180;
            clock2.eulerAngles = rot;

            // 0.2秒待機
            yield return new WaitForSeconds(0.1f);

            rot.z = 186;
            clock2.eulerAngles = rot;
        }
    }
}
