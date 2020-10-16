using System;
using UnityEngine;

[Serializable]
public class StoreItem
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

    public bool TryBuy()
    {
        if (!DataHolder.TrySaveSpentCoins(GetCost()))
        {
            return false;
        }

        DataHolder.PutItemIntoStorage(GetItemId());

        return true;
    }

    public bool TryApply()
    {
        if (!DataHolder.TryRetrieveAvailableItem(GetItemId()))
        {
            return false;
        }

        DataHolder.SaveItemAsApplied(GetItemId());

        return true;
    }
}
