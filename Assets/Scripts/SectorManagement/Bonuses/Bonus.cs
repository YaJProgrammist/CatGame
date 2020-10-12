using UnityEngine;

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
