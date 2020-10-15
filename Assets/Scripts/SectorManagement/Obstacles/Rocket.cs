using UnityEngine;

public class Rocket : Obstacle
{
    [SerializeField]
    private GameObject cautionSignsHolder;

    [SerializeField]
    private CautionSign cautionSignPrefab;

    [SerializeField]
    private float waitingTimeInSec;

    private CautionSign currentCautionSign;
    private float timePassedInSec;
    private bool fireIsDone;

    void Start()
    {
        Debug.Log("start");
        currentCautionSign = Instantiate(cautionSignPrefab, cautionSignsHolder.transform);
        currentCautionSign.Show();
        timePassedInSec = 0;
        fireIsDone = false;
    }

    void OnBecameInvisible()
    {
        currentCautionSign.Hide();
    }

    void Update()
    {
        Vector2 currentCautionSignPosition = currentCautionSign.transform.position;
        //Camera.current.OnW
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

    private void Fire()
    {
        fireIsDone = true;
        currentCautionSign.PutIntoDangerMode();
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-6f, 0);
    }

    protected override sealed void MakeImpact()
    {
        // TODO
        GameObject.Find("Player").GetComponent<HealthController>().DecreaseLivesCount();
        // TODO
    }
}
