using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour // TODO separate visual item and logical item
{
    [SerializeField]
    private string title;

    [SerializeField]
    private Sprite itemSourceSprite;

    [SerializeField]
    private Image itemTargetImage;

    [SerializeField]
    private Text costText;

    [SerializeField]
    private Text titleText;

    [SerializeField]
    private int cost;

    [SerializeField]
    private Item itemId;

    void Start()
    {
        itemTargetImage.sprite = itemSourceSprite;
        costText.text = cost.ToString();
        titleText.text = title;
    }

    public int GetCost()
    {
        return cost;
    }

    public void SetCost(int newCost)
    {
        cost = newCost;
        costText.text = cost.ToString();
    }

    public Item GetItemId()
    {
        return itemId;
    }
}
