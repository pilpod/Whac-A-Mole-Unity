//using System;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] holes;
    public GameObject[] moles;
    public GameObject flower_attack;

    public float frequency = 2f;
    private readonly float minimumFrequency = 0.50f;
    private readonly float frequencyCheckPointInSeconds = 10f;

    private int dice = 0;

    private float starterFrameTime;
    private float starterTimeGame;
    private float CheckPointTime;

    private int randomHole;
    private GameObject currentHole;
    private GameObject currentMole;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        CheckPointTime = starterTimeGame = Time.time;

        moles[randomHole].GetComponent<MoleController>().isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        float now = Time.time;
        float timeSpent = now - starterFrameTime;

        randomHole = Random.Range(0, moles.Length);
        currentHole = holes[randomHole];
        currentMole = moles[randomHole];
        HoleController hole = currentHole.GetComponent<HoleController>();

        if (hole.isEmpty)
        {
            if (dice > 3)
            {
                SetMole(now, timeSpent);
            }
            else
            {
                SetFlower(now, timeSpent);
            }
        }

        if (timeSpent >= frequency) RollDice();

        IncreaseFrequency(now);
    }

    private void SetMole(float now, float timeSpent)
    {
        if (timeSpent >= frequency)
        {
            bool moleIsActive = currentMole.GetComponent<MoleController>().isActive;

            if (!moleIsActive)
            {
                currentMole.GetComponent<MoleController>().isActive = true;
                starterFrameTime = now;
            }
        }
    }

    private void SetFlower(float now, float timeSpent)
    {
        if (timeSpent >= frequency)
        {
            GameObject plant = (currentMole.transform.parent.Find("flower_attack(Clone)") == null) ?
                Instantiate(flower_attack, currentHole.transform)
                : currentMole.transform.parent.Find("flower_attack(Clone)").gameObject;

            ParticleSystem part = currentMole.GetComponent<MoleController>().part;
            plant.GetComponent<MoleController>().part = part;

            bool isActive = plant.GetComponent<MoleController>().isActive;

            if (!isActive)
            {
                plant.GetComponent<MoleController>().isActive = true;
                starterFrameTime = now;
            }
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
