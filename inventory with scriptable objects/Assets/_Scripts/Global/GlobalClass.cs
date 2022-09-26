using UnityEngine;

public class GlobalClass : MonoBehaviour
{
    public enum ItemType
    {
        None,
        Helmet,
        BodyArmour,
        Gauntlet,
        Accesory,
        Usable,
        NonUsable
    }
    public static ItemType itemType;
}
