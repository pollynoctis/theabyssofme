using UnityEngine;

public class CinematicBusMovement : MonoBehaviour
{
    private float speed = 5f;      // Скорость основного движения
    private float amplitudeX = 10f; 
    private float amplitudeY = 2f; 
    private float swaySpeed = 0.5f; 

    private Vector3 startPosition;
    private float randomOffset;

    void Start()
    {
        startPosition = transform.position;
        randomOffset = Random.Range(0f, 100f); 
    }

    void Update()
    {
        float time = Time.time * speed;

        // Плавное движение влево-вправо с синусоидальной амплитудой
        float x = Mathf.Sin(time) * amplitudeX;

        // Легкие покачивания вверх-вниз (с небольшой задержкой)
        float y = Mathf.Sin(time * swaySpeed + randomOffset) * amplitudeY;

        // Итоговое движение
        transform.position = startPosition + new Vector3(x, y, 0);
    }
}