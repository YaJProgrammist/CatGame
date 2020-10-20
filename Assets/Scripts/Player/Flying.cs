using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using static UnityEngine.InputSystem.PlayerInput;

/*
 * Behavior that pushes player forward-up when button is pressed
 * and pushes it forward-down when button is not pressed.
 * Activated when player doesn't touch the floor.
 */
class Flying : PlayerMovingBehavior
{
    private Vector2 velocityVector; //vector that determines horizontal velocity during this behavior
    private float airJumpYUpStep; //determines vertical speed upwards during this behavior
    private float airJumpYDownStep; //determines vertical speed downwards during this behavior
    private PlayerInput playerInput;
    private bool pushedUp;

    public Flying(Rigidbody2D rigidbody) : base (rigidbody)
    {
        playerInput = InputManager.GetInstance().GetPlayerInput();

        playerInput.currentActionMap["PushUp"].performed += OnPushUp;
        playerInput.currentActionMap["PushDown"].performed += OnPushDown;

        PlayerFlyingSettings settings = SettingsManager.GetInstance().GetPlayerSettings().GetMovingSettings().GetFlyingSettings();

        float horizontalSpeed = settings.GetFlyingHorizontalSpeed();
        velocityVector = new Vector2(horizontalSpeed, 0);

        airJumpYUpStep = settings.GetFlyingUpSpeed();
        airJumpYDownStep = settings.GetFlyingDownSpeed();

        rigidbody.velocity = velocityVector;
        pushedUp = false;
    }

    //Called in behavior controller's Update (once per frame)
    public override sealed void Update()
    {
        if (pushedUp)
        {
            //Push player up
            currentRigidbody.velocity = new Vector2(velocityVector.x, airJumpYUpStep);
        }
        else
        {
            //Push player down
            currentRigidbody.velocity = new Vector2(velocityVector.x, airJumpYDownStep);
        }
    }

    private void OnPushUp(CallbackContext callbackContext)
    {
        pushedUp = true;
    }

    private void OnPushDown(CallbackContext callbackContext)
    {
        pushedUp = false;
    }
}