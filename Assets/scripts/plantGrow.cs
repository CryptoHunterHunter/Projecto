using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plantGrow : MonoBehaviour
{
    private float waitTime = 5;
    public float timer = 0;
    public GameObject plantDisplay;
    public float internalCount;

    void Start()
    {
        GlobalBluntz.PlantCount += 1;
    }

    void Update()
    {
        timer += Time.deltaTime;
        internalCount = timer;


        plantDisplay.GetComponent<Text>().text = internalCount.ToString("F1");

        if (timer > waitTime)
        {

            Destroy(gameObject);
            GlobalBluntz.PlantCount -= 1;
            GlobalBluntz.BudCount += (Random.Range((GlobalBluntz.plantYield - 16), GlobalBluntz.plantYield));

            timer = timer - waitTime;
        }
    }

}
