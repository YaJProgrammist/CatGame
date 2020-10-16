using UnityEngine;
using UnityEngine.Events;

//Called when controller of current lazer has to be affected by certain action
public class DynamicLazerControllerAffectedUnityEvent : UnityEvent<UnityAction<DynamicLazerController>>
{
}

public class DynamicLazer : Obstacle
{
    //Called when controller of current lazer has to be affected
    public DynamicLazerControllerAffectedUnityEvent DynamicLazerControllerAffected = new DynamicLazerControllerAffectedUnityEvent();

    [SerializeField]
    private SpriteRenderer lazerSpriteRenderer;

    [SerializeField]
    private Sprite cautionSprite; //sprite to show when lazer is in caution mode (doesn't harm player)

    [SerializeField]
    private Sprite dangerSprite; //sprite to show when lazer is in danger mode (do harm player)

    [SerializeField]
    private Collider2D lazerCollider;

    //Set mode in which lazer doesn't harm player
    public void SetCautionMode()
    {
        lazerSpriteRenderer.sprite = cautionSprite;
        lazerCollider.enabled = false;
    }

    //Set mode in which lazer do harm player
    public void SetDangerMode()
    {
        lazerSpriteRenderer.sprite = dangerSprite;
        lazerCollider.enabled = true;
    }

    //Take player's life
    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.PlayerHealthAffected.Invoke((healthController) => healthController.DecreaseLivesCount());
    }
}
