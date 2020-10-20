using System;
using UnityEngine;

[Serializable]
public class StoreDesignModeSettings : DesignDependentSkin
{
    [SerializeField]
    private Color backgroundColor;

    public Color GetBackgroundColor()
    {
        return backgroundColor;
    }
}
