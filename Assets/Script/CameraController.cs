using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 3.0f;

    private float rotationX;
    private float rotationY;

    [SerializeField] private Transform target;
    [SerializeField] private float distanceFromTarget = 3.0f;

    private Vector2 currentRotation;
    private Vector2 smoothVelocity = Vector2.zero;

    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private Vector2 rotaionXMinMax = new Vector2 (-20, 40);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationY += mouseX;

        rotationX = Mathf.Clamp(rotationX, rotaionXMinMax.x, rotaionXMinMax.y);

        Vector2 nextRotaion = new Vector2(rotationX, rotationY);

        currentRotation = Vector2.SmoothDamp(currentRotation, nextRotaion, ref smoothVelocity, smoothTime);

        transform.localEulerAngles = currentRotation;

        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
