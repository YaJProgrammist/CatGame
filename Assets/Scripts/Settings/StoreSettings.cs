using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StoreSettings
{
    [SerializeField]
    private List<StoreItemSettings> itemList;

    [SerializeField]
    private List<StoreDesignModeSettings> storeDesignModes;

    public List<StoreItemSettings> GetItemList()
    {
        return itemList;
    }

    public List<StoreDesignModeSettings> GetStoreDesignModes()
    {
        return storeDesignModes;
    }
}
