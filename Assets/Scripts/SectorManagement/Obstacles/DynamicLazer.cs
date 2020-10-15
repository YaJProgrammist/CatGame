using UnityEngine;

public class DynamicLazer : Obstacle
{
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
        // TODO
        GameObject.Find("Player").GetComponent<HealthController>().DecreaseLivesCount();
        // TODO
    }
}
