using UnityEngine;

public class Bonfire : MonoBehaviour
{
    public bool Active = true;
    public GameObject Fire = null;


    private void OnTriggerEnter(Collider Other)
    {
        Torch SourceFire = Other.attachedRigidbody.GetComponent<Torch>();

        if (SourceFire != null)
        {
            Ignition(SourceFire);

            Debug.Log("Fire! 222");
        }
    }

    private void Ignition(Torch SourceFire)
    {
        if (SourceFire.Active)
        {
            Active = true;
            Fire.SetActive(true);
        }
    }
}
