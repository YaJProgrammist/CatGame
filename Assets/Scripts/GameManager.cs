using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour // TODO singleton ?
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private SectorManager sectorManager;

    [SerializeField]
    private Canvas mainMenuCanvas;

    [SerializeField]
    private Canvas playmodeCanvas;

    [SerializeField]
    private Canvas gameOverCanvas;

    [SerializeField]
    private Store store;

    [SerializeField]
    private Text currentCoinsNumberText;

    void Start()
    {
        HealthController playerHealthController = player.GetComponent<HealthController>();
        playerHealthController.NoLivesLeft.AddListener(GameOver);
        RefreshMainMenuData();
    }

    public void PlayAgain()
    {
        gameOverCanvas.gameObject.SetActive(false);
        ResetGame();
        StartGame();
    }

    public void StartGame()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        playmodeCanvas.gameObject.SetActive(true);
        sectorManager.MoveOn();
        player.StartMoving();
    }

    public void GoToMainMenu()
    {
        playmodeCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);

        RefreshMainMenuData();
        ResetGame();
    }

    public void OpenStore()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        store.Open();
    }

    public void CloseStore()
    {
        player.Refresh();
        RefreshMainMenuData();
        store.Close();
        mainMenuCanvas.gameObject.SetActive(true);
    }

    private void RefreshMainMenuData()
    {
        currentCoinsNumberText.text = DataHolder.GetCurrentCoinsNumber().ToString();
    }

    private void ResetGame()
    {
        player.Reset();
        sectorManager.Reset();
    }

    private void GameOver()
    {
        sectorManager.FinishGame();
        player.StopMoving();
        playmodeCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
    }
}
