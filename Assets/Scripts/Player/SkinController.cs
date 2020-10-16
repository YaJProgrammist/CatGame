using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

/*
 * Responsible for applying correct current skin to player.
 */
public class SkinController : MonoBehaviour
{
    [Serializable]
    struct SkinInfo
    {
        public string skinTitle;
        public Sprite SkinSprite;
        public AnimatorController SkinAnimatorController;
    }

    [SerializeField]
    private List<SkinInfo> skinInfos; //have to be given in the same order that Skin items are given in

    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;

    [SerializeField]
    private Animator playerAnimator;

    private bool playerSkinIsSet; //if player skin was set at least once
    private Item currentPlayerSkin;

    void Start()
    {
        playerSkinIsSet = false;
        RefreshSkin();
    }

    public void RefreshSkin()
    {
        Item newPlayerSkin = DataHolder.GetCurrentPlayerSkin();

        //Get number of skin in skinInfos (same as number of skin in Skin category)
        int skinNumber = ItemCategoryManager.GetNumberOfItemInCategory(newPlayerSkin);

        if (playerSkinIsSet == false || currentPlayerSkin != newPlayerSkin)
        {
            SetSkin(skinNumber);
            currentPlayerSkin = newPlayerSkin;
            playerSkinIsSet = true;
        }
    }

    private void SetSkin(int skinNumber)
    {
        SkinInfo skinInfo = skinInfos[skinNumber];
        playerSpriteRenderer.sprite = skinInfo.SkinSprite;
        playerAnimator.runtimeAnimatorController = skinInfo.SkinAnimatorController;
    }
}
