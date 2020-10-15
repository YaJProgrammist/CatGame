using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField]
    private RectTransform storeItemListScrollViewContent;

    [SerializeField]
    private StoreItemVisualizer itemPanelPrefab;

    [SerializeField]
    private List<StoreItem> itemList;

    [SerializeField]
    private Canvas storeCanvas;

    [SerializeField]
    private Text storeCoinsNumberText;

    private float scaleFactor;
    private List<StoreItemVisualizer> vizualizedItemsList = new List<StoreItemVisualizer>();

    void Start()
    {
        DisplayAllItems();
    }

    public void Open()
    {
        storeCanvas.gameObject.SetActive(true);
        RefreshData();
    }

    public void Close()
    {
        storeCanvas.gameObject.SetActive(false);
    }

    public void RefreshData()
    {
        storeCoinsNumberText.text = DataHolder.GetCurrentCoinsNumber().ToString();
        RefreshAllItems();
    }

    private void DisplayAllItems()
    {
        scaleFactor = itemList.Count * itemPanelPrefab.GetComponent<RectTransform>().rect.height / storeItemListScrollViewContent.rect.height;

        Vector2 currentContentLocalScale = storeItemListScrollViewContent.transform.localScale;
        currentContentLocalScale.y = currentContentLocalScale.y * scaleFactor;
        storeItemListScrollViewContent.transform.localScale = currentContentLocalScale;

        foreach (StoreItem item in itemList)
        {
             DisplayItem(item);
        }
    }

    private void DisplayItem(StoreItem item)
    {
        StoreItemVisualizer currentStoreItem = Instantiate(itemPanelPrefab, storeItemListScrollViewContent);

        Vector2 currentStoreItemLocalScale = currentStoreItem.transform.localScale;
        currentStoreItemLocalScale.y /= scaleFactor;
        currentStoreItem.transform.localScale = currentStoreItemLocalScale;
        currentStoreItem.ItemBought.AddListener((boughtItem) => RefreshData());
        currentStoreItem.ItemApplied.AddListener((appliedItem) => RefreshAllItems());

        currentStoreItem.SetStoreItem(item);
        vizualizedItemsList.Add(currentStoreItem);
    }

    private void RefreshAllItems()
    {
        foreach (StoreItemVisualizer item in vizualizedItemsList)
        {
            item.Refresh();
        }
    }
}
