using UnityEngine;

public class Bonfire : MonoBehaviour
{
    private bool Active = false;


    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "SourceFire")
        {
            Ignition();
        }
    }

    private void Ignition()
    {

    }
}
