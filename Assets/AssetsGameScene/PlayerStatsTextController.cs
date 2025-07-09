using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsTextController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] TextMeshProUGUI sanityNum;

    PlayerData playerData = new PlayerData();

    // Start is called before the first frame update
    void Start()
    {
        playerName.text = playerData.playerName;
        sanityNum.text = playerData.sanity.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
