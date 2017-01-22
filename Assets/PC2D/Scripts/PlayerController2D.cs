
using UnityEngine;

/// <summary>
/// This class is a simple example of how to build a controller that interacts with PlatformerMotor2D.
/// </summary>
[RequireComponent(typeof(PlatformerMotor2D))]
public class PlayerController2D : MonoBehaviour
{

    public KeyCode jump;
    public KeyCode dash;
    public KeyCode left;
    public KeyCode right;
    private PlatformerMotor2D _motor;

    // Use this for initialization
    void Start()
    {
        _motor = GetComponent<PlatformerMotor2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Mathf.Abs(Input.GetAxis("BlueHorizontal")) > PC2D.Globals.INPUT_THRESHOLD)
        //{
        //  _motor.normalizedXMovement = Input.GetAxis(PC2D.Input.HORIZONTAL);
        //}
        //else
        //{
        //    _motor.normalizedXMovement = 0;
        //}
        if (Input.GetKey(left))
        {
            _motor.normalizedXMovement = (-1);
        }
        else if (Input.GetKey(right))
        {
            _motor.normalizedXMovement = (1);
        }
        else {
            _motor.normalizedXMovement = (0);
        }

        // Jump?
        if (Input.GetKeyDown(jump))
        {
            _motor.Jump();
        }

        _motor.jumpingHeld = Input.GetKey(jump);

        if (Input.GetAxis("BlueVertical") < -PC2D.Globals.FAST_FALL_THRESHOLD)
        {
            _motor.fallFast = true;
        }
        else
        {
            _motor.fallFast = false;
        }

        if (Input.GetKeyDown(dash))
        {
            _motor.Dash();
        }
    }
}
