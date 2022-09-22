using UnityEngine;
using DG.Tweening;

public class ItemWorld : MonoBehaviour
{
    public int id;
    public int ammount;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = ItemDatabase.Instance.FetchItemById(id).sprite;
        if (ammount > ItemDatabase.Instance.FetchItemById(id).stackLimit) ammount = ItemDatabase.Instance.FetchItemById(id).stackLimit;
    }
    float opacity;
    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        GetComponent<SpriteRenderer>().DOColor(Color.white, 1);
    }
}
