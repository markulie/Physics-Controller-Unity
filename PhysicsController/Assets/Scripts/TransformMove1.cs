using System;
using System.Collections;
using UnityEngine;

public class TransformMove1 : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpSpeed = 10f;
    private float _oldSpeed;
    private bool _turbo;

    private void Start()
    {
        _oldSpeed = speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity += Vector3.up * jumpSpeed;
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        Vector3 velocity = new Vector3(h, 0, v) * speed;
        velocity.y = rigidbody.velocity.y;
        Vector3 worldVelocity = transform.TransformVector(velocity);
        rigidbody.velocity = worldVelocity;
        rigidbody.angularVelocity = new Vector3(0, r * rotationSpeed, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift) && !_turbo)
        {
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        _turbo = true;
        speed *= 3f;
        Debug.Log("1");
        yield return new WaitForSeconds(3);
        speed = _oldSpeed;
        Debug.Log("2");
        _turbo = false;
    }
}