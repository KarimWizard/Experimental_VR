using UnityEngine;

public class Torch : MonoBehaviour
{
    private bool IsTaken = false;

    public bool Active = false;
    public GameObject Fire = null;

    public float TimeFading  = 5.0f;
    public float Timer = 0.0f;


    private void Update()
    {
        if (Active && !IsTaken)
        {
            Timer += Time.deltaTime;

            if (Timer > TimeFading)
            {
                Timer = 0;
                Fading();
            }
        }
    }
    private void OnTriggerEnter(Collider Other)
    {
        Bonfire SourceFire = Other.attachedRigidbody.GetComponent<Bonfire>();

        if (SourceFire != null && IsTaken)
        {
            Ignition(SourceFire);

            Debug.Log("Fire! 222");
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
    private void Ignition(Bonfire SourceFire)
    {
        if (SourceFire.Active)
        {
            Active = true;
            Fire.SetActive(true);
        }
    }
    private void Fading()
    {
        Active = false;
        Fire.SetActive(false);
    }
}