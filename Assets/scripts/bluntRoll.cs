using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bluntRoll : MonoBehaviour
{
    private float waitTime = 5;
    public float timer = 0;
    public GameObject bluntDisplay;
    public float internalCount;

    void Start()
    {
        GlobalBluntz.bluntCount += 1;
        GlobalBluntz.BudCount -= GlobalBluntz.RollMoreLevel;//x
       // GlobalBluntz.CashCount -= GlobalBluntz.RollMoreLevel;//x
    }

    void Update()
    {
        timer += Time.deltaTime;
        internalCount = timer;


        bluntDisplay.GetComponent<Text>().text = internalCount.ToString("F1");

        if (timer > waitTime)
        {

            Destroy(gameObject);
            GlobalBluntz.bluntCount -= 1;
            GlobalBluntz.BluntzCount += GlobalBluntz.RollMoreLevel;//x




            timer = timer - waitTime;
        }
    }

}
