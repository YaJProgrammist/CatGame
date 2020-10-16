using UnityEngine;
using UnityEngine.UI;

/*
 * UI image that appears in the way of rocket.
 */
[RequireComponent(typeof(Image))]
public class CautionSign : MonoBehaviour
{
    [SerializeField]
    private Sprite usualIcon; //icon to show when rocket isn't flying

    [SerializeField]
    private Sprite dangerIcon; //icon to show when rocket isn flying

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

    //Called when rocket starts to fly
    public void PutIntoDangerMode()
    {
        this.GetComponent<Image>().sprite = dangerIcon;
    }
}
