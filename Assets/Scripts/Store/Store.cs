using System;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    private RectTransform storeItemListScrollViewContent;

    [SerializeField]
    private RectTransform storeItemPrefab;

    [SerializeField]
    private List<StoreItem> itemList;

    void Start()
    {
        DisplayAllItems();
    }

    private void DisplayAllItems()
    {
        foreach(StoreItem item in itemList)
        {
            for (int i = 0; i < 5; i++)
            {
                DisplayItem(item); // TODO
            }
        }
    }

    private void DisplayItem(StoreItem item)
    {
        RectTransform currentStoreItem = Instantiate(storeItemPrefab, storeItemListScrollViewContent);

    }
}
