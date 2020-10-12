using UnityEngine;

public class SectorEndTrigger : MonoBehaviour
{
    [SerializeField]
    private Sector currentSector;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();

        if (player != null)
        {
            currentSector.EndTriggered?.Invoke();
        }
    }
}
