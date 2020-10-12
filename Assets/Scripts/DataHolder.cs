using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

static class DataHolder
{
    private static string CoinsNumberName = "CoinsNumber";

    public static void SaveEarnedCoins(int coinsNumber)
    {
        if (PlayerPrefs.HasKey(CoinsNumberName))
        {
            coinsNumber += PlayerPrefs.GetInt(CoinsNumberName);
        }

        PlayerPrefs.SetInt(CoinsNumberName, coinsNumber);
    }

    public static void SaveSpentCoins(int coinsNumber)
    {
        coinsNumber *= -1;

        if (PlayerPrefs.HasKey(CoinsNumberName))
        {
            coinsNumber += PlayerPrefs.GetInt(CoinsNumberName);
        }

        PlayerPrefs.SetInt(CoinsNumberName, coinsNumber);
    }

    public static int GetCurrentCoinsNumber()
    {
        if(!PlayerPrefs.HasKey(CoinsNumberName))
        {
            PlayerPrefs.SetInt(CoinsNumberName, 0);
            return 0;
        }

        return PlayerPrefs.GetInt(CoinsNumberName);
    }

    public static void SaveBoughtItem(Item item)
    {
        // TODO
    }

    public static void SaveAppliedItem(Item item)
    {
        // TODO
    }
}
