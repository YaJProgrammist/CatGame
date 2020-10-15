using UnityEngine;
using UnityEngine.Events;

public class DynamicLazerControllerAffectedUnityEvent : UnityEvent<UnityAction<DynamicLazerController>>
{
}

public class DynamicLazer : Obstacle
{
    public DynamicLazerControllerAffectedUnityEvent DynamicLazerControllerAffected = new DynamicLazerControllerAffectedUnityEvent();

    [SerializeField]
    private SpriteRenderer lazerSpriteRenderer;

    [SerializeField]
    private Sprite cautionSprite;

    [SerializeField]
    private Sprite dangerSprite;

    [SerializeField]
    private Collider2D lazerCollider;

    public void SetCautionMode()
    {
        lazerSpriteRenderer.sprite = cautionSprite;
        lazerCollider.enabled = false;
    }

    public void SetDangerMode()
    {
        lazerSpriteRenderer.sprite = dangerSprite;
        lazerCollider.enabled = true;
    }

    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.PlayerHealthAffected.Invoke((healthController) => healthController.DecreaseLivesCount());
    }
}
