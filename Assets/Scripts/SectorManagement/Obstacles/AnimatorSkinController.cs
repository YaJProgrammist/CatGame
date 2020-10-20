using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AnimatorSkinController : MonoBehaviour
{
    private List<ObstacleAnimatorSkin> differentDesignModeSkins;

    void Start()
    {
        differentDesignModeSkins = GetDesignModeSkins();

        ApplyCurrentDesign();
    }

    protected abstract List<ObstacleAnimatorSkin> GetDesignModeSkins();

    private void ApplyCurrentDesign()
    {
        DesignMode designMode = SettingsManager.GetInstance().GetDesignSettings().GetDesignMode();

        Animator animator = this.GetComponent<Animator>();

        foreach (ObstacleAnimatorSkin skin in differentDesignModeSkins)
        {
            if (skin.GetDesignMode() == designMode)
            {
                animator.runtimeAnimatorController = skin.GetSkinAnimatorController();
                break;
            }
        }
    }
}
