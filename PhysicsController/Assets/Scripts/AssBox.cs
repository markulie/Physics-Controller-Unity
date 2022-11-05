using UnityEngine;

public class AssBox : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform playerBody;
    [SerializeField] private Vector3 scaleDown = new Vector3(1.2f, 0.8f, 1.2f);
    [SerializeField] private Vector3 scaleUp = new Vector3(0.8f, 1.2f, 0.8f);
    [SerializeField] private float scaleCoefficient;
    [SerializeField] private float rotationCoefficient;

    private void Update()
    {
        Vector3 relativePosition = playerTransform.InverseTransformPoint(transform.position);
        float interpolation = relativePosition.y * scaleCoefficient;
        Vector3 scale = Lerp3(scaleDown, Vector3.one, scaleUp, interpolation);
        playerBody.localScale = scale;
        playerBody.localEulerAngles = new Vector3(relativePosition.z, 0, -relativePosition.x) * rotationCoefficient;
    }

    private static Vector3 Lerp3(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        return t < 0 ? Vector3.Lerp(a, b, t + 1f) : Vector3.Lerp(b, c, t);
    }
}