using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public UnityEvent NoLivesLeft = new UnityEvent();

    [SerializeField]
    private Text LivesLeftNumberText;

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
        LivesCount = 1; // TODO 5
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
