using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalBluntz : MonoBehaviour
{
    //gangStrengthLevel
    public static int gangStrengthLevel;
    public GameObject gangStrengthDisplay;

    //grow
    public static int PlantCount = 1;
    public GameObject PlantsDisplay;

    //bluntz
    public static int BluntzCount;
    public GameObject BluntzDisplay;
    public int InternalBluntz;

    //bud
    public static double BudCount;
    public GameObject BudDisplay;
    public double InternalBud;

    //cash
    public static int CashCount = 500;
    public GameObject CashDisplay;
    public int InternalCash;

    //prices
    public static int BuyBudPrice;
    public GameObject BuyBudPriceDisplay;
    public int InternalBuyBudPrice;

    public static int SellBudPrice;
    public GameObject SellBudPriceDisplay;
    public int InternalSellBudPrice;

    public static int BluntzPrice;
    public GameObject BluntzPriceDisplay;
    public int InternalBluntzPrice;

    public GameObject RollBluntzDisplay;

    private float nextActionTime = 0f;
    public float period = 3f;


    //crew
    public static int growerPrice = 500;
    public static int growerLevel;
    public GameObject GrowerPriceDisplay;

    public static int rollerPrice = 500;
    public static int rollerLevel;
    public GameObject RollerPriceDisplay;

    public static int bouncerPrice = 500;
    public static int bouncerLevel;
    public GameObject bouncerPriceDisplay;

    public static int sellerPrice = 500;
    public static int sellerLevel;
    public GameObject sellerPriceDisplay;

    public static int shootaPrice = 500;
    public static int shootaLevel; //number of shootas
    public GameObject shootaPriceDisplay;
    public GameObject shootaCountDisplay;

    public static int hittaPrice = 500;
    public static int hittaLevel; //number of hittas
    public GameObject hittaPriceDisplay;
    public GameObject hittaCountDisplay;

    public static int bluntCount = 1; //amount of blunts being "rolled" right now

    //upgrades
    public static int BiggerPlantsPrice = 100;
    public static int BiggerPlantsLevel= 1;
    public GameObject BiggerPlantsPriceDisplay;

    public static int RollMorePrice = 100;
    public static int RollMoreLevel= 1;
    public GameObject RollMorePriceDisplay;

    public static int SellMorePrice = 100;
    public static int SellMoreLevel = 1;
    public GameObject SellMorePriceDisplay;

    public static int BiggerBagsPrice = 100;
    public static int BiggerBagsLevel = 1;
    public GameObject BiggerBagsPriceDisplay;
    public static int buyBagsAmount;

    public static int plantYield;

    void Update()
    {
        gangStrengthLevel = (shootaLevel + hittaLevel) / 2;

        buyBagsAmount = (7 * BiggerBagsLevel);

        plantYield = 23 + (BiggerPlantsLevel * 5);

        //upgrades
        BiggerPlantsPriceDisplay.GetComponent<Text>().text = "$" + BiggerPlantsPrice.ToString();

        RollMorePriceDisplay.GetComponent<Text>().text = "$" + RollMorePrice.ToString();

        SellMorePriceDisplay.GetComponent<Text>().text = "$" + SellMorePrice.ToString();

        BiggerBagsPriceDisplay.GetComponent<Text>().text = "$" + BiggerBagsPrice.ToString();

        //crew&gang
        GrowerPriceDisplay.GetComponent<Text>().text = "$" + growerPrice.ToString();

        RollerPriceDisplay.GetComponent<Text>().text = "$" + rollerPrice.ToString();

        sellerPriceDisplay.GetComponent<Text>().text = "$" + sellerPrice.ToString();

        bouncerPriceDisplay.GetComponent<Text>().text = "$" + bouncerPrice.ToString();

        shootaPriceDisplay.GetComponent<Text>().text = "$" + shootaPrice.ToString();
        shootaCountDisplay.GetComponent<Text>().text = "x" + shootaLevel.ToString();

        hittaPriceDisplay.GetComponent<Text>().text = "$" + hittaPrice.ToString();
        hittaCountDisplay.GetComponent<Text>().text = "x" + hittaLevel.ToString();


        //gui
        PlantsDisplay.GetComponent<Text>().text = (plantYield - 16) + " - " + plantYield + "g per plant";

        InternalBluntz = BluntzCount;
        BluntzDisplay.GetComponent<Text>().text = InternalBluntz + " bluntZ";

        InternalBud = BudCount;
        BudDisplay.GetComponent<Text>().text = InternalBud + "g";

        InternalCash = CashCount;
        CashDisplay.GetComponent<Text>().text = "$" + InternalCash;

        gangStrengthDisplay.GetComponent<Text>().text = "Gang Strength lvl: " + gangStrengthLevel;

        RollBluntzDisplay.GetComponent<Text>().text = "Roll " + GlobalBluntz.RollMoreLevel + " blunts";

        InternalBuyBudPrice = BuyBudPrice;
        BuyBudPriceDisplay.GetComponent<Text>().text = "Buy " + GlobalBluntz.buyBagsAmount + "g $" + (InternalBuyBudPrice * BiggerBagsLevel);

        InternalSellBudPrice = SellBudPrice;
        SellBudPriceDisplay.GetComponent<Text>().text = "Sell " + BiggerBagsLevel + "g $" + (InternalSellBudPrice * BiggerBagsLevel);

        InternalBluntzPrice = BluntzPrice;
        BluntzPriceDisplay.GetComponent<Text>().text = "Sell "+ SellMoreLevel + " blunts $" + (InternalBluntzPrice * SellMoreLevel);

        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            BuyBudPrice = Random.Range(30, 68);
            SellBudPrice = Random.Range(6, 10);
            BluntzPrice = Random.Range(9, 15);
        }
    }
}
