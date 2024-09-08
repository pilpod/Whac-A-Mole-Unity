using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] moles;

    public float frequency = 3f;
    private readonly float minimumFrequency = 0.50f;
    private readonly float frequencyCheckPointInSeconds = 15f;

    private int dice = 1;

    private float starterFrameTime;
    private float starterTimeGame;
    private float CheckPointTime;

    private int randomMole;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        CheckPointTime = starterTimeGame = Time.time;

        moles[randomMole].GetComponent<MoleController>().isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        float now = Time.time;

        SetMole(now);
        IncreaseFrequency(now);
    }

    private void SetMole(float now)
    {
        float timeSpent = now - starterFrameTime;
        randomMole = Random.Range(0, moles.Length);

        if (timeSpent >= frequency || dice == 6)
        {
            bool moleIsActive = moles[randomMole].GetComponent<MoleController>().isActive;

            if (!moleIsActive)
            {
                moles[randomMole].GetComponent<MoleController>().isActive = true;
                starterFrameTime = now;

                Debug.Log("Setting Mole ----------- : " + dice);
            }

            RollDice();
        }
    }

    private void IncreaseFrequency(float now)
    {
        float CheckpointTimeSpent = now - CheckPointTime;

        if (CheckpointTimeSpent >= frequencyCheckPointInSeconds && frequency > minimumFrequency)
        {
            frequency -= 0.25f;
            CheckPointTime = now;
        }
    }

    private void RollDice()
    {
        dice = Random.Range(1, 7);
    }
}
