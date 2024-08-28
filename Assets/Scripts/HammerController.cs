using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rotation = new Vector3(0, 0, 45);
            transform.Rotate(rotation);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 rotation = new Vector3(0, 0, -45);
            transform.Rotate(rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliding with Mole: " + other.name);
    }


}
