using UnityEngine;

public class View : MonoBehaviour
{
    private Transform Transform;

    private float RotateX;
    private float RotateY;

    [SerializeField] private float MaxAngleUp;
    [SerializeField] private float MaxAngleDown;

    private void Start()
    {
        Transform = this.transform;
    }
    private void Update()
    {
        RotateY = Mathf.Clamp(RotateY, -MaxAngleUp, MaxAngleDown);

        Transform.localRotation = Quaternion.Euler(RotateY, RotateX, 0);
    }

    public void RotateViewX(float Value) => RotateX += Value;
    public void RotateViewY(float Value) => RotateY += Value;

    public float RotationViewX() => RotateX;

}
