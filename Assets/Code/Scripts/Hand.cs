using UnityEngine;

public class Hand : MonoBehaviour, IHand
{
    private Transform Transform  ;
    public  float     DistanceRay;
    public  IItem     TakeTorch  ;

    private void Start()
    {
        Transform = this.transform;
    }

    public void TakeObject()
    {
        if (TakeTorch == null)
        {
            Vector3 Origin    = transform.position;
            Vector3 Direction = transform.forward ;

            Physics.Raycast(Origin, Direction, out RaycastHit Hit, DistanceRay);

            if (Hit.transform     != null  )
            if (Hit.transform.tag == "Item")
            {
                TakeTorch = Hit.transform.GetComponent<IItem>();
                TakeTorch.Taking(Transform);
            }
        }
    }
    public void ThrowObject()
    {
        if (TakeTorch != null)
        {
            TakeTorch.Throwing();
            TakeTorch = null;
        }
    }
}
