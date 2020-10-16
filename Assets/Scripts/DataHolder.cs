using System.Collections.Generic;
using UnityEngine;

static class DataHolder
{
    private static string coinsNumberName = "CoinsNumber";
    private static string initializationDoneName = "InitializationDone";

    static DataHolder()
    {
        if (!PlayerPrefs.HasKey(initializationDoneName) || PlayerPrefs.GetInt(initializationDoneName) == 0)
        {
            SetInitialSettings();
        }
    }

    public static void SetInitialSettings()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt(coinsNumberName, 100);

        SaveItemAsApplied(Item.CatSkin);

        SaveItemAsApplied(Item.KitchenSector);
        SaveItemAsApplied(Item.LivingRoomSector);

        PlayerPrefs.SetInt(initializationDoneName, 1);
    }

    public static void SaveEarnedCoins(int coinsNumber)
    {
        if (PlayerPrefs.HasKey(coinsNumberName))
        {
            coinsNumber += PlayerPrefs.GetInt(coinsNumberName);
        }

        PlayerPrefs.SetInt(coinsNumberName, coinsNumber);
    }

    public static void PutItemIntoStorage(Item item)
    {
        string keyName = GetBoughtKeyForItem(item);

        int prevBoughtCount = 0;

        if (PlayerPrefs.HasKey(keyName))
        {
            prevBoughtCount = PlayerPrefs.GetInt(keyName);
        }

        PlayerPrefs.SetInt(keyName, prevBoughtCount + 1);
    }

    public static bool TryRetrieveBoughtItem(Item item)
    {
        string keyName = GetBoughtKeyForItem(item);

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

    public static int GetItemBoughtNumber(Item item)
    {
        string keyName = GetBoughtKeyForItem(item);

        if (!PlayerPrefs.HasKey(keyName))
        {
            return 0;
        }

        return PlayerPrefs.GetInt(keyName);
    }

    public static void SaveItemAsApplied(Item item)
    {
        if (ItemCategoryManager.GetItemCategory(item) == ItemCategory.Skin && item != GetCurrentPLayerSkin())
        {
            PutAppliedSkinIntoStorage();
        }

        PlayerPrefs.SetInt(GetAppliedKeyForItem(item), 1);
    }

    public static void SaveItemAsUnapplied(Item item)
    {
        PlayerPrefs.SetInt(GetAppliedKeyForItem(item), 0);
    }

    public static bool GetIfItemIsApplied(Item item)
    {
        return (PlayerPrefs.GetInt(GetAppliedKeyForItem(item)) != 0);
    }

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

    public static Item GetCurrentPLayerSkin()
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

    private static string GetBoughtKeyForItem(Item item)
    {
        return item.ToString() + "IsBought";
    }

    private static string GetAppliedKeyForItem(Item item)
    {
        return item.ToString() + "IsApplied";
    }

    private static void PutAppliedSkinIntoStorage()
    {
        Item currentPlayerSkin = GetCurrentPLayerSkin();
        PutItemIntoStorage(currentPlayerSkin);
        SaveItemAsUnapplied(currentPlayerSkin);
    }
}
