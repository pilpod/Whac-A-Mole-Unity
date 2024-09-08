using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleController : MonoBehaviour
{
    public bool isActive = false;
    private int velocity;
    private float starterTime;
    private bool isOut;
    public float maxTimeOut;
    private readonly float minTimeOut = 0.75f;
    private float timeSpent;
    public ParticleSystem part;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(10.45f, 0, -23);
        velocity = 9;
        isOut = false;
        maxTimeOut = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            MoveUp();
            MoveDown();
        }

        if (transform.localPosition.y >= 2.25f && !isOut)
        {
            isOut = true;
            starterTime = Time.time;
        }

        if (isOut)
        {
            timeSpent = Time.time - starterTime;
        }

        Disable();

    }

    private void MoveUp()
    {
        if (transform.localPosition.y < 2.25f && !isOut)
        {
            transform.Translate(Time.deltaTime * velocity * Vector3.up);
        }
    }

    private void MoveDown()
    {
        if (isOut && timeSpent >= maxTimeOut)
        {
            transform.Translate(Time.deltaTime * velocity * Vector3.down);
        }
    }

    private void Disable()
    {
        if (transform.localPosition.y <= 0)
        {
            isOut = false;
            isActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isOut)
        {
            part.Play();
            transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
            Disable();

            if (maxTimeOut >= minTimeOut)
            {
                maxTimeOut -= 0.25f;
            }
        }
    }
}
