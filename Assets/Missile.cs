using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    [Range(-10, 10)]
    private float xAxisP, xAxisI, xAxisD;
    private PIDController xAxisPIDController;
    public float speed;
    public float rotationModifier;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        
        xAxisPIDController = new PIDController(xAxisP, xAxisI, xAxisD);
    }

    // Update is called once per frame
    void Update()
    {
        
        

       
    }

    private void FixedUpdate()
    {
        Vector3 vectorTotarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorTotarget.y, vectorTotarget.x); // * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        

        float xAngleError = Mathf.DeltaAngle(transform.rotation.eulerAngles.x, q.eulerAngles.x); Debug.Log("Error is " + xAngleError);
        //float xTorqueCorrection = xAxisPIDController.GetOutput(xAngleError, Time.fixedDeltaTime); Debug.Log("xTorque is " + xTorqueCorrection);
        float x2TorqueCorrection = xAxisPIDController.GetOutput(angle, Time.fixedDeltaTime);
        //rb.AddTorque(xTorqueCorrection);
        rb.AddTorque(x2TorqueCorrection);
        //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * xTorqueCorrection);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * x2TorqueCorrection);


        Debug.DrawRay(transform.position, target.transform.position, Color.red);
    }
}
