using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToAddForce : MonoBehaviour
{
    [SerializeField] private bool impluse;
    [SerializeField] private Vector3 forceVector = new Vector3(0,100,0);
    [SerializeField] private float forceWaite = 1.0f;
    [SerializeField] private ForceMode selectForceMode = ForceMode.Force;
    
    private Vector3 mousePosition;
    private Rigidbody objectRigidbody;

    private void Start()
    {
        
        if (!gameObject.GetComponent<Rigidbody>())
        {
            gameObject.AddComponent<Rigidbody>();
            objectRigidbody = gameObject.GetComponent<Rigidbody>();
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectForceMode == ForceMode.Force)
            {
                var initMass = objectRigidbody.mass;

                objectRigidbody.mass = forceWaite;
                objectRigidbody.AddForce(forceVector,selectForceMode);

                objectRigidbody.mass = initMass;
            }
            else if(selectForceMode == ForceMode.Acceleration)
            {
                objectRigidbody.AddForce(forceVector,selectForceMode);
            }
            else
            {
                Debug.Log("ForceMode.ForceかForceMode.Accelerationしか使えんぞ！！");
            }
        }
    }
}
