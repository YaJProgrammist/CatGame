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
        
        player.MoveToStart();
        sectorManager.ClearAll();
        sectorManager.ActivateMenuSector();
        // TODO coins earned take from bonus manager
        // TODO refresh bonus manager coins count + health controller lives count
    }

    private void GameOver()
    {
        player.StopMoving();
        playmodeCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
    }
}
