using UnityEngine;

public class Torch : MonoBehaviour
{
    private bool  IsTaken         = false;
    private bool  IsActive        = false;
    public  float TimeAttenuation = 0.0f ;
    private float Timer           = 0.0f ;

    private void Update()
    {
        if (IsActive && !IsTaken)
        {
            if (Timer < TimeAttenuation)
            {
                Timer += Time.deltaTime;
            }
            else
            {
                Timer    = 0    ;
                IsActive = false;
            }
        }
    }

    public void Taking() 
    {
        IsTaken = true;
    }
    public void Throwing() 
    {
        IsTaken = false;
    }
    public void Arson() 
    {
        IsActive = true;
    }
    public void Attenuation() 
    {
        IsActive = false;
    }
}