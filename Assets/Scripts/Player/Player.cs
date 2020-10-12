using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private HealthController healthController;

    private PlayerMovingBehavior movingBehavior;
    private Rigidbody2D playerRigidbody;
    private float xDistanceToCamera;
    private Vector3 startPlayerPosition;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

        movingBehavior = new Standing(playerRigidbody);

        xDistanceToCamera = mainCamera.transform.position.x - this.transform.position.x;

        startPlayerPosition = this.transform.position;

        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            return;
        }

        if (Input.GetButton("Jump")) // TODO optimization?
        {
            movingBehavior = new Flying(playerRigidbody);
        }

        movingBehavior.Move();
        MoveCamera();
    }

    private void MoveCamera()
    {
        Vector3 currentCameraPosition = mainCamera.transform.position;
        currentCameraPosition.x = this.transform.position.x + xDistanceToCamera;
        mainCamera.transform.position = currentCameraPosition;
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
        isMoving = true;
        movingBehavior = new Running(playerRigidbody); // TODO if boosted ...
    }

    public void StopMoving()
    {
        isMoving = false;
        movingBehavior = new Standing(playerRigidbody);
    }
   
    public void Reset()
    {
        MoveToStart();
        this.healthController.Reset();
    }

    private void MoveToStart()
    {
        this.transform.position = startPlayerPosition;
        MoveCamera();
    }

    private bool TryHandleColliderAsWall(Collider2D collider)
    {
        Wall wall = collider.gameObject.GetComponent<Wall>();

        if (wall != null)
        {
            movingBehavior = new Running(playerRigidbody);

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

            // TODO or it is better to change health controller from here?

            return true;
        }

        return false;
    }
}
