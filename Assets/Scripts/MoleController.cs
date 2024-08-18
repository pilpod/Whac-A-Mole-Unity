using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleController : MonoBehaviour
{

    private int velocity;
    private float starterTime;
    private bool isOut;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(10.45f, 0, -23);
        velocity = 3;        
        isOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y < 2.25f && isOut == false)
        {
            transform.Translate(Time.deltaTime * velocity * Vector3.up);
        }

        if (transform.localPosition.y >= 2.25f && isOut == false)
        {
            isOut = true;
            starterTime = Time.time;
            Debug.Log(starterTime);
        }
    }
}
