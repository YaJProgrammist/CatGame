using System;
using UnityEngine;

[Serializable]
public class PlayerSettings
{
    [SerializeField]
    private PlayerMovingSettings playerMovingSettings;

    public PlayerMovingSettings GetMovingSettings()
    {
        return playerMovingSettings;
    }
}
