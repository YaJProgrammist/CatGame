using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StaticLazerSettings
{
    [SerializeField]
    private List<ObstacleAnimatorSkin> designModeSkins;

    public List<ObstacleAnimatorSkin> GetDesignModeSkins()
    {
        return designModeSkins;
    }
}
