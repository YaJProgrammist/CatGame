using System;
using UnityEngine;

[Serializable]
public class RubySettings
{
    [SerializeField]
    public int coinsCost;

    public RubySettings()
    {
        coinsCost = 5;
    }

    public int GetCoinsCost()
    {
        return coinsCost;
    }
}
