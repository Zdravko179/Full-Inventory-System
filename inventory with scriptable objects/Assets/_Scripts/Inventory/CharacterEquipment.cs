using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    private Item head, body, hands, accesory;

    public void TryEquipHead()
    {
        head = GlobalClass.item;
    }
    public void TryEquipBody()
    {
        body = GlobalClass.item;
    }
    public void TryEquipHands()
    {
        hands = GlobalClass.item;
    }
    public void TryEquipAccesory()
    {
        accesory = GlobalClass.item;
    }

}
