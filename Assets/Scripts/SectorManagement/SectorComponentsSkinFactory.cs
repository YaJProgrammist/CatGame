using UnityEditor.Animations;
using UnityEngine;

public class SectorComponentsSkinFactory : MonoBehaviour
{
    [SerializeField]
    private Sector sectorPrefab;

    [SerializeField]
    private AnimatorController _coinAnimatorController;

    [SerializeField]
    private Sprite _rubySprite;

    [SerializeField]
    private AnimatorController _boosterAnimatorController;

    public AnimatorController CoinAnimatorController
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

    public AnimatorController BoosterAnimatorController
    {
        get
        {
            return _boosterAnimatorController;
        }
    }

    public Sector GetNewSector()
    {
        Sector newSector = Instantiate<Sector>(sectorPrefab.GetComponent<Sector>());

        return newSector;
    }
}
