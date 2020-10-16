using UnityEngine;

/*
 * Triggers when player has gone through almost all sector length.
 */
public class SectorEndTrigger : MonoBehaviour
{
    [SerializeField]
    private Sector currentSector; //sector that contains current end trigger

    void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();

        //If trigger was triggered by player
        if (player != null)
        {
            currentSector.EndTriggered?.Invoke();
        }
    }
}
