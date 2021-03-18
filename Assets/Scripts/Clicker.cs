using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public float points;
    //a simple float to keep track of how many points/currency the player has
    int displayPoints;
    //an int to display the score with greater accuracy
    public float pointsPerClick;
    public Text scoreText;
    //UI element to display to the player their current number of points/currency
    public float costToUpgrade1;
    public float costToUpgrade2;
    public float costToUpgrade3;
    public float costToUpgrade4;
    //values that act as the "price" for items
    public Text upgradeText1;
    public Text upgradeText2;
    public Text upgradeText3;
    //display that will update the adjusted price for the player 
    public float pointsIncreasedPerSecond;
    //a value that will increase the player's point counts for a set value every second
    public float increasePointsPerClick;
    //this will add to the players pointsPerClick value
    public float maxIncreasePointsPerClick;
    //adjusts the increasePointsPerClick value so the player is able to increase the boosts they get by more than just a factor of one
    public Text hacksText;
    //displays how many of the "hacks" boost the player has in their possession
    private float upgradeNo2;
    //value that determines how many of the "hack" boost the player possesses in a numeric value
    public Text fireWallsText;
    //displays how many of the "Firewall Breach" boost the player has in their possession
    private float upgradeNo1;
    //value that determines how many of the "firewall breach" boosts the player possesses in a numeric value
    List<string> playerSass;
    public Text sassDisplay;
    float timer;
    //a list of messages that the player can be shown, along with the gameobject to display the text as well as the timer to count down to the next message
    public Text superiorDialogue;
    public GameObject techNuke;
    private void Start()
    {
        pointsIncreasedPerSecond = 0;
        increasePointsPerClick = 1;
        maxIncreasePointsPerClick = 1;
        superiorDialogue.text = ("Your mission is a simple one, how you go about it is up to you. You need to... HACK THE PLANET");
        #region Sass List
        playerSass = new List<string>();
        playerSass.Add("Bypassing the Mainframe...");
        playerSass.Add("You're about to blast through the last blinky box...");
        playerSass.Add("They've deployed cyber nukes! Watch out!");
        playerSass.Add("You know you could probably do this faster in Cyberspace");
        playerSass.Add("Initiating Breach Protocol");
        playerSass.Add("Did you know? You can hack even faster with two people typing on the same keyboard!");
        playerSass.Add("Did you know? Downloading more RAM means that your hacking is even stronger than the other guys'");
        playerSass.Add("Did you know? Hollywood doesn't know shit about computers");
        playerSass.Add("Just PayPal me some Bitcoin when you get the chance");
        playerSass.Add("Ctrl+Alt+Death");
        playerSass.Add("Relic Malfunction Detected");
        playerSass.Add("Assuming Direct Control");
        #endregion
        //listed out the randomly selected messages the player can see
        //note to self, probably no time to find a better method but there has to be a better way to hide this because JESUS CHRIST MY EYES
        //fuck it just hide it with a region for now...

    }
    private void FixedUpdate()
    {
        points += pointsIncreasedPerSecond * Time.deltaTime;
        UpdateUI();
        increasePointsPerClick = maxIncreasePointsPerClick;
        timer += Time.deltaTime;
        if (timer > 20)
        {
            timer -= 20;
            string randomSass = playerSass[Random.Range(0, playerSass.Count - 1)];
            sassDisplay.text = randomSass;
        }
    }
    public void Update()
    {
        if(points == 9999999)
        {
            techNuke.SetActive(true);
        }
    }
    #region Scores
    public void IncreaseScore()
    {
        points += pointsPerClick;
        //will trigger every time the button is clicked, increasing score by 1
        Debug.Log("score");
        UpdateUI();
    }
    #endregion
    #region Update Systems
    private void UpdateUI()
    {
        scoreText.text = "Score:" + Mathf.FloorToInt(points).ToString();
        //updates the score text to be reflective of the players current points/currency
    }
    void UpdateUpgradeDisplay1()
    {
        fireWallsText.text = Mathf.FloorToInt(upgradeNo1) + " Firewall Breaches";
    }
    void UpdateUpgradeDisplay2()
    {
        hacksText.text = Mathf.FloorToInt(upgradeNo2) + " Filthy Hacks";
    }
    public void UpdateUpgradeText()
    {
        upgradeText1.text = costToUpgrade1 + " Points";
    }
    public void UpdateUpgradeText2()
    {
        upgradeText2.text = costToUpgrade2 + " Points";
    }
    #endregion
    #region Purchase Upgrades
    public void AutomaticClicker()
    {
        if (points >= costToUpgrade2)
        {
            points -= costToUpgrade2;
            costToUpgrade2 *= 2;
            pointsIncreasedPerSecond++;
            upgradeNo2++;
            UpdateUI();
            UpdateUpgradeText2();
            UpdateUpgradeDisplay2();
        }
    }
    public void UpgradePointsPerClick()
    {
        if (points >= costToUpgrade1)
        {
            points -= costToUpgrade1;
            costToUpgrade1 *= 2;
            pointsPerClick += increasePointsPerClick;
            maxIncreasePointsPerClick *= 1.1f;
            upgradeNo1++;
            UpdateUpgradeDisplay1();
            UpdateUI();
            UpdateUpgradeText();
        }
    }
    public void TechBoost()
    {
        if (points >= costToUpgrade3)
        {
            costToUpgrade1 *= 0.5f;
            costToUpgrade2 *= 0.5f;
        }
        UpdateUpgradeText();
        UpdateUpgradeText2();
    }
    public void HackTheWorld()
    {
        if(points >= costToUpgrade4)
        {

        }
    }
    #endregion
    public void ObjectiveDialogue()
    {
        superiorDialogue.text = ("Need a reminder? Really? Hack everything you can get your hands on.");
    }
    public void PurchaseDialogue1()
    {
        if (points >= costToUpgrade1)
        {
            superiorDialogue.text = "Much obliged, now get out there and put my tech to use";
        }
        else if (points <= costToUpgrade1)
        {
            superiorDialogue.text = "Hey! Script Kiddy! You don't have enough currency to do that yet!";
        }
    }
    public void PurchaseDialogue2()
    {
        if (points>= costToUpgrade2)
        {
            superiorDialogue.text = "Many thanks, now go out there and hack some stuff!";
        }
        else if(points <= costToUpgrade2)
        {
            superiorDialogue.text = "You can't afford that yet!";
        }
    }
    public void PurchaseDialogue3()
    {
        if (points >= costToUpgrade3)
        {
            superiorDialogue.text = "Initiating System Reboot";
        }
        else if (points <= costToUpgrade3)
        {
            superiorDialogue.text = "I can't help you until you have enough currency!";
        }
    }
}
