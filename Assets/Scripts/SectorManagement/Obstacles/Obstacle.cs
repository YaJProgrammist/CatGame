using UnityEngine;

/*
 * Collider that affects player negatively when it is triggered by player.
 */
public abstract class Obstacle : MonoBehaviour
{
    void Awake()
    {
        GameManager gameManager = GameManager.GetInstance();

        //Listen if obstacles have to be affected by a certain action.
        gameManager.OnObstaclesAffected.AddListener((action) => action(this)); 
    }

    //Called when player has triggered this
    public void HandleCollision()
    {
        MakeImpact();
    }

    //Affect player negatively
    protected abstract void MakeImpact();
}
