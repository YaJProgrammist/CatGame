using System.Collections.Generic;
using UnityEngine;

/*
 * Stores player progress, settings etc. during the game and between game loads.
 */
static class DataHolder
{
    private static string distanceRecordName = "DistanceRecord"; //name of distance record key
    private static string coinsNumberName = "CoinsNumber"; //name of total coins number key
    private static string initializationDoneName = "InitializationDone"; //name of initialization done key
    private static string designModeName = "DesignMode"; //name of design mode key

    static DataHolder()
    {
        if (!PlayerPrefs.HasKey(initializationDoneName) || PlayerPrefs.GetInt(initializationDoneName) == 0)
        {
            SetInitialSettings();
        }
    }

    //Called on first game load
    public static void SetInitialSettings()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetFloat(distanceRecordName, 0);

        PlayerPrefs.SetInt(coinsNumberName, 100);

        MarkItemAsApplied(Item.CatSkin);

        MarkItemAsApplied(Item.KitchenSector);
        MarkItemAsApplied(Item.LivingRoomSector);

        PlayerPrefs.SetInt(initializationDoneName, 1);
    }

    public static void SaveDistanceRecord(float newDistance)
    {
        if (!PlayerPrefs.HasKey(distanceRecordName))
        {
            PlayerPrefs.SetFloat(distanceRecordName, newDistance);
            return;
        }

        float prevRecord = PlayerPrefs.GetFloat(distanceRecordName);

        if (prevRecord < newDistance)
        {
            PlayerPrefs.SetFloat(distanceRecordName, newDistance);
        }
    }

    //Add coins amount to storage
    public static void SaveEarnedCoins(int coinsNumber)
    {
        if (PlayerPrefs.HasKey(coinsNumberName))
        {
            coinsNumber += PlayerPrefs.GetInt(coinsNumberName);
        }

        PlayerPrefs.SetInt(coinsNumberName, coinsNumber);
    }

    //Increments number of given items in the storage
    public static void PutItemIntoStorage(Item item)
    {
        string keyName = GetAvailableKeyForItem(item);

        int prevBoughtCount = 0;

        if (PlayerPrefs.HasKey(keyName))
        {
            prevBoughtCount = PlayerPrefs.GetInt(keyName);
        }

        PlayerPrefs.SetInt(keyName, prevBoughtCount + 1);
    }

    //Attempts to remove one copy of item from storage. 
    //Returns if operation was possible.
    public static bool TryRetrieveAvailableItem(Item item)
    {
        string keyName = GetAvailableKeyForItem(item);

        if (!PlayerPrefs.HasKey(keyName))
        {
            return false;
        }

        int prevBoughtCount = PlayerPrefs.GetInt(keyName);

        if (prevBoughtCount == 0)
        {
            return false;
        }

        PlayerPrefs.SetInt(keyName, prevBoughtCount - 1);

        return true;
    }

    //Returns count of given items in storage
    public static int GetItemAvailableNumber(Item item)
    {
        string keyName = GetAvailableKeyForItem(item);

        if (!PlayerPrefs.HasKey(keyName))
        {
            return 0;
        }

        return PlayerPrefs.GetInt(keyName);
    }

    public static void MarkItemAsApplied(Item item)
    {
        if (ItemCategoryManager.GetItemCategory(item) == ItemCategory.Skin && item != GetCurrentPlayerSkin())
        {
            PutAppliedSkinIntoStorage();
        }

        PlayerPrefs.SetInt(GetAppliedKeyForItem(item), 1);
    }

    public static void MarkItemAsUnapplied(Item item)
    {
        PlayerPrefs.SetInt(GetAppliedKeyForItem(item), 0);
    }

    public static bool GetIfItemIsApplied(Item item)
    {
        return (PlayerPrefs.GetInt(GetAppliedKeyForItem(item)) != 0);
    }

    //Attempts to remove given amount of coins from storage.
    //Returns if operation was possible.
    public static bool TrySaveSpentCoins(int coinsNumber)
    {
        coinsNumber *= -1;

        if (PlayerPrefs.HasKey(coinsNumberName))
        {
            coinsNumber += PlayerPrefs.GetInt(coinsNumberName);
        }

        if (coinsNumber < 0)
        {
            return false;
        }

        PlayerPrefs.SetInt(coinsNumberName, coinsNumber);

        return true;
    }

    public static int GetCurrentCoinsNumber()
    {
        if(!PlayerPrefs.HasKey(coinsNumberName))
        {
            PlayerPrefs.SetInt(coinsNumberName, 0);
            return 0;
        }

        return PlayerPrefs.GetInt(coinsNumberName);
    }

    public static Item GetCurrentPlayerSkin()
    {
        List<Item> skins = ItemCategoryManager.GetAllItemsInCategory(ItemCategory.Skin);

        foreach (Item skin in skins)
        {
            if (GetIfItemIsApplied(skin))
            {
                return skin;
            }
        }

        Item defaultItem = ItemCategoryManager.GetDefaultItemInCategory(ItemCategory.Skin);
        PlayerPrefs.SetInt(GetAppliedKeyForItem(defaultItem), 1);
        return defaultItem;
    }

    public static DesignMode GetCurrentDesignMode()
    {
        if (!PlayerPrefs.HasKey(designModeName))
        {
            PlayerPrefs.SetInt(designModeName, (int)DesignMode.Usual);
            return DesignMode.Usual;
        }

        return (DesignMode)PlayerPrefs.GetInt(designModeName);
    }

    //Builds key that contains value "if item is available"
    private static string GetAvailableKeyForItem(Item item)
    {
        return item.ToString() + "IsAvailable";
    }

    //Builds key that contains value "if item is applied"
    private static string GetAppliedKeyForItem(Item item)
    {
        return item.ToString() + "IsApplied";
    }

    //"Takes" current player skin "off" and stores it
    private static void PutAppliedSkinIntoStorage()
    {
        Item currentPlayerSkin = GetCurrentPlayerSkin();
        PutItemIntoStorage(currentPlayerSkin);
        MarkItemAsUnapplied(currentPlayerSkin);
    }
}
