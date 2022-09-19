using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsZ : MonoBehaviour
{
    TextMeshProUGUI statsText;
    public int power, defense, agility, luck;

    void Start()
    {
        statsText = GameObject.Find("StatsText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        statsText.SetText(
            "Power: " + power + "\n" +
            "Defense: " + defense + "\n" +
            "Agility: " + agility + "\n" +
            "Luck: " + luck);
    }
}
