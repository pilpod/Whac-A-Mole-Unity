using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private bool isUp = true;
    private float maxTimeDown = 0.25f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Hammer fallow the mouse
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            transform.position = hit.point;
        }

        // Hammer swing down when mouse button left is clicked
        if (Input.GetMouseButtonDown(0) && isUp)
        {
            SwingDown();
        }

        // Hammer return to initial position if left button was up
        if (Input.GetMouseButtonUp(0) && !isUp)
        {
            SwingUp();
        }

        // Hammer cannot be down for more then half a second
        if (!isUp)
        {
            maxTimeDown -= Time.deltaTime;

            if (maxTimeDown <= 0)
            {
                SwingUp();
            }
        }

    }

    private void SwingDown()
    {
        Vector3 rotation = new Vector3(0, 0, 45);
        transform.Rotate(rotation);
        isUp = false;
    }

    private void SwingUp()
    {
        Vector3 reverseRotation = new Vector3(0, 0, -45);
        transform.Rotate(reverseRotation);
        isUp = true;
        maxTimeDown = 0.25f;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliding with Mole: " + other.name);
    }


}
