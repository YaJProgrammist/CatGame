using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public void HandleCollision()
    {
        MakeImpact();
    }

    protected abstract void MakeImpact();
}
