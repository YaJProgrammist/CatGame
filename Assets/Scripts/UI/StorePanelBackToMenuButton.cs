using UnityEngine;

public class StorePanelBackToMenuButton : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.GetInstance().CloseStore();
    }
}
