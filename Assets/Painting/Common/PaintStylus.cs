using UnityEngine;

public class PaintStylus : MonoBehaviour
{
    // Класс полностью тестовый и нужен только для отладки рисования.
    //   Подлежит полной замене и/или переработке под работу с VR.

    private Camera ViewCamera;
    private KeyCode Paint = KeyCode.Mouse0;
    private KeyCode Reset = KeyCode.Mouse1;
    private KeyCode Check = KeyCode.Mouse2;


    private void Start()
    {
        ViewCamera = Camera.main;
    }

    private void Update()
    {
        Ray Ray = ViewCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(Ray, out RaycastHit Hit);

        if (Hit.transform != null && Hit.transform.tag == "PaintCanvas")
        {
            PaintCanvas Canvas = Hit.transform.GetComponent<PaintCanvas>();

            if (Input.GetKey(Paint))
            {   
                Vector2 BrushPosition = Hit.textureCoord;
                Canvas.Painting(BrushPosition);
            }
            if (Input.GetKeyUp(Paint))
            {
                Canvas.Stop();
            }

            if (Input.GetKeyDown(Reset))
            {
                Canvas.ResetPaint();
            }

            if (Input.GetKeyDown(Check))
            {
                Canvas.CheckCorrect();
            }
        }
    }
}
