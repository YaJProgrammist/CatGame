using UnityEngine;

public class BoosterStoreItem : StoreItem
{
    public override sealed bool TryBuy()
    {
        Debug.Log("try buying");
        if (!DataHolder.TrySaveSpentCoins(GetCost()))
        {
            return false;
        }
        Debug.Log("buying");
        DataHolder.SaveItemAsBought(GetItemId());        

        return true;
    }

    public override sealed bool TryApply()
    {
        if (!DataHolder.TryRetrieveBoughtItem(GetItemId()))
        {
            return false;
        }

        DataHolder.SaveItemAsApplied(GetItemId());

        return true;
    }
}
