using UnityEngine;

public class PeeMoverController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float minAngle = -45f;      
    public float maxAngle = 45f;       

    private float currentRotationY = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float parentRotationY = transform.parent.eulerAngles.y;
        currentRotationY += mouseX * rotationSpeed * Time.deltaTime;
        currentRotationY = Mathf.Clamp(currentRotationY, minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(0f, parentRotationY - currentRotationY, 0f);
    }
}
