using UnityEngine;

/*
 * Collider that is driven by user actions.
 * "Main character" of the game.
 */
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private MovingBehaviorController movingBehaviorController;

    [SerializeField]
    private SkinController skinController;

    [SerializeField]
    private HealthController healthController;

    private Vector3 startPlayerPosition; //position of player in main menu

    void Start()
    {
        startPlayerPosition = this.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (TryHandleColliderAsFloor(collision.collider))
        {
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Ignore triggers when boost mode is on
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
   
    //Set properties into state of the game start
    public void Reset()
    {
        StopMoving();
        MoveToStart();
        this.healthController.Reset();
    }

    //Refresh player data (in this case - refresh current player skin)
    public void Refresh()
    {
        skinController.RefreshSkin();
    }

    //Move player to its position in main menu
    private void MoveToStart()
    {
        this.transform.position = startPlayerPosition;
        movingBehaviorController.MoveCamera();
    }

    private bool TryHandleColliderAsFloor(Collider2D collider)
    {
        Floor floor = collider.gameObject.GetComponent<Floor>();

        //If collision happened with floor
        if (floor != null)
        {
            movingBehaviorController.SwitchToRun();

            return true;
        }

        return false;
    }

    private bool TryHandleColliderAsBonus(Collider2D collider)
    {
        Bonus bonus = collider.gameObject.GetComponent<Bonus>();

        //If collision happened with bonus
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

        //If collision happened with obstacle
        if (obstacle != null)
        {
            obstacle.HandleCollision();
            return true;
        }

        return false;
    }
}
