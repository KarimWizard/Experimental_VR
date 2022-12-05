using UnityEngine;

public class Hand : MonoBehaviour
{
    private Transform Transform;

    private bool Active ;
    private bool ActionA;
    private bool ActionB;

    public float DistanceRay;

    private void Start()
    {
        Transform = this.transform;
    }
    private void Update()
    {   
        if (Active)
        {
            Vector3 Origin    = transform.position;
            Vector3 Direction = transform.forward ;

            Physics.Raycast(Origin, Direction, out RaycastHit Hit, DistanceRay);

            if (Hit.transform.tag == "Item")
            {

                if (ActionA) { }
                if (ActionB) { }
            }
        }
    }

    public void Activate   (bool Value) => Active  = Value;
    public void MakeActionA(bool Value) => ActionA = Value;
    public void MakeActionB(bool Value) => ActionB = Value;
}
