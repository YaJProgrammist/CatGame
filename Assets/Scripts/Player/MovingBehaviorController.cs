using UnityEngine;

/*
 * Player controller that is responsible for its moving behavior.
 */
public class MovingBehaviorController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    private float xDistanceToCamera; //horizontal distance between player and camera (have to be held during player moving)
    private Rigidbody2D playerRigidbody;
    private PlayerMovingBehavior movingBehavior;

    public bool IsMoving { get; private set; }
    public bool IsBoosted { get; private set; } //if boosted behavior is applied

    void Start()
    {
        xDistanceToCamera = mainCamera.transform.position.x - this.transform.position.x;

        playerRigidbody = GetComponent<Rigidbody2D>();
        movingBehavior = new Standing(playerRigidbody);
        IsMoving = false;
        IsBoosted = false;
    }

    void Update()
    {
        if (!IsMoving)
        {
            return;
        }

        if (!IsBoosted && Input.GetButton("Jump"))
        {
            movingBehavior = new Flying(playerRigidbody);
        }

        movingBehavior.Update(); 
        
        MoveCamera();
    }

    //Called once per frame to follow player
    public void MoveCamera()
    {
        Vector3 currentCameraPosition = mainCamera.transform.position;
        currentCameraPosition.x = this.transform.position.x + xDistanceToCamera;
        mainCamera.transform.position = currentCameraPosition;
    }

    public void StartMoving()
    {
        IsMoving = true;

        //If booster is applied then use it
        if (DataHolder.GetIfItemIsApplied(Item.Booster))
        {
            DataHolder.MarkItemAsUnapplied(Item.Booster);
            SwitchToBoost();
            return;
        }

        SwitchToRun();
    }

    public void StopMoving()
    {
        IsMoving = false;
        movingBehavior = new Standing(playerRigidbody);
    }

    public void SwitchToRun()
    {
        movingBehavior = new Running(playerRigidbody);
    }

    public void SwitchToFly()
    {
        movingBehavior = new Flying(playerRigidbody);
    }

    public void SwitchToBoost()
    {
        IsBoosted = true;
        movingBehavior = new Boosted(playerRigidbody);

        //When boost is finished - start running
        ((Boosted)movingBehavior).BoostDone.AddListener(() =>
        {
            SwitchToRun();
            IsBoosted = false;
        });
    }
}
