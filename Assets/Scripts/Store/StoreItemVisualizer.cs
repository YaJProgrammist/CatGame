using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemAppliedUnityEvent : UnityEvent<Item>
{
}

public class ItemBoughtUnityEvent : UnityEvent<Item>
{
}

public class StoreItemVisualizer : MonoBehaviour 
{

    public ItemAppliedUnityEvent ItemApplied = new ItemAppliedUnityEvent();
    public ItemBoughtUnityEvent ItemBought = new ItemBoughtUnityEvent();

    [SerializeField]
    private Image itemTargetImage;

    [SerializeField]
    private Text costText;

    [SerializeField]
    private Text titleText;

    [SerializeField]
    private Button buyButton;

    [SerializeField]
    private Button applyButton;

    private StoreItem storeItem;

    public void SetStoreItem(StoreItem item)
    {
        storeItem = item;

        titleText.text = item.GetTitle();
        itemTargetImage.sprite = item.GetIcon();
        costText.text = item.GetCost().ToString();

        buyButton.onClick.AddListener(BuyButtonOnClick);
        applyButton.onClick.AddListener(ApplyButtonOnClick);
    }

    public void Refresh()
    {
        if (storeItem == null)
        {
            return;
        }

        if (DataHolder.GetIfItemIsApplied(storeItem.GetItemId()))
        {
            SwitchToApply();
            applyButton.interactable = false;
            return;
        }

        if (DataHolder.GetItemAvailableNumber(storeItem.GetItemId()) > 0)
        {
            SwitchToApply();
            return;
        }

        SwitchToBuy();
    }

    private void SwitchToBuy()
    {
        buyButton.gameObject.SetActive(true);
        applyButton.gameObject.SetActive(false);
    }

    private void SwitchToApply()
    {
        buyButton.gameObject.SetActive(false);
        applyButton.gameObject.SetActive(true);
        applyButton.interactable = true;
    }

    private void BuyButtonOnClick()
    {
        if (!storeItem.TryBuy())
        {
            return; // TODO error not enough money
        }

        SwitchToApply();

        ItemBought?.Invoke(storeItem.GetItemId());
    }

    private void ApplyButtonOnClick()
    {
        if (!storeItem.TryApply())
        {
            return; // TODO error not bought
        }

        applyButton.interactable = false;

        ItemApplied?.Invoke(storeItem.GetItemId()) ;
    }
}
