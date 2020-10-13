using UnityEngine;
using UnityEngine.UI;

public abstract class StoreItem : MonoBehaviour 
{
    [SerializeField]
    private string title;

    [SerializeField]
    private Sprite itemSourceSprite;

    [SerializeField]
    private int cost;

    [SerializeField]
    private Item itemId;

    public string GetTitle()
    {
        return title;
    }

    public Sprite GetIcon()
    {
        return itemSourceSprite;
    }

    public int GetCost()
    {
        return cost;
    }

    public Item GetItemId()
    {
        return itemId;
    }

    public abstract bool TryBuy();

    public abstract bool TryApply();
}
