using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemWorld : MonoBehaviour
{
    public int id;
    public int ammount;
    
    private TextMesh ammountText;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = ItemDatabase.Instance.FetchItemById(id).sprite;
        if (ammount > ItemDatabase.Instance.FetchItemById(id).stackLimit) ammount = ItemDatabase.Instance.FetchItemById(id).stackLimit;

        ammountText = GetComponentInChildren<TextMesh>();
        ammountText.text = ammount.ToString();
    }
    float opacity;
    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        GetComponent<SpriteRenderer>().DOColor(Color.white, 1);

    }
    public void UpdateItem(int ammount)
    {   
        if (ammount == 0)
        {
            GetComponent<SpriteRenderer>().DOKill(); //stops tweening when item is destroied
            Destroy(gameObject);
        }
        else
        {
            this.ammount = ammount;
            ammountText.text = this.ammount.ToString();
        }
    }
}
