using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/*
 * Responsible for player lives count.
 */
public class HealthController : MonoBehaviour
{
    //Called when lives count became 0
    public UnityEvent NoLivesLeft = new UnityEvent();

    [SerializeField]
    private Text LivesLeftNumberText; //UI text where lives count is put into

    private int _livesCount; 

    public int LivesCount 
    {
        get 
        {
            return _livesCount;
        }

        private set
        {
            if (value < 0)
            {
                return;
            }

            _livesCount = value;
            LivesLeftNumberText.text = value.ToString();

            if (value == 0)
            {
                NoLivesLeft?.Invoke();
            }
        }
    }

    void Start()
    {
        GameManager gameManager = GameManager.GetInstance();

        //Subscribe to event that performs action on health controller when player health need to be affected
        gameManager.PlayerHealthAffected.AddListener((action) => action(this));

        Reset();
    }

    //Put lives count (etc.) into start position
    public void Reset()
    {
        LivesCount = 1;
    }

    public void IncreaseLivesCount()
    {
        LivesCount++;
    }

    public void DecreaseLivesCount()
    {
        LivesCount--;
    }
}
