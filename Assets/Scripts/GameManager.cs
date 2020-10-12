using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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
    private Canvas storeCanvas;

    void Start()
    {
        HealthController playerHealthController = player.GetComponent<HealthController>();
        playerHealthController.NoLivesLeft.AddListener(GameOver);
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

        ResetGame();
    }

    public void OpenStore()
    {
        storeCanvas.gameObject.SetActive(true);
    }

    public void CloseStore()
    {
        storeCanvas.gameObject.SetActive(false);
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
