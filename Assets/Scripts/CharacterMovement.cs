using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public VariableJoystick joystick;
    public CharacterController controller;
    public float maxMovementSpeed;
    public float rotaionSpeed;

    public Canvas inputCanvas;
    public bool isJoystick;

    private void Start()
    {
        EnableJoystickInput();
    }

    public void EnableJoystickInput()
    {
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (isJoystick)
        {
            var movementDirection = new Vector3(joystick.Direction.x, 0.0f, joystick.Direction.y);


            if (movementDirection.sqrMagnitude <= 0)
                return;

            var targetDirection = Vector3.RotateTowards(controller.transform.forward,
                movementDirection, rotaionSpeed * Time.deltaTime, 0.0f);

            controller.transform.rotation = Quaternion.LookRotation(targetDirection);
            
            var movementSpeed = maxMovementSpeed * Vector3.Dot(movementDirection, targetDirection);
            controller.SimpleMove(movementDirection * movementSpeed);
        }
    }
}
