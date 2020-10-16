using UnityEngine;
using UnityEngine.Events;

/*
 * Box with background inside which player can move.
 */
public abstract class Sector : MonoBehaviour
{
    //Called when player almost reached right wall of sector
    public UnityEvent EndTriggered = new UnityEvent();

    //Factory used for generating current sector elements
    public SectorComponentsSkinFactory ComponentsSkinFactory { get; set; }

    public abstract void Remove();
}
