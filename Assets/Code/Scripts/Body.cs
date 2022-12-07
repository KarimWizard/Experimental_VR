using UnityEngine;

public class Body : MonoBehaviour, IBody
{
    private Transform Transform;

    private bool ActiveMoveF;
    private bool ActiveMoveB;
    private bool ActiveMoveL;
    private bool ActiveMoveR;

    public  float SpeedMove;
    private float RotateMove;

    private void Start()
    {
        Transform = this.transform;
    }
    private void Update()
    {
        float MoveF = ActiveMoveF ? 1.0f : 0.0f;
        float MoveB = ActiveMoveB ? 1.0f : 0.0f;
        float MoveL = ActiveMoveL ? 1.0f : 0.0f;
        float MoveR = ActiveMoveR ? 1.0f : 0.0f;

        Vector2 DirectionMoveHor = new Vector2();
        DirectionMoveHor.x = MoveR - MoveL;
        DirectionMoveHor.y = MoveF - MoveB;
        DirectionMoveHor = DirectionMoveHor.normalized * SpeedMove;

        Vector3 DirectionMoveAll = new Vector3();
        DirectionMoveAll.x = DirectionMoveHor.x;
        DirectionMoveAll.y = 0.0f;
        DirectionMoveAll.z = DirectionMoveHor.y;

        Quaternion DirectionView = Quaternion.Euler(0, RotateMove, 0);
        DirectionMoveAll = DirectionView * DirectionMoveAll;

        Transform.localPosition += DirectionMoveAll;
    }

    public void MoveForward(bool Value) => ActiveMoveF = Value;
    public void MoveBack   (bool Value) => ActiveMoveB = Value;
    public void MoveLeft   (bool Value) => ActiveMoveL = Value;
    public void MoveRight  (bool Value) => ActiveMoveR = Value;

    public void RotationMove(float Value) => RotateMove  = Value;
}
