using UnityEngine;

/*
 * Obstacle that waites for some time, then starts moving horizontally towards player.
 */
public class Rocket : Obstacle
{
    [SerializeField]
    private GameObject cautionSignsHolder;

    [SerializeField]
    private CautionSign cautionSignPrefab;

    [SerializeField]
    private Rigidbody2D currentRigidbody;

    [SerializeField]
    private float waitingTimeInSec; //time to wait before start moving

    private CautionSign currentCautionSign; //UI sign that warns user about a rocket
    private float timePassedInSec; //time passed since rocket appeared (stops refreshing when rocket starts moving)
    private bool fireIsDone; //if rocket has started moving
    private float sectorHeight;

    public RocketBehavior MovingBehavior { get; set; }

    void Start()
    {
        sectorHeight = SectorManager.GetInstance().GetPlaySpaceHeight();

        currentCautionSign = Instantiate(cautionSignPrefab, cautionSignsHolder.transform);
        currentCautionSign.Show();
        timePassedInSec = 0;
        fireIsDone = false;
        MovingBehavior = new RocketBehaviorUsual();
    }

    //Called when rocket is not seen by the camera
    // !!! Also called when rocket is seen in editor - HIDE SCENE EDITOR TO TEST PROPERLY !!!
    void OnBecameInvisible()
    {
        currentCautionSign.Hide();
    }

    void Update()
    {
        Vector2 currentCautionSignPosition = currentCautionSign.transform.position;

        //Calculate caution sign Y position on canvas so it is on the same horizontal line with rocket on camera        
        currentCautionSignPosition.y = cautionSignsHolder.transform.position.y + this.transform.position.y / sectorHeight * Screen.height;

        currentCautionSign.gameObject.transform.position = currentCautionSignPosition;

        if (fireIsDone)
        {
            return;
        }

        timePassedInSec += Time.deltaTime;

        if (timePassedInSec >= waitingTimeInSec)
        {
            Fire();
        }
    }

    //Refresh moving according to current moving behavior
    public void RefreshMoving()
    {
        MovingBehavior.Move(currentRigidbody);
    }

    //Start moving rocket
    private void Fire()
    {
        fireIsDone = true;
        currentCautionSign.PutIntoDangerMode();
        MovingBehavior.Move(currentRigidbody);
    }

    //Take player's life
    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.OnPlayerHealthAffected?.Invoke((healthController) => healthController.DecreaseLivesCount());
    }
}
