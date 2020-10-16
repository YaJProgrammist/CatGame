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
    private Image storeBackground;

    [SerializeField]
    private Text storeCoinsNumberText;

    [SerializeField]
    private List<StoreModeFactory> storeModeFactories;

    private float scaleFactor;
    private List<StoreItemVisualizer> vizualizedItemsList = new List<StoreItemVisualizer>();

    void Start()
    {
        SetStoreMode();
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

    private void SetStoreMode()
    {
        DesignMode currentDesignMode = DataHolder.GetCurrentDesignMode();
        StoreModeFactory factory = GetStoreModeFactoryForDesignMode(currentDesignMode);

        if (factory == null)
        {
            factory = GetStoreModeFactoryForDesignMode(DesignMode.Usual);
        }

        storeBackground.color = factory.GetBackgroundColor();
    }

    private StoreModeFactory GetStoreModeFactoryForDesignMode(DesignMode designMode)
    {
        foreach (StoreModeFactory factory in storeModeFactories)
        {
            if (factory.GetСorrespondingDesignMode() == designMode)
            {
                return factory;
            }
        }

        return null;
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
