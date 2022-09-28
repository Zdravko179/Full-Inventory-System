using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class ItemWorld : MonoBehaviour
{
    public int id;
    public int ammount;
    
    public bool canBeTaken { get; private set; }
    private TextMesh ammountText;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = ItemDatabase.Instance.FetchItemById(id).sprite;
        if (ammount > ItemDatabase.Instance.FetchItemById(id).stackLimit) ammount = ItemDatabase.Instance.FetchItemById(id).stackLimit;

        ammountText = GetComponentInChildren<TextMesh>();
        ammountText.text = ammount.ToString();

        canBeTaken = true;
    }
    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        GetComponent<SpriteRenderer>().DOColor(Color.white, 1);

    }
    public void UpdateItem(int ammount)
    {   
        if (ammount == 0)
        {
            StartCoroutine(Destroy());
        }
        else
        {
            StartCoroutine(ReduceAmmount(ammount));
        }
    }
    IEnumerator Destroy()
    {
        transform.DOScale(2, 0.1f);
        yield return new WaitForSeconds(0.1f);
        transform.DOScale(0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().DOKill(); //stops tweening before item is destroied
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }
    IEnumerator ReduceAmmount(int ammount)
    {
        transform.DOScale(2, 0.1f);
        yield return new WaitForSeconds(0.1f);
        this.ammount = ammount;
        ammountText.text = this.ammount.ToString();
        transform.DOScale(1.5f, 0.2f);
    }

    public void DelayCanBeTaken()
    {
        if (canBeTaken) StartCoroutine(CanBeTaken());
        canBeTaken = false;
    }
    IEnumerator CanBeTaken()
    {
        yield return new WaitForSeconds(1f);
        canBeTaken = true;
    }
}
