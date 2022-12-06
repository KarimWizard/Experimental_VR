using UnityEngine;

public class Torch : MonoBehaviour
{
    private bool IsTaken = false;


    private void Update()
    {

    }
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "SourceFire")
        {
            Ignition();
        }
    }

    public void Taking(Transform SourceRetention)
    {
        IsTaken = true;

        Transform ThisTransform = GetComponent<Transform>();
        Rigidbody ThisRigidbody = GetComponent<Rigidbody>();

        ThisTransform.parent = SourceRetention;
        ThisTransform.localPosition = Vector3.zero;
        ThisTransform.localRotation = Quaternion.Euler(Vector3.zero);
        ThisRigidbody.isKinematic = true;
    }
    public void Throwing()
    { 
        IsTaken = false;

        Transform ThisTransform = GetComponent<Transform>();
        Rigidbody ThisRigidbody = GetComponent<Rigidbody>();

        ThisTransform.parent = null;
        ThisRigidbody.isKinematic = false;
    }
    private void Ignition()
    {

    }
    private void Fading()
    {
        
    }
}