using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    private Item_Y head, body, hands, accesory;

    public void TryEquipHead()
    {
        head = GlobalClass_Y.item;
    }
    public void TryEquipBody()
    {
        body = GlobalClass_Y.item;
    }
    public void TryEquipHands()
    {
        hands = GlobalClass_Y.item;
    }
    public void TryEquipAccesory()
    {
        accesory = GlobalClass_Y.item;
    }

}
