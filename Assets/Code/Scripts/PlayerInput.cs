using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Сам скрипт полукостыльный, пока нет адаптации под VR
    // После появления доступа к гарнитуре необходимо переписать

    public Transform TBody = null; // Временный костыль для работы без VR
    public Transform TView = null; // Временный костыль для работы без VR
    public Transform THand = null; // Временный костыль для работы без VR

    private IBody Body = null;
    private IView View = null;
    private IHand Hand = null;

    public KeyCode MoveForward = KeyCode.W;
    public KeyCode MoveBack    = KeyCode.S;
    public KeyCode MoveLeft    = KeyCode.A;
    public KeyCode MoveRight   = KeyCode.D;

    public KeyCode HandActionA = KeyCode.Q;
    public KeyCode HandActionB = KeyCode.E;

    public float SensitivityMouse = 2.5f;

    private void Start()
    {
        Body = TBody.GetComponent<IBody>(); // Временный костыль для работы без VR
        View = TView.GetComponent<IView>(); // Временный костыль для работы без VR
        Hand = THand.GetComponent<IHand>(); // Временный костыль для работы без VR
    }
    private void Update()
    {
        Body.MoveForward(Input.GetKey(MoveForward));
        Body.MoveBack   (Input.GetKey(MoveBack   ));
        Body.MoveLeft   (Input.GetKey(MoveLeft   ));
        Body.MoveRight  (Input.GetKey(MoveRight  ));

        Body.RotationMove(View.RotationViewX());

        View.RotateViewX( Input.GetAxis("Mouse X") * SensitivityMouse);
        View.RotateViewY(-Input.GetAxis("Mouse Y") * SensitivityMouse);

        if (Input.GetKeyDown(HandActionA)) Hand.TakeObject ();
        if (Input.GetKeyDown(HandActionB)) Hand.ThrowObject();
    }
}
