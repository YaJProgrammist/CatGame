using UnityEngine;

/*
 * Is generated during the game.
 * Performs some action when "picked up" by player.
 * Disappears when "picked up".
 */
public abstract class Bonus : MonoBehaviour
{
    public void PickUp()
    {
        MakeImpact();
        Remove();
    }

    protected abstract void MakeImpact();

    private void Remove()
    {
        Destroy(gameObject);
    }
}
