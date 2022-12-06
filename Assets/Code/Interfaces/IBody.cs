using UnityEngine;

public interface IBody
{
    void MoveForward (bool  Value);
    void MoveBack    (bool  Value);
    void MoveLeft    (bool  Value);
    void MoveRight   (bool  Value);
    void RotationMove(float Value);
}
