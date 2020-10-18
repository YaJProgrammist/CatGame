using UnityEngine;

public class PauseGamePanelResumeButton : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.GetInstance().ResumeGame();
    }
}
