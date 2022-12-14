using UnityEngine;

public class PaintCanvas : MonoBehaviour
{
    public CustomRenderTexture SupportTexture;
    public Material SupportMaterial;

    private Material Canvas;
    
    private void Start()
    {   
        Canvas = transform.GetComponent<MeshRenderer>().material;

        SupportMaterial.SetVector("_Position", new Vector2(-1, -1));
        SupportTexture.Initialize();
    }
    public void Painting(Vector2 PaintCoord)
    {
        SupportMaterial.SetVector("_Position", PaintCoord);
    }
    public void Stop()
    {
        SupportMaterial.SetVector("_Position", new Vector2(-1, -1));
    }
    public void ResetPaint()
    {
        SupportMaterial.SetVector("_Position", new Vector2(-1, -1));
        SupportTexture.Initialize();
    }
    public void CheckCorrect()
    {
    // Texture2D PaintImage  = Canvas.GetTexture("_Paint" ) as Texture2D;
    // Texture2D OriginImage = Canvas.GetTexture("_Origin") as Texture2D;

    // Color32[] PixelsPaint  = PaintImage .GetPixels32();
    // Color32[] PixelsOrigin = OriginImage.GetPixels32();

    // for (int i = 0; i < PixelsPaint .Length; i++)
    // //for (int j = 0; j < PixelsOrigin.Length; j++)
    // {
    //     if (PixelsPaint[i] == new Color32(0, 0, 0, 0))
    //     {
    //         Debug.Log("Black!");
    //     }
    // }
    }
}
