using UnityEngine;

static class DataHolder
{
    private static string coinsNumberName = "CoinsNumber";

    public static void SaveEarnedCoins(int coinsNumber)
    {
        if (PlayerPrefs.HasKey(coinsNumberName))
        {
            coinsNumber += PlayerPrefs.GetInt(coinsNumberName);
        }

        PlayerPrefs.SetInt(coinsNumberName, coinsNumber);
    }

    public static void SaveItemAsBought(Item item)
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

    private static string GetBoughtKeyForItem(Item item)
    {
        return item.ToString() + "IsBought";
    }

    private static string GetAppliedKeyForItem(Item item)
    {
        return item.ToString() + "IsApplied";
    }
}
