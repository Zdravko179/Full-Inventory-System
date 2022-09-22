using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public Text statsText;     
    Equipment equipment;

    public void SetEquipment(Equipment equipment) => this.equipment = equipment;

    int headPower, bodyPower, handPower, accesoryPower;
    private void Update()
    {
        int headPower = (equipment.head == null) ? 0 : equipment.head.data.power;
        int bodyPower = (equipment.body == null) ? 0 : equipment.body.data.power;
        int handPower = (equipment.hands == null) ? 0 : equipment.hands.data.power;
        int accesoryPower = (equipment.accesory == null) ? 0 : equipment.accesory.data.power;

        int headDef = (equipment.head == null) ? 0 : equipment.head.data.defense;
        int bodyDef = (equipment.body == null) ? 0 : equipment.body.data.defense;
        int handDef = (equipment.hands == null) ? 0 : equipment.hands.data.defense;
        int accesoryDef = (equipment.accesory == null) ? 0 : equipment.accesory.data.defense;

        int headAg = (equipment.head == null) ? 0 : equipment.head.data.agility;
        int bodyAg = (equipment.body == null) ? 0 : equipment.body.data.agility;
        int handAg = (equipment.hands == null) ? 0 : equipment.hands.data.agility;
        int accesoryAg = (equipment.accesory == null) ? 0 : equipment.accesory.data.agility;

        int headLuck = (equipment.head == null) ? 0 : equipment.head.data.luck;
        int bodyLuck = (equipment.body == null) ? 0 : equipment.body.data.luck;
        int handLuck = (equipment.hands == null) ? 0 : equipment.hands.data.luck;
        int accesoryLuck = (equipment.accesory == null) ? 0 : equipment.accesory.data.luck;

        statsText.text =
            $"STATS \n\n " +
            $"Power: {headPower + bodyPower + handPower + accesoryPower} \n" +
            $"Defense: {headDef+bodyDef+handDef+accesoryDef}\n" +
            $"Agility:{headAg+bodyAg+handAg+accesoryAg}\n" +
            $"Luck: {headLuck+bodyLuck+handLuck+accesoryLuck}";
    }
}
