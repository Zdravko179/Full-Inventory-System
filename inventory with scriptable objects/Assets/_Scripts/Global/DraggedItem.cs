using UnityEngine;
using UnityEngine.UI;


public class DraggedItem : MonoBehaviour
{
    public static DraggedItem Instance;
    Image image;
    private void Awake()
    {
        Instance = this;
        image = GetComponent<Image>();
    }
    private void Start()
    {
        Deactivate();
    }
    void Update()
    {
        transform.position = Input.mousePosition;
    }
    public void Activate(Sprite sprite)
    {
        if (image == null) return;
        image.sprite = sprite;
        image.color = new Color(1, 1, 1, 1);
    }
    public void Deactivate()
    {
        if (image == null) return;
        image.color = new Color(1, 1, 1, 0);
    }
}
