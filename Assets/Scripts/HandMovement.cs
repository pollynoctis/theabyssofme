using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public float positionShakeAmount = 0.05f;   // How much it moves (tiny shake)
    public float positionShakeSpeed = 5f;       // How fast the shaking is

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Slight random position shake
        float x = Mathf.PerlinNoise(Time.time * positionShakeSpeed, 0f) - 0.5f;
        float y = Mathf.PerlinNoise(0f, Time.time * positionShakeSpeed) - 0.5f;

        Vector3 positionOffset = new Vector3(x, y, 0) * positionShakeAmount;

        // Apply position only — no rotation!
        transform.position = startPos + positionOffset;
    }
}
