using System;
using UnityEngine;

[Serializable]
public class BonusesSettings
{
    [SerializeField]
    private RubySettings rubySettings;

    public RubySettings GetRubySettings()
    {
        return rubySettings;
    }
}
