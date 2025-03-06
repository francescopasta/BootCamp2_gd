using UnityEngine;

public class PeeMoverController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float minAngle = -45f;
    public float maxAngle = 45f;
    public float basePissForce = 1f;
    public float boostedPissForce = 3f;
    public ParticleSystem piss;

    private float currentRotationY = 0f;
    private ParticleSystem.MainModule pissMain;

    void Start()
    {
        if (piss != null)
        {
            pissMain = piss.main;
        }
    }

    void Update()
    {
        // Handle rotation
        float mouseX = Input.GetAxis("Mouse X");
        float parentRotationY = transform.parent.eulerAngles.y;
        currentRotationY += mouseX * rotationSpeed * Time.deltaTime;
        currentRotationY = Mathf.Clamp(currentRotationY, minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(0f, parentRotationY - currentRotationY, 0f);

        // Adjust piss force based on RMB hold
        if (Input.GetMouseButton(1)) // Right Mouse Button
        {
            pissMain.startSpeed = boostedPissForce; // Increase distance
        }
        else
        {
            pissMain.startSpeed = basePissForce;
        }
    }
}
