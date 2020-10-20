using UnityEngine;

/*
 * Stores elements of sector components that form a single design.
 */
public class SectorComponentsSkinFactory : MonoBehaviour
{
    [SerializeField]
    private Sector sectorPrefab;

    [SerializeField]
    private RuntimeAnimatorController _coinAnimatorController;

    [SerializeField]
    private Sprite _rubySprite;

    [SerializeField]
    private Item sectorType;

    public RuntimeAnimatorController CoinAnimatorController
    {
        get
        {
            return _coinAnimatorController;
        }
    }

    public Sprite RubySprite
    {
        get
        {
            return _rubySprite;
        }
    }

    public Sector InstantiateNewSector()
    {
        Sector newSector = Instantiate(sectorPrefab.GetComponent<Sector>());
        newSector.ComponentsSkinFactory = this;

        return newSector;
    }

    public Item GetSectorType()
    {
        return sectorType;
    }
}
