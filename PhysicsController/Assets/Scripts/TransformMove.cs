using UnityEngine;

public class TransformMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float rotationSensitivity = 10f;
    public GameObject box;
    public double distance;

    private void Update()
    {
        CharacterPosition();
    }

    private void CharacterPosition()
    {
        //Debug.Log(Vector3.Distance(transform.position, box.transform.position));
        float r = Input.GetAxisRaw("Mouse X");
        transform.Rotate(0, r * rotationSensitivity, 0);

        if (Vector3.Distance(transform.position, box.transform.position) > distance)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Vector3 offset = new Vector3(h, 0, v) * (Time.deltaTime * speed);
            transform.Translate(offset);
            Debug.Log(Time.deltaTime);
        }
    }
}