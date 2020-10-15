using UnityEngine;

public class Rocket : Obstacle
{
    [SerializeField]
    private GameObject cautionSignsHolder;

    [SerializeField]
    private CautionSign cautionSignPrefab;

    [SerializeField]
    private Rigidbody2D currentRigidbody;

    [SerializeField]
    private float waitingTimeInSec;

    private CautionSign currentCautionSign;
    private float timePassedInSec;
    private bool fireIsDone;

    public RocketBehavior MovingBehavior { get; set; }

    void Start()
    {
        currentCautionSign = Instantiate(cautionSignPrefab, cautionSignsHolder.transform);
        currentCautionSign.Show();
        timePassedInSec = 0;
        fireIsDone = false;
        MovingBehavior = new RocketBehaviorUsual();
    }

    //Also called when rocket is seen in editor - HIDE SCENE EDITOR TO TEST PROPERLY
    void OnBecameInvisible()
    {
        currentCautionSign.Hide();
    }

    void Update()
    {
        Vector2 currentCautionSignPosition = currentCautionSign.transform.position;

        currentCautionSignPosition.y = cautionSignsHolder.transform.position.y + this.transform.position.y / 2.211402f * Screen.height; // TODO
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

    public void RefreshMoving()
    {
        MovingBehavior.Move(currentRigidbody);
    }

    private void Fire()
    {
        fireIsDone = true;
        currentCautionSign.PutIntoDangerMode();
        MovingBehavior.Move(currentRigidbody);
    }

    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.PlayerHealthAffected.Invoke((healthController) => healthController.DecreaseLivesCount());
    }
}
