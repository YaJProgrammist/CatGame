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

    public PlayerBehaviorMode BehaviorMode { get; private set; }

    void Start()
    {
        xDistanceToCamera = mainCamera.transform.position.x - this.transform.position.x;

        playerRigidbody = GetComponent<Rigidbody2D>();
        movingBehavior = new Standing(playerRigidbody);
        BehaviorMode = PlayerBehaviorMode.Standing;

        InputManager.GetInstance().GetPlayerInput().currentActionMap["PushUp"].performed += _ => OnPushUp();
    }

    void Update()
    {
        if (BehaviorMode == PlayerBehaviorMode.Standing)
        {
            return;
        }

        movingBehavior.Update(); 
        
        MoveCamera();
    }

    public void OnPushUp()
    {
        if (BehaviorMode == PlayerBehaviorMode.Running)
        {
            SwitchToFly();
        }
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
        BehaviorMode = PlayerBehaviorMode.Standing;
        movingBehavior = new Standing(playerRigidbody);
    }

    public void SwitchToRun()
    {
        BehaviorMode = PlayerBehaviorMode.Running;
        movingBehavior = new Running(playerRigidbody);
    }

    public void SwitchToFly()
    {
        BehaviorMode = PlayerBehaviorMode.Flying;
        movingBehavior = new Flying(playerRigidbody);
    }

    public void SwitchToBoost()
    {
        BehaviorMode = PlayerBehaviorMode.Boosted;
        movingBehavior = new Boosted(playerRigidbody);

        //When boost is finished - start running
        ((Boosted)movingBehavior).OnBoostDone +=
            () =>
            {
                SwitchToRun();
            };
    }
}
