using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using static UnityEngine.InputSystem.PlayerInput;
//using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

/* 
 * Holds player input.
 * Singleton.
 */
public class InputManager : MonoBehaviour 
{
    [SerializeField]
    private PlayerInput input;

    public PlayerInput GetPlayerInput()
    {
        return input;
    }

    void Start()
    {
        if (Touchscreen.current != null)
        {
            input.SwitchCurrentControlScheme("Touch", Touchscreen.current);
        }

        if (Keyboard.current != null)
        {
            input.SwitchCurrentControlScheme("Keyboard&Mouse", Keyboard.current);
        }
    }

    //Singleton logic:
    //v ****************************************** v

    private static InputManager instance;

    void Awake()
    {
        EnhancedTouchSupport.Enable();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public static InputManager GetInstance()
    {
        return instance;
    }
    //^ ****************************************** ^
}
