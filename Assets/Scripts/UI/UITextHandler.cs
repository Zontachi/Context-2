using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class UpdateText : MonoBehaviour
{
    public TextMeshProUGUI CDCounter, LeatherCounter, CanCounter, FlowerCounter, WoolCounter, FabricsCounter, RopeCounter, ButtonsCounter, PlasticsCounter, RamenCounter, SoupCounter, CandyCounter, CookiesCounter;
    public TextMeshProUGUI DayCounter, ReputationCounter, EncumberanceCounter, TimeCounter, FoodCounter;
    [SerializeField] private string sReputation;
    private float fFoodTotal = 0;

    void Update()
    {
        if (GlobalVariables.alive)
        {
            CDCounter.text = "x" + GlobalVariables.iCD;
            LeatherCounter.text = "x" + GlobalVariables.iLeather;
            CanCounter.text = "x" + GlobalVariables.iCan;
            FlowerCounter.text = "x" + GlobalVariables.iFlower;
            WoolCounter.text = "x" + GlobalVariables.iWool;
            FabricsCounter.text = "x" + GlobalVariables.iFabrics;
            RopeCounter.text = "x" + GlobalVariables.iRope;
            ButtonsCounter.text = "x" + GlobalVariables.iButtons;
            PlasticsCounter.text = "x" + GlobalVariables.iPlastics;
            RamenCounter.text = "x" + GlobalVariables.iRamen;
            SoupCounter.text = "x" + GlobalVariables.iSoup;
            CandyCounter.text = "x" + GlobalVariables.iCandy;
            CookiesCounter.text = "x" + GlobalVariables.iCookies;
            DayCounter.text = "Day " + GlobalVariables.iDay;
            UpdateReputationText();
            ReputationCounter.text = "Reputation: " + sReputation + " (" + GlobalVariables.iReputation + ")";
            CalculateEncumberance();
            UpdateEncumberanceColor();
            EncumberanceCounter.text = "Encumberance: " + GlobalVariables.iEncumberance + "/" + GlobalVariables.iMaxEncumbernace;
            TimeCounter.text = ConvertTo24HourFormat(GlobalVariables.iTime);
            //TimeCounter.text = ConvertTo24HourFormat((int) Time.time);
            FoodCounter.text = CalculateFood() + " Days worth of food";
            FoodTextColor();
        }
    }

    int CalculateFood()
    {
        fFoodTotal = GlobalVariables.iRamen + (GlobalVariables.iSoup * 2) + (GlobalVariables.iCandy / 4) + (GlobalVariables.iCookies / 2);
        return Mathf.RoundToInt(fFoodTotal);
    }

    int CalculateEncumberance()
    {
        GlobalVariables.iEncumberance = (GlobalVariables.iRamen * 4) + (GlobalVariables.iSoup * 10) + GlobalVariables.iCandy + (GlobalVariables.iCookies * 2) + GlobalVariables.iCD + GlobalVariables.iLeather + GlobalVariables.iCan + GlobalVariables.iFlower + GlobalVariables.iWool + GlobalVariables.iFabrics + GlobalVariables.iRope + GlobalVariables.iButtons + GlobalVariables.iPlastics;
        return GlobalVariables.iEncumberance;
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
        if (GlobalVariables.iReputation >= 0 && GlobalVariables.iReputation < 20)
        {
            sReputation = "A Nobody";
            ReputationCounter.color = Color.red;
        }
        else if (GlobalVariables.iReputation >= 20 && GlobalVariables.iReputation < 40)
        {
            sReputation = "Small Timer";
            ReputationCounter.color = new Color(1.0f, 0.5f, 0.0f);
        }
        else if (GlobalVariables.iReputation >= 40 && GlobalVariables.iReputation < 75)
        {
            sReputation = "Well Known";
            ReputationCounter.color = Color.yellow;
        }
        else if (GlobalVariables.iReputation >= 75)
        {
            sReputation = "Famous";
            ReputationCounter.color = Color.green;
        }
    }

    void UpdateEncumberanceColor()
    {
        if (GlobalVariables.iEncumberance >= 0 && GlobalVariables.iEncumberance < 25)
        {
            EncumberanceCounter.color = Color.green;
        }
        else if (GlobalVariables.iEncumberance >= 25 && GlobalVariables.iEncumberance < 50)
        {
            EncumberanceCounter.color = Color.yellow;
        }
        else if (GlobalVariables.iEncumberance >= 50 && GlobalVariables.iEncumberance < 75)
        {
            EncumberanceCounter.color = new Color(1.0f, 0.5f, 0.0f);
        }
        else if (GlobalVariables.iEncumberance >= 75)
        {
            EncumberanceCounter.color = Color.red;
        }
    }
    
    public void NextDay()
    {
        if (GlobalVariables.iRamen > 1)
        {
            GlobalVariables.iRamen -= 1;
        }
        else if (GlobalVariables.iCookies > 2)
        {
            GlobalVariables.iCookies -= 2;
        }
        else if (GlobalVariables.iSoup > 1)
        {
            GlobalVariables.iSoup -= 1;
        }
        else if (GlobalVariables.iCandy > 4)
        {
            GlobalVariables.iCandy -= 4;
        }
        else
        {
            DayCounter.text = "You starved to death";
            GlobalVariables.alive = false;
        }
        GlobalVariables.iTime = 0;
        GlobalVariables.iDay += 1;
    }

    string ConvertTo24HourFormat(int time)
    {
        int hours = time / 60; // Extract hours
        int minutes = time % 60; // Extract minutes

        // Ensure that hours and minutes are within the valid range
        hours = Mathf.Clamp(hours, 0, 24);
        minutes = Mathf.Clamp(minutes, 0, 59);

        if (hours == 24)
        {
            NextDay();
        }

        // Format the time string in 24-hour format
        string formattedTime = string.Format("{0:00}:{1:00}", hours, minutes);

        return formattedTime;
    }
}
