using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private FloatingJoystick floatingJoystick;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private float vertical, horizontal, verticalRotation, horizontalRotation;

    private Vector3 playerRotation;

    private void LateUpdate()
    {
        vertical = floatingJoystick.Vertical;
        horizontal = floatingJoystick.Horizontal;

        player.transform.position += new Vector3(horizontal, 0f, vertical) * Time.deltaTime * speed;

        verticalRotation = floatingJoystick.RotationVertical;
        horizontalRotation = floatingJoystick.RotationHorizontal;

        playerRotation = new Vector3(horizontalRotation, 0, verticalRotation);

        if (floatingJoystick.CanRotate)
        {
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation,
                                       Quaternion.LookRotation(playerRotation), rotationSpeed * Time.deltaTime);

            player.HumanoidModel.Run();
        }
        else
        {
            player.HumanoidModel.Idle();
        }
    }
}
