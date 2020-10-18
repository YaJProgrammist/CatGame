public class StorePanelController : UIPanel
{
    void Start()
    {
        UIManager uiManager = UIManager.GetInstance();
        uiManager.OnStoreOpened += Show;
        uiManager.OnStoreClosed += Hide;
    }
}
