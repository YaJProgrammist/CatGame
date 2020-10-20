using System;
using UnityEngine;

[Serializable]
public abstract class DesignDependentSkin
{
    [SerializeField]
    private DesignMode designMode;

    public DesignMode GetDesignMode()
    {
        return designMode;
    }
}
