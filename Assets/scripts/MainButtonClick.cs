using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButtonClick : MonoBehaviour
{
    public GameObject Plant;
    public GameObject Blunt;
    public GameObject canvas;
    public int plantPosX;
    public int bluntPosX;
    public GameObject crewMenuUI;
    public GameObject shopMenuUI;
    public GameObject comingSoonUI;
    public GameObject introUI;

    public GameObject Grower;
    public GameObject HireGrowerButton;

    public GameObject Roller;
    public GameObject HireRollerButton;

    public GameObject Seller;
    public GameObject HireSellerButton;

    public GameObject Bouncer;
    public GameObject HireBouncerButton;

    public GameObject Shoota;

    public GameObject Hitta;


    private float growerwaitTime = 7;
    public float growertimer = 0;
    public float growerinternalCount;

    private float rollerwaitTime = 6;
    public float rollertimer = 0;
    public float rollerinternalCount;

    private float sellerwaitTime = 10;
    public float sellertimer = 0;
    public float sellerinternalCount;


    //grow bud
    public void ClickTheGrowButton()
    {

        if (GlobalBluntz.PlantCount <= 6)
        {
            plantPosX = (-530 + (90 * GlobalBluntz.PlantCount));

            GameObject myPlant = Instantiate(Plant, new Vector2(plantPosX, 900), Quaternion.identity) as GameObject;
            myPlant.transform.SetParent(canvas.transform, false);


        }
    }

    //Roll Blunt
    public void ClickTheBluntButton()
    {
        if (GlobalBluntz.BudCount >= GlobalBluntz.RollMoreLevel && GlobalBluntz.bluntCount <=4)
        {
            bluntPosX = (-590 + (135 * GlobalBluntz.bluntCount));

            GameObject myBlunt = Instantiate(Blunt, new Vector2(bluntPosX, -590), Quaternion.identity) as GameObject;
            myBlunt.transform.SetParent(canvas.transform, false);

        }
    }

    //Buy Bud
    public void ClickTheBudButton()
    {
        // Bud + 28 gs of bud
        //if Cash - BuyBudPrice

        if (GlobalBluntz.CashCount >= (GlobalBluntz.BuyBudPrice * GlobalBluntz.BiggerBagsLevel))
        {
            GlobalBluntz.BudCount += GlobalBluntz.buyBagsAmount;
            GlobalBluntz.CashCount -= (GlobalBluntz.BuyBudPrice * GlobalBluntz.BiggerBagsLevel);
        }
    }

    //Sell Bluntz
    public void ClickTheSellBluntzButton()
    {
        if (GlobalBluntz.BluntzCount >= GlobalBluntz.SellMoreLevel)
        {
            GlobalBluntz.BluntzCount -= GlobalBluntz.SellMoreLevel;
            GlobalBluntz.CashCount += (GlobalBluntz.BluntzPrice * GlobalBluntz.SellMoreLevel);
        }
    }

    //Sell Bud
    public void ClickTheSellBudButton()
    {
        if (GlobalBluntz.BudCount >= GlobalBluntz.BiggerBagsLevel)
        {
            GlobalBluntz.BudCount -= GlobalBluntz.BiggerBagsLevel;
            GlobalBluntz.CashCount += (GlobalBluntz.SellBudPrice * GlobalBluntz.BiggerBagsLevel);
        }
    }

    //Lower GUI & Resume buttons
    public void ClickTheCrewButton()
    {
        crewMenuUI.SetActive(true);
    }
    public void resumeCrewMenuButton()
    {
        crewMenuUI.SetActive(false);
    }
    public void ClickTheShopButton()
    {
        shopMenuUI.SetActive(true);
    }//upgrades menu
    public void resumeShopMenuButton()
    {
        shopMenuUI.SetActive(false);
    }
    public void ClickComingSoon()
    {
        comingSoonUI.SetActive(true);
    }
    public void resumeComingSoon()
    {
        comingSoonUI.SetActive(false);
    }
    public void startIntroMenuButton()
    {
        introUI.SetActive(false);
    }

    //Upgrades menu
    public void BiggerPlantsButton()
    {
        if (GlobalBluntz.CashCount >= GlobalBluntz.BiggerPlantsPrice)
        {
            GlobalBluntz.CashCount -= GlobalBluntz.BiggerPlantsPrice;
            GlobalBluntz.BiggerPlantsLevel += 1;
            Debug.Log("Bigger Plants bought");
            GlobalBluntz.BiggerPlantsPrice += 50;
        }
    }
    public void RollMoreButton()
    {
        if (GlobalBluntz.CashCount >= GlobalBluntz.RollMorePrice)
        {
            GlobalBluntz.CashCount -= GlobalBluntz.RollMorePrice;
            GlobalBluntz.RollMoreLevel += 1;
            Debug.Log("Roll More bought");
            GlobalBluntz.RollMorePrice += 50;
        }
    }
    public void SellMoreButton()
    {
        if (GlobalBluntz.CashCount >= GlobalBluntz.SellMorePrice)
        {
            GlobalBluntz.CashCount -= GlobalBluntz.SellMorePrice;
            GlobalBluntz.SellMoreLevel += 1;
            Debug.Log("Sell More bought");
            GlobalBluntz.SellMorePrice += 50;
        }
    }
    public void BiggerBagsButton()
    {
        if (GlobalBluntz.CashCount >= GlobalBluntz.BiggerBagsPrice)
        {
            GlobalBluntz.CashCount -= GlobalBluntz.BiggerBagsPrice;
            GlobalBluntz.BiggerBagsLevel += 1;
            Debug.Log("Bigger Bags bought");
            GlobalBluntz.BiggerBagsPrice += 50;
        }
    }

    //crew managment/hiremenu
    public void buyGrowerButton()
    {
        Debug.Log("button pressed");
        if (GlobalBluntz.CashCount >= GlobalBluntz.growerPrice && GlobalBluntz.growerLevel == 0)
        {
            GlobalBluntz.CashCount -= GlobalBluntz.growerPrice;
            GlobalBluntz.growerLevel += 1;
            Grower.SetActive(true);
            Debug.Log("grower bought");
            GlobalBluntz.growerPrice = 100;
            //activate loop to press grow button every x seconds
            HireGrowerButton.GetComponent<Text>().text = "Upgrade Grower";

        } else if (GlobalBluntz.CashCount >= GlobalBluntz.growerPrice)
        {
            GlobalBluntz.CashCount -= GlobalBluntz.growerPrice;
            GlobalBluntz.growerLevel += 1;
            Debug.Log("grower upgraded");
            GlobalBluntz.growerPrice += 100;
            //speed up grow press loop
        }
    }
    public void buyRollererButton()
    {
        Debug.Log("button pressed");
        if (GlobalBluntz.CashCount >= GlobalBluntz.rollerPrice && GlobalBluntz.rollerLevel == 0)
        {
            GlobalBluntz.CashCount -= GlobalBluntz.rollerPrice;
            GlobalBluntz.rollerLevel += 1;
            Roller.SetActive(true);
            Debug.Log("roller bought");
            GlobalBluntz.rollerPrice = 100;
            //activate loop to press grow button every x seconds
            HireRollerButton.GetComponent<Text>().text = "Upgrade Roller";

        }
        else if (GlobalBluntz.CashCount >= GlobalBluntz.rollerPrice)
        {
            GlobalBluntz.CashCount -= GlobalBluntz.rollerPrice;
            GlobalBluntz.rollerLevel += 1;
            Debug.Log("roller upgraded");
            GlobalBluntz.rollerPrice += 100;
            //speed up grow press loop
        }
    }
    public void buySellerButton()
    {
        Debug.Log("button pressed");
        if (GlobalBluntz.CashCount >= GlobalBluntz.sellerPrice && GlobalBluntz.sellerLevel == 0)
        {
            GlobalBluntz.CashCount -= GlobalBluntz.sellerPrice;
            GlobalBluntz.sellerLevel += 1;
            Seller.SetActive(true);
            Debug.Log("seller bought");
            GlobalBluntz.sellerPrice = 100;
            HireSellerButton.GetComponent<Text>().text = "Upgrade Seller";

        }
        else if (GlobalBluntz.CashCount >= GlobalBluntz.sellerPrice)
        {
            GlobalBluntz.CashCount -= GlobalBluntz.sellerPrice;
            GlobalBluntz.sellerLevel += 1;
            Debug.Log("seller upgraded");
            GlobalBluntz.sellerPrice += 100;
        }
    }
    public void buyBouncerButton()
    {
        Debug.Log("button pressed");
        if (GlobalBluntz.CashCount >= GlobalBluntz.bouncerPrice && GlobalBluntz.bouncerLevel == 0)
        {
            GlobalBluntz.CashCount -= GlobalBluntz.bouncerPrice;
            GlobalBluntz.bouncerLevel += 1;
            Bouncer.SetActive(true);
            Debug.Log("bouncer bought");
            GlobalBluntz.bouncerPrice = 100;
            HireBouncerButton.GetComponent<Text>().text = "Upgrade Bouncer";

        }
        else if (GlobalBluntz.CashCount >= GlobalBluntz.bouncerPrice)
        {
            GlobalBluntz.CashCount -= GlobalBluntz.bouncerPrice;
            GlobalBluntz.bouncerLevel += 1;
            Debug.Log("bouncer upgraded");
            GlobalBluntz.bouncerPrice += 100;
        }
    }
    public void buyShootaButton()
    {
        Debug.Log("button pressed");
        if (GlobalBluntz.CashCount >= GlobalBluntz.shootaPrice)
        {
            GlobalBluntz.CashCount -= GlobalBluntz.shootaPrice;
            GlobalBluntz.shootaLevel += 1;
            Shoota.SetActive(true);
            Debug.Log("Shoota bought");
            GlobalBluntz.shootaPrice += 10;

        }
    }
    public void buyHittaButton()
    {
        Debug.Log("button pressed");
        if (GlobalBluntz.CashCount >= GlobalBluntz.hittaPrice)
        {
            GlobalBluntz.CashCount -= GlobalBluntz.hittaPrice;
            GlobalBluntz.hittaLevel += 1;
            Hitta.SetActive(true);
            Debug.Log("Hitta bought");
            GlobalBluntz.hittaPrice += 10;

        }
    }


    void Update()
    {
        growertimer += Time.deltaTime;
        growerinternalCount = growertimer;

        if (growertimer > growerwaitTime)
        {
            if (GlobalBluntz.PlantCount <= 6 && GlobalBluntz.growerLevel > 0)
            {
                plantPosX = (-530 + (90 * GlobalBluntz.PlantCount));

                GameObject myPlant = Instantiate(Plant, new Vector2(plantPosX, 900), Quaternion.identity) as GameObject;
                myPlant.transform.SetParent(canvas.transform, false);


            }

            growertimer = growertimer - growerwaitTime;
        }

        rollertimer += Time.deltaTime;
        rollerinternalCount = rollertimer;

        if (rollertimer > rollerwaitTime)
        {
            if (GlobalBluntz.BudCount >= GlobalBluntz.RollMoreLevel && GlobalBluntz.bluntCount <= 4 && GlobalBluntz.rollerLevel > 0)
            {
                bluntPosX = (-590 + (135 * GlobalBluntz.bluntCount));

                GameObject myBlunt = Instantiate(Blunt, new Vector2(bluntPosX, -590), Quaternion.identity) as GameObject;
                myBlunt.transform.SetParent(canvas.transform, false);

            }

            rollertimer = rollertimer - rollerwaitTime;
        }

        sellertimer += Time.deltaTime;
        sellerinternalCount = sellertimer;

        if (sellertimer > sellerwaitTime)
        {
            if (GlobalBluntz.BudCount >= GlobalBluntz.BiggerBagsLevel && GlobalBluntz.sellerLevel > 0)
            {
                GlobalBluntz.BudCount -= GlobalBluntz.BiggerBagsLevel;
                GlobalBluntz.CashCount += (GlobalBluntz.SellBudPrice * GlobalBluntz.BiggerBagsLevel);
            }
            if (GlobalBluntz.BluntzCount >= GlobalBluntz.SellMoreLevel && GlobalBluntz.sellerLevel > 0)
            {
                GlobalBluntz.BluntzCount -= GlobalBluntz.SellMoreLevel;
                GlobalBluntz.CashCount += (GlobalBluntz.BluntzPrice * GlobalBluntz.SellMoreLevel);
            }


            sellertimer = sellertimer - sellerwaitTime;
        }
    }

}
