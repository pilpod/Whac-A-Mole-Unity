using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] moles;
    public float frequency = 3;
    private float starterTime;
    private int randomMole;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        moles[0].GetComponent<MoleController>().isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        float timeSpent = Time.time - starterTime;

        if (timeSpent >= frequency)
        {
            randomMole = Random.Range(0, moles.Length);
            
            bool moleIsActive = moles[randomMole].GetComponent<MoleController>().isActive;

            if (!moleIsActive)
            {
                moles[randomMole].GetComponent<MoleController>().isActive = true;
                starterTime = Time.time;
            }
        }
    }

}
