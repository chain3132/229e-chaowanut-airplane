using System;
using UnityEngine;

public class Airplane : MonoBehaviour
{
   [SerializeField] private Rigidbody rb;
   [SerializeField] private float enginePower = 20f;
   [SerializeField] private float liftBooster =  0.5f;
   [SerializeField] private float drag = 0.001f;
   [SerializeField] private float angularDrag = 0.001f;
   [SerializeField] private float yawPower = 50f;
   [SerializeField] private float pitchPower = 50f;
   [SerializeField] private float rollPower = 30f;

   private void Start()
   {
      rb = GetComponent<Rigidbody>();
      
   }

   private void FixedUpdate()
   {
      if (Input.GetKey(KeyCode.Space))
      {
        rb.AddForce(transform.forward * enginePower);
      }

      Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
      rb.AddForce(transform.up * lift.magnitude * liftBooster);
      rb.linearDamping = rb.linearVelocity.magnitude * drag;
      rb.angularDamping = rb.linearVelocity.magnitude * angularDrag;

      float yaw = Input.GetAxis("Horizontal") * yawPower;
      float pitch = Input.GetAxis("Vertical") * pitchPower;
      float roll = Input.GetAxis("Roll") * rollPower;
      
      rb.AddTorque(transform.up * yaw);
      rb.AddTorque(transform.right * pitch );
      rb.AddTorque(transform.forward * roll);

   }
}
