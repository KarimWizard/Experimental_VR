using UnityEngine;

public class Body : MonoBehaviour
{
    private Transform Transform;

    private bool ActiveMoveF;
    private bool ActiveMoveB;
    private bool ActiveMoveL;
    private bool ActiveMoveR;

    [SerializeField] private float SpeedMove;
    private float RotateMove;

    private void Start()
    {
        Transform = this.transform;
    }

    public void PositionMove(Vector2 DirectionStep, float RotationView)
    {
        Vector3 DirectionMove = new Vector3();
        DirectionMove.x = DirectionStep.x;
        DirectionMove.y = 0.0f;
        DirectionMove.z = DirectionStep.y;
        DirectionMove *= SpeedMove;

        Quaternion DirectionView = Quaternion.Euler(0, RotationView, 0);
        DirectionMove = DirectionView * DirectionMove;

        Transform.localPosition += DirectionMove;
    }
}
