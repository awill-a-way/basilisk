using UnityEngine;

public class OnWater : MonoBehaviour
{
    public WaterSurface water;
    public float onWaterRange = 0.1f;
    public bool isOnWater = false;

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        float waterY = water.SampleHeight(pos);
        
        if (pos.y < waterY)
            pos.y = waterY;

        transform.position = pos;

        if (pos.y < waterY + onWaterRange)
            isOnWater = true;
        else
            isOnWater = false;
    }
}
