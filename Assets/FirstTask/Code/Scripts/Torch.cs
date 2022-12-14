using UnityEngine;

public class Torch : MonoBehaviour, ITakebleObject, ISourceFire
{
    private bool IsTaken = false;

    private bool _Active = false;
    public bool Active
    {
        get => _Active;
    }
    [SerializeField] private GameObject Fire = null;
    [SerializeField] private GameObject Outline = null;

    [SerializeField] private float TimeFading  = 5.0f;
    [SerializeField] private float Timer = 0.0f;


    private void Update()
    {
        if (!IsTaken && _Active)
        {
            Timer += Time.deltaTime;

            if (Timer > TimeFading)
            {
                Timer = 0;
                Fading();
            }
        }
        if (IsTaken && Timer != 0)
        {
            Timer = 0;
        }
    }
    private void OnTriggerEnter(Collider Other)
    {
        Rigidbody RigidbodyOther =  Other.attachedRigidbody;

        if (RigidbodyOther != null)
        {
            ISourceFire SourceFire = Other.attachedRigidbody.GetComponent<ISourceFire>();

            if (SourceFire != null && IsTaken)
            {
                Ignition(SourceFire);
            }
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
    private void Ignition(ISourceFire SourceFire)
    {
        if (SourceFire.Active)
        {
            _Active = true;
            Fire.SetActive(true);
        }
    }
    private void Fading()
    {
        _Active = false;
        Fire.SetActive(false);
    }

    public void ViewEnter()
    {
        Outline.SetActive(true);
    }
    public void ViewExit()
    {
        Outline.SetActive(false);
    }
}