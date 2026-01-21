using UnityEngine;

public class OnWater : MonoBehaviour
{
    private Waves currentWater;
    private CharacterController controller;

    public float gravity = -30f;
    public float surfaceOffset = 0.05f;

    private float verticalVelocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Waves water))
        {
            currentWater = water;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Waves water))
        {
            if (currentWater == water)
                currentWater = null;
        }
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (currentWater != null)
        {
            float waveHeight = currentWater.GetHeight(pos);

            if (pos.y <= waveHeight + 0.2f)
            {
                float snap = (waveHeight + surfaceOffset) - pos.y;

                if (snap > 0f)
                    controller.Move(Vector3.up * snap);

                verticalVelocity = -2f;
                return;
            }
        }
	
        // Gravity when not on water
        verticalVelocity += gravity * Time.deltaTime;
        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }
}