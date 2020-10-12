using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    [SerializeField]
    private string title;

    [SerializeField]
    private Sprite itemSourceSprite;

    [SerializeField]
    private Image itemTargetImage;

    [SerializeField]
    private Text costText;

    [SerializeField]
    private Text titleText;

    public int Cost;

    void Start()
    {
        itemTargetImage.sprite = itemSourceSprite;
        costText.text = Cost.ToString();
        titleText.text = title;
    }

    public void SetNewCost(int newCost)
    {
        Cost = newCost;
        costText.text = Cost.ToString();
    }
}
