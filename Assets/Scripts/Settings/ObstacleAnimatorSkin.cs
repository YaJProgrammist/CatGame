using System;
using UnityEngine;

[Serializable]
public class ObstacleAnimatorSkin : DesignDependentSkin
{
    [SerializeField]
    private RuntimeAnimatorController skinAnimatorController;

    public RuntimeAnimatorController GetSkinAnimatorController()
    {
        return skinAnimatorController;
    }
}
