using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private MovingBehaviorController movingBehaviorController;

    [SerializeField]
    private SkinController skinController;

    [SerializeField]
    private HealthController healthController;

    private Vector3 startPlayerPosition;

    void Start()
    {
        startPlayerPosition = this.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (TryHandleColliderAsWall(collision.collider))
        {
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (movingBehaviorController.IsBoosted)
        {
            return;
        }

        if (TryHandleColliderAsBonus(collider))
        {
            return;
        }

        if (TryHandleColliderAsObstacle(collider))
        {
            return;
        }
    }

    public void StartMoving()
    {
        movingBehaviorController.StartMoving();
    }

    public void StopMoving()
    {
        movingBehaviorController.StopMoving();
    }
   
    public void Reset()
    {
        StopMoving();
        MoveToStart();
        this.healthController.Reset();
    }

    public void Refresh()
    {
        skinController.RefreshSkin();
    }

    private void MoveToStart()
    {
        this.transform.position = startPlayerPosition;
        movingBehaviorController.MoveCamera();
    }

    private bool TryHandleColliderAsWall(Collider2D collider)
    {
        Wall wall = collider.gameObject.GetComponent<Wall>();

        if (wall != null)
        {
            movingBehaviorController.SwitchToRun();

            return true;
        }

        return false;
    }

    private bool TryHandleColliderAsBonus(Collider2D collider)
    {
        Bonus bonus = collider.gameObject.GetComponent<Bonus>();

        if (bonus != null)
        {
            bonus.PickUp();

            return true;
        }

        return false;
    }

    private bool TryHandleColliderAsObstacle(Collider2D collider)
    {
        Obstacle obstacle = collider.gameObject.GetComponent<Obstacle>();

        if (obstacle != null)
        {
            obstacle.HandleCollision();
            return true;
        }

        return false;
    }
}
