using System;
using UnityEngine;

[Serializable]
public class DynamicLazerSkin : DesignDependentSkin
{

    [SerializeField]
    private Sprite cautionSprite; //sprite to show when lazer is in caution mode (doesn't harm player)

    [SerializeField]
    private Sprite dangerSprite; //sprite to show when lazer is in danger mode (do harm player)

    public Sprite GetCautionSprite()
    {
        return cautionSprite;
    }

    public Sprite GetDangerSprite()
    {
        return dangerSprite;
    }
}
