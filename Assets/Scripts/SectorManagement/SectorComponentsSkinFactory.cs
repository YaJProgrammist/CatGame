﻿using UnityEditor.Animations;
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
    private Item sectorType;

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

    public Sector GetNewSector()
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
