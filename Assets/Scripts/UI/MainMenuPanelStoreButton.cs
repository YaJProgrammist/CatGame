using UnityEngine;

public class MainMenuPanelStoreButton : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.GetInstance().OpenStore();
    }
}
