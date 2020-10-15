using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    void Awake()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.ObstaclesAffected.AddListener((action) => action(this)); 
    }

    public void HandleCollision()
    {
        MakeImpact();
    }

    protected abstract void MakeImpact();
}
