using UnityEngine;

public class MainMenuPanelResetProgressButton : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.GetInstance().ResetProgress();
    }
}
