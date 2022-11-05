using UnityEngine;

public class FPS : MonoBehaviour
{
    public byte value = 30;

    private void OnValidate()
    {
        Application.targetFrameRate = value;
    }
}