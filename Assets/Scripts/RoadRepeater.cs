using UnityEngine;

public class RoadRepeater : MonoBehaviour
{
    [Header("Road Renderer")]
    public Renderer roadRenderer;

    [Header("Scrolling Settings")]
    public float scrollSpeed = 0.5f;

    private Material roadMaterial;
    private Vector2 textureOffset;

    private string textureProperty;

    private void Start()
    {
        if (roadRenderer == null)
            roadRenderer = GetComponent<Renderer>();

        if (roadRenderer == null)
        {
            Debug.LogError("Road Renderer is missing!");
            enabled = false;
            return;
        }

        // Create an instance of the material
        roadMaterial = roadRenderer.material;

        // Support Built-in and URP shaders
        if (roadMaterial.HasProperty("_BaseMap"))
            textureProperty = "_BaseMap";
        else if (roadMaterial.HasProperty("_MainTex"))
            textureProperty = "_MainTex";
        else
        {
            Debug.LogError("Material has no supported texture property!");
            enabled = false;
            return;
        }

        textureOffset = roadMaterial.GetTextureOffset(textureProperty);
    }

    private void Update()
    {
        // Scroll texture along the road's Z direction
        textureOffset.y -= scrollSpeed * Time.deltaTime;

        roadMaterial.SetTextureOffset(textureProperty, textureOffset);
    }

    // Change scrolling speed from another script
    public void SetRoadSpeed(float speed)
    {
        scrollSpeed = speed;
    }
}
