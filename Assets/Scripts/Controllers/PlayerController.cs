using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    

    private Rigidbody rb;

    public float inputDelay = 0.1f;
    public float forwardVel = 120;
    public float rotateVel = 100;

    Quaternion targetRotation;
    float forwardInput, turnInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation;  }
    }

    void Start()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rb = GetComponent<Rigidbody>();
        else
            Debug.LogError("The character needs a rigidbody.");

        forwardInput = turnInput = 0;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        GetInput();
        Turn();
    }

    private void FixedUpdate()
    {
        Run();
    }

    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            rb.velocity = transform.forward * forwardInput * forwardVel;
        }
        else
            rb.velocity = Vector3.zero;
    }
    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }
}