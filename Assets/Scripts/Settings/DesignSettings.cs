using System;
using UnityEngine;

[Serializable]
public class DesignSettings
{
    [SerializeField]
    private DesignMode designMode;

    public DesignMode GetDesignMode()
    {
        return designMode;
    }
}
