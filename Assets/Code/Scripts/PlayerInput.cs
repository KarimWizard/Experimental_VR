using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Transform ObjBody = null;
    [SerializeField] private Transform ObjView = null;
    [SerializeField] private Transform ObjHand = null;

    private Body Body = null;
    private View View = null;
    private Hand Hand = null;

    [SerializeField] private KeyCode MoveForward = KeyCode.W;
    [SerializeField] private KeyCode MoveBack = KeyCode.S;
    [SerializeField] private KeyCode MoveLeft = KeyCode.A;
    [SerializeField] private KeyCode MoveRight = KeyCode.D;

    [SerializeField] private KeyCode HandActionA = KeyCode.Mouse0;
    [SerializeField] private KeyCode HandActionB = KeyCode.Mouse1;

    [SerializeField] private float SensitivityMouse = 2.5f;

    private void Start()
    {
        Body = ObjBody.GetComponent<Body>();
        View = ObjView.GetComponent<View>();
        Hand = ObjHand.GetComponent<Hand>();
    }
    private void Update()
    {
        InputBody();
        InputView();
        InputHand();
    }

    private void InputBody() 
    { 
        float MoveF = Input.GetKey(MoveForward) ? 1.0f : 0.0f;
        float MoveB = Input.GetKey(MoveBack) ? 1.0f : 0.0f;
        float MoveL = Input.GetKey(MoveLeft) ? 1.0f : 0.0f;
        float MoveR = Input.GetKey(MoveRight) ? 1.0f : 0.0f;

        Vector2 DirectionStep = new Vector2();
        DirectionStep.x = MoveR - MoveL;
        DirectionStep.y = MoveF - MoveB;
        DirectionStep = DirectionStep.normalized;

        Body.PositionMove(DirectionStep, View.RotationViewX());
    }
    private void InputView() 
    { 
        View.RotateViewX( Input.GetAxis("Mouse X") * SensitivityMouse);
        View.RotateViewY(-Input.GetAxis("Mouse Y") * SensitivityMouse);
    }
    private void InputHand() 
    { 
        if (Input.GetKeyDown(HandActionA))
        {
            Hand.RayCasting(true);
        }
        if (Input.GetKeyUp(HandActionA))
        {
            Hand.TakeObject();

            Hand.RayCasting(false);
        }

        if (Input.GetKeyDown(HandActionB)) 
        {
            Hand.ThrowObject();
        }
    }
}
