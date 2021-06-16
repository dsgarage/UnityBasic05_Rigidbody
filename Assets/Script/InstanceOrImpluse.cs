using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceOrImpluse : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private bool impluse;
    [SerializeField] private Vector3 forceVector;
    [SerializeField] private float impluseWaite;
    [SerializeField] private int destroyTime = 3;
    [SerializeField] private ForceMode selectForceMode = ForceMode.Impulse;
    
    private Vector3 mousePosition;
    private Rigidbody prefabRigidbody;

    private void Start()
    {
        if (prefab.GetComponent<Rigidbody>())
        {
            prefab.AddComponent<Rigidbody>();
            prefabRigidbody = prefab.GetComponent<Rigidbody>();
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!impluse)
            {
                ClickInstantiate();
            }
            else
            {
                ClickImpluse();
            }
        }
    }

    void ClickInstantiate()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 40.0f;
        Destroy(Instantiate(prefab, Camera.main.ScreenToWorldPoint(mousePosition),Quaternion.identity),destroyTime);
        
        
    }

    void ClickImpluse()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 5.0f; // 必ず0以上にする
        var ImpPrefab = Instantiate(prefab, Camera.main.ScreenToWorldPoint(mousePosition),Quaternion.identity);
        
        prefabRigidbody = ImpPrefab.GetComponent<Rigidbody>();
        Destroy(ImpPrefab,destroyTime);

        if (selectForceMode == ForceMode.Impulse)
        {
            prefabRigidbody.mass = impluseWaite;
        }
        
        prefabRigidbody.AddForce(forceVector, selectForceMode);
    }
}
