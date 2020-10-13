using UnityEngine;

public class MovingBehaviorController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    private float xDistanceToCamera;
    private Rigidbody2D playerRigidbody;
    private PlayerMovingBehavior movingBehavior;

    public bool IsMoving { get; private set; }
    public bool IsBoosted { get; private set; }

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

        if (!IsBoosted && Input.GetButton("Jump")) // TODO optimization?
        {
            movingBehavior = new Flying(playerRigidbody);
        }

        movingBehavior.Move(); 
        
        MoveCamera();
    }

    public void MoveCamera()
    {
        Vector3 currentCameraPosition = mainCamera.transform.position;
        currentCameraPosition.x = this.transform.position.x + xDistanceToCamera;
        mainCamera.transform.position = currentCameraPosition;
    }

    public void StartMoving()
    {
        IsMoving = true;

        if (DataHolder.GetIfItemIsApplied(Item.Booster))
        {
            DataHolder.SaveItemAsUnapplied(Item.Booster);
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

        ((Boosted)movingBehavior).BoostDone.AddListener(() =>
        {
            SwitchToRun();
            IsBoosted = false;
        });
    }
}
