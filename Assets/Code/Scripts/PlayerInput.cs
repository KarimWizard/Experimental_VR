using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Body    Body = null;
    public View    View = null;
    public Hand    Hand = null;

    public KeyCode MoveForward = KeyCode.W;
    public KeyCode MoveBack    = KeyCode.S;
    public KeyCode MoveLeft    = KeyCode.A;
    public KeyCode MoveRight   = KeyCode.D;

    public KeyCode ActionA     = KeyCode.Q;
    public KeyCode ActionB     = KeyCode.E;

    public float Sensitivity = 2.5f;

    private void Update()
    {
        Body.MoveForward (Input.GetKey(MoveForward));
        Body.MoveBack    (Input.GetKey(MoveBack   ));
        Body.MoveLeft    (Input.GetKey(MoveLeft   ));
        Body.MoveRight   (Input.GetKey(MoveRight  ));
        Body.RotationMove(View.RotationViewX()     );

        View.RotateViewX( Input.GetAxis("Mouse X") * Sensitivity);
        View.RotateViewY(-Input.GetAxis("Mouse Y") * Sensitivity);

        if (Input.GetKeyDown(ActionA)) Hand.TakeObject ();
        if (Input.GetKeyDown(ActionB)) Hand.ThrowObject();
    }
}
