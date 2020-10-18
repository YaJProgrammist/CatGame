using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    [SerializeField]
    protected RectTransform panel;

    protected void Hide()
    {
        panel.gameObject.SetActive(false);
    }

    protected void Show()
    {
        panel.gameObject.SetActive(true);
    }
}
