using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Responsible for displaying buyable/applyable items.
 * Singleton.
 */
public class Store : MonoBehaviour
{
    [SerializeField]
    private RectTransform storeItemListScrollViewContent;

    [SerializeField]
    private StoreItemVisualizer itemPanelPrefab;

    [SerializeField]
    private Image storeBackground;

    [SerializeField]
    private Text storeCoinsNumberText;

    private float scaleFactor;
    private List<StoreItemSettings> itemList;
    private List<StoreDesignModeSettings> storeModes;
    private List<StoreItemVisualizer> vizualizedItemsList = new List<StoreItemVisualizer>();

    void Start()
    {
        GameManager.GetInstance().OnStoreOpened += Open;

        itemList = SettingsManager.GetInstance().GetStoreSettings().GetItemList();
        storeModes = SettingsManager.GetInstance().GetStoreSettings().GetStoreDesignModes();

        SetStoreMode();
        DisplayAllItems();
    }

    public void Open()
    {
        RefreshData();
    }

    public void RefreshData()
    {
        storeCoinsNumberText.text = DataHolder.GetCurrentCoinsNumber().ToString();
        RefreshAllItems();
    }

    private void SetStoreMode()
    {
        DesignMode currentDesignMode = SettingsManager.GetInstance().GetDesignSettings().GetDesignMode();
        StoreDesignModeSettings factory = GetStoreModeFactoryForDesignMode(currentDesignMode);

        if (factory == null)
        {
            factory = GetStoreModeFactoryForDesignMode(DesignMode.Usual);
        }

        storeBackground.color = factory.GetBackgroundColor();
    }

    private StoreDesignModeSettings GetStoreModeFactoryForDesignMode(DesignMode designMode)
    {
        foreach (StoreDesignModeSettings factory in storeModes)
        {
            if (factory.GetDesignMode() == designMode)
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

        foreach (StoreItemSettings item in itemList)
        {
             DisplayItem(item);
        }
    }

    private void DisplayItem(StoreItemSettings item)
    {
        StoreItemVisualizer currentStoreItem = Instantiate(itemPanelPrefab, storeItemListScrollViewContent);

        Vector2 currentStoreItemLocalScale = currentStoreItem.transform.localScale;
        currentStoreItemLocalScale.y /= scaleFactor;
        currentStoreItem.transform.localScale = currentStoreItemLocalScale;
        currentStoreItem.OnItemBought += (boughtItem) => RefreshData();
        currentStoreItem.OnItemApplied += (appliedItem) => RefreshAllItems();

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

    //Singleton logic:
    //v ****************************************** v

    private static Store instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public static Store GetInstance()
    {
        return instance;
    }
    //^ ****************************************** ^
}
