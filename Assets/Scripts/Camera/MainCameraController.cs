using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float smoothing = 0.2f;
    [SerializeField] Vector2 minCameraBoundary;
    [SerializeField] Vector2 maxCameraBoundary;
    private void LateUpdate()
    {
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);
        
        targetPos.x = Mathf.Clamp(targetPos.x, minCameraBoundary.x, maxCameraBoundary.x);
        targetPos.y = Mathf.Clamp(targetPos.y, minCameraBoundary.y, maxCameraBoundary.y);

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
    }

    public void setCameraSmoothing(float smoothing)
    {
        this.smoothing = smoothing; 
    }

    public float getCameraSmoothing()
    {
        return this.smoothing;
    }

    public void setMinCameraBoundary(float x, float y)
    {
        this.minCameraBoundary.x = x;
        this.minCameraBoundary.y = y;
    }

    public void setMaxCameraBoundary(float x, float y)
    {
        this.maxCameraBoundary.x = x;
        this.maxCameraBoundary.y = y;
    }

}
