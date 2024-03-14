using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateText : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI CDCounter, LeatherCounter, CanCounter, FlowerCounter, WoolCounter, FabricsCounter, RopeCounter, ButtonsCounter, PlasticsCounter, RamenCounter, SoupCounter, CandyCounter, CookiesCounter;
    [SerializeField] private int iCD = 0, iLeather = 0, iCan = 0, iFlower = 0, iWool = 0, iFabrics = 0, iRope = 0, iButtons = 0, iPlastics = 0;
    [SerializeField] private int iRamen = 0, iSoup = 0, iCandy = 0, iCookies = 0;
    [SerializeField] public TextMeshProUGUI DayCounter, ReputationCounter, EncumberanceCounter, TimeCounter, FoodCounter;
    [SerializeField] private int iDay = 1, iTime = 0, iReputation = 0, iEncumberance = 0, iMaxEncumbernace = 100;
    [SerializeField] private string sReputation;
    private float fFoodTotal = 0;

    void Start()
    {
    }

    void Update()
    {
        CDCounter.text = "x" + iCD;
        LeatherCounter.text = "x" + iLeather;
        CanCounter.text = "x" + iCan;
        FlowerCounter.text = "x" + iFlower;
        WoolCounter.text = "x" + iWool;
        FabricsCounter.text = "x" + iFabrics;
        RopeCounter.text = "x" + iRope;
        ButtonsCounter.text = "x" + iButtons;
        PlasticsCounter.text = "x" + iPlastics;
        RamenCounter.text = "x" + iRamen;
        SoupCounter.text = "x" + iSoup;
        CandyCounter.text = "x" + iCandy;
        CookiesCounter.text = "x" + iCookies;
        DayCounter.text = "Day " + iDay;
        UpdateReputationText();
        ReputationCounter.text = "Reputation: " + sReputation + " (" + iReputation + ")";
        UpdateEncumberanceColor();
        EncumberanceCounter.text = "Encumberance: " + iEncumberance + "/" + iMaxEncumbernace;
        TimeCounter.text = ConvertTo24HourFormat(iTime);
        FoodCounter.text = CalculateFood() + " Days worth of food";
        FoodTextColor();
    }

    int CalculateFood()
    {
        fFoodTotal = iRamen + (iSoup * 2) + (iCandy / 4) + (iCookies / 2);
        return Mathf.RoundToInt(fFoodTotal);
    }

    void FoodTextColor()
    {
        if (CalculateFood() >= 0 && CalculateFood() < 2)
        {
            FoodCounter.color = Color.red;
        }
        else if (CalculateFood() >= 2 && CalculateFood() < 4)
        {
            FoodCounter.color = new Color(1.0f, 0.5f, 0.0f);
        }
        else if (CalculateFood() >= 4 && CalculateFood() < 6)
        {
            FoodCounter.color = Color.yellow;
        }
        else if (CalculateFood() >= 6)
        {
            FoodCounter.color = Color.green;
        }
    }

    void UpdateReputationText()
    {
        if (iReputation >= 0 && iReputation < 20)
        {
            sReputation = "A Nobody";
            ReputationCounter.color = Color.red;
        }
        else if (iReputation >= 20 && iReputation < 40)
        {
            sReputation = "Small Timer";
            ReputationCounter.color = new Color(1.0f, 0.5f, 0.0f);
        }
        else if (iReputation >= 40 && iReputation < 75)
        {
            sReputation = "Well Known";
            ReputationCounter.color = Color.yellow;
        }
        else if (iReputation >= 75)
        {
            sReputation = "Famous";
            ReputationCounter.color = Color.green;
        }
    }

    void UpdateEncumberanceColor()
    {
        if (iEncumberance >= 0 && iEncumberance < 25)
        {
            EncumberanceCounter.color = Color.green;
        }
        else if (iEncumberance >= 25 && iEncumberance < 50)
        {
            EncumberanceCounter.color = Color.yellow;
        }
        else if (iEncumberance >= 50 && iEncumberance < 75)
        {
            EncumberanceCounter.color = new Color(1.0f, 0.5f, 0.0f);
        }
        else if (iEncumberance >= 75)
        {
            EncumberanceCounter.color = Color.red;
        }
    }

    string ConvertTo24HourFormat(int time)
    {
        int hours = time / 100; // Extract hours
        int minutes = time % 100; // Extract minutes

        // Ensure that hours and minutes are within the valid range
        hours = Mathf.Clamp(hours, 0, 23);
        minutes = Mathf.Clamp(minutes, 0, 59);

        // Format the time string in 24-hour format
        string formattedTime = string.Format("{0:00}:{1:00}", hours, minutes);

        return formattedTime;
    }
}
