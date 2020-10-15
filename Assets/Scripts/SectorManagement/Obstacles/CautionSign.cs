using UnityEngine;
using UnityEngine.UI;

public class CautionSign : MonoBehaviour
{
    [SerializeField]
    private Sprite usualIcon;

    [SerializeField]
    private Sprite dangerIcon;

    void Start()
    {
        this.GetComponent<Image>().sprite = usualIcon;
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void PutIntoDangerMode()
    {
        this.GetComponent<Image>().sprite = dangerIcon;
    }
}
