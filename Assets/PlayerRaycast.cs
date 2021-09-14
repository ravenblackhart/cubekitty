using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    private RaycastHit Catcher;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int layerMask = 1 << 6;

       if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out Catcher, 1f, layerMask))
        {
            Debug.Log(Catcher.transform);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * Catcher.distance, Color.yellow);
            Destroy(Catcher.transform.gameObject);
        }
        
    }
}
