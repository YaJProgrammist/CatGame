using UnityEngine;
using UnityEngine.Events;

public abstract class Sector : MonoBehaviour
{
    public UnityEvent EndTriggered = new UnityEvent();

    public abstract void Remove();
}
