using UnityEngine;

public class Hand : MonoBehaviour
{
    private Transform Transform;
    private ITakebleObject TakeTorch;

    [SerializeField] private float DistanceRay;
    [SerializeField] private LineRenderer Ray;
    [SerializeField] private bool RaycastActive;
    [SerializeField] private RaycastHit Hit;

    private Transform SelectTakebleItem;

    private void Start()
    {
        Ray = transform.GetComponent<LineRenderer>();
        Transform = transform;
    }
    private void Update()
    {
        RendererTakeLine();
        SelectItem();
    }

    public void RayCasting(bool Active)
    {
        RaycastActive = Active;
    }
    public void TakeObject()
    {
        if (TakeTorch == null)
        {
            if (Hit.transform != null && Hit.transform.tag == "Item")
            {
                TakeTorch = Hit.transform.GetComponent<ITakebleObject>();
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

    private void RendererTakeLine()
    {
        if (RaycastActive)
        {
            Vector3 Origin    = transform.position;
            Vector3 Direction = transform.forward ;
            Physics.Raycast(Origin, Direction, out Hit, DistanceRay);

            Vector3 PointRayOrigin = new Vector3();
            Vector3 PointRayDirection = new Vector3();

            PointRayOrigin = Transform.position;
            if (Hit.transform != null)
            {
                PointRayDirection = Hit.point;
            }
            else
            {
                PointRayDirection = Transform.position + (Transform.forward * DistanceRay);
            }

            Ray.SetPosition(0, PointRayOrigin);
            Ray.SetPosition(1, PointRayDirection);
        }
        else
        {
            Ray.SetPosition(0, Vector3.zero);
            Ray.SetPosition(1, Vector3.zero);
        }
    }
    private void SelectItem()
    {
        if (RaycastActive)
        {
            if (SelectTakebleItem != Hit.transform && Hit.transform.tag == "Item")
            {
                if (SelectTakebleItem != null)
                {
                    SelectTakebleItem.GetComponent<ITakebleObject>().ViewExit();
                }

                SelectTakebleItem = Hit.transform;
                SelectTakebleItem.GetComponent<ITakebleObject>().ViewEnter();
            }
        }
        else
        {
            if (SelectTakebleItem != null )
            {
                SelectTakebleItem.GetComponent<ITakebleObject>().ViewExit();
            }

            SelectTakebleItem = null;
        }
    }
}
