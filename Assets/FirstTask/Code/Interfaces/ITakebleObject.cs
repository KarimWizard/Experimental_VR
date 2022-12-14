using UnityEngine;

public interface ITakebleObject
{
    void Taking(Transform SourceRetention);
    void Throwing();

    void ViewEnter();
    void ViewExit();
}
