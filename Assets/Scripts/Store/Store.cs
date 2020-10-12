using System;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    private RectTransform storeItemListScrollViewContent;

    [SerializeField]
    private List<StoreItem> itemPrefabsList;

    private float scaleFactor;

    void Start()
    {
        DisplayAllItems();
    }

    private void DisplayAllItems()
    {
        if (itemPrefabsList.Count == 0)
        {
            return;
        }

        scaleFactor = itemPrefabsList.Count * itemPrefabsList[0].GetComponent<RectTransform>().rect.height / storeItemListScrollViewContent.rect.height;

        Vector2 currentContentLocalScale = storeItemListScrollViewContent.transform.localScale;
        currentContentLocalScale.y = currentContentLocalScale.y * scaleFactor;
        storeItemListScrollViewContent.transform.localScale = currentContentLocalScale;

        foreach (StoreItem item in itemPrefabsList)
        {
             DisplayItem(item);
        }
    }

    private void DisplayItem(StoreItem item)
    {
        StoreItem currentStoreItem = Instantiate(item, storeItemListScrollViewContent);

        Vector2 currentStoreItemLocalScale = currentStoreItem.transform.localScale;
        currentStoreItemLocalScale.y /= scaleFactor;
        currentStoreItem.transform.localScale = currentStoreItemLocalScale;
    }
}
