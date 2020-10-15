using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    [Serializable]
    struct SkinVisualization
    {
        public string skinTitle;
        public Sprite SkinSprite;
        public AnimatorController SkinAnimatorController;
    }

    [SerializeField]
    private List<SkinVisualization> skinVisualizations;

    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;

    [SerializeField]
    private Animator playerAnimator;

    private bool playerSkinIsSet;
    private Item currentPlayerSkin;

    void Start()
    {
        playerSkinIsSet = false;
        RefreshSkin();
    }

    public void RefreshSkin()
    {
        Item newPlayerSkin = DataHolder.GetCurrentPLayerSkin();
        int skinNumber = ItemCategoryManager.GetNumberOfItemInCategory(newPlayerSkin);

        if (playerSkinIsSet == false || currentPlayerSkin != newPlayerSkin)
        {
            SetSkinVisualization(skinNumber);
            currentPlayerSkin = newPlayerSkin;
        }

        playerSkinIsSet = true;
    }

    private void SetSkinVisualization(int skinNumber)
    {
        SkinVisualization skinVisualization = skinVisualizations[skinNumber];
        playerSpriteRenderer.sprite = skinVisualization.SkinSprite;
        playerAnimator.runtimeAnimatorController = skinVisualization.SkinAnimatorController;
    }
}
