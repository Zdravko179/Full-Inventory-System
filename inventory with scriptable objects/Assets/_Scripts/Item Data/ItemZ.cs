using UnityEngine;


[CreateAssetMenu(fileName = "ItemZ", menuName = "Item")]
public class ItemZ : ScriptableObject
{
    [HideInInspector] public int id;
    public new string name;
    [TextArea] public string description;
    public GlobalClass_Y.ItemType itemType;
    public Sprite sprite;
    public int stackLimit = 1;
    [Range(1, 3)] public int rarity = 1;

    [Header("Usable")]
    public int healAmount;
    public int damageAmount;

    [Header("Stats")]
    public int power;
    public int defense;
    public int agility;
    public int luck;
}