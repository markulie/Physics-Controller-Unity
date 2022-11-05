using UnityEngine;

public class TestGraph : MonoBehaviour
{
    public AnimationCurve curve;

    private void Update()
    {
        curve.AddKey(Time.time, transform.rotation.y);
    }
}