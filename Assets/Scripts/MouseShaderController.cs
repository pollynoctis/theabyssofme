using UnityEngine;
using UnityEngine.UI;

public class MouseShaderController : MonoBehaviour
{
    public Material mat;
    public Camera mainCam;
    public float radius = 1f;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = mainCam.ScreenToWorldPoint(mousePos);
        mat.SetVector("_Mouse", new Vector4(worldPos.x, worldPos.y, 0, 0));
        mat.SetFloat("_Radius", radius);
    }
}