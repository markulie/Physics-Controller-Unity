using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float lerpRate = 10f;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * lerpRate);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * lerpRate);
    }
}