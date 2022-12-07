using UnityEngine;

public class Bonfire : MonoBehaviour, ISourceFire
{
    public bool _Active = true;
    public bool Active
    {
        get => _Active;
    }
    public GameObject Fire = null;


    private void OnTriggerEnter(Collider Other)
    {
        ISourceFire SourceFire = Other.attachedRigidbody.GetComponent<ISourceFire>();

        if (SourceFire != null)
        {
            Ignition(SourceFire);
        }
    }

    private void Ignition(ISourceFire SourceFire)
    {
        if (SourceFire.Active)
        {
            _Active = true;
            Fire.SetActive(true);
        }
    }
}
