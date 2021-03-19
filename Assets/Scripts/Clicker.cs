using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Text upgradeText1;
    public Text upgradeText2;
    public Text upgradeText3;
    //display that will update the adjusted price for the player 
    public float pointsIncreasedPerSecond;

    //a value that will increase the player's point counts for a set value every second
    float[] costToUpgrade = {
            100,
                50,
                10000,
                9999999
        };
    //values that act as the prices for the upgrades for the user
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
    #region Sass List
    string[] playerSass =
    {
            "Bypassing the Mainframe...",
            "You're about to blast through the last blinky box...",
            "They've deployed cyber nukes! Watch out!",
            "You know you could probably do this faster in Cyberspace",
            "Initiating Breach Protocol",
            "Did you know? You can hack even faster with two people typing on the same keyboard!",
            "Did you know? Downloading more RAM means that your hacking is even stronger than the other guys'",
            "Did you know? Hollywood doesn't know shit about computers",
            "Just PayPal me some Bitcoin when you get the chance",
            "Ctrl+Alt+Death",
            "Relic Malfunction Detected",
            "Assuming Direct Control"

        };
    #endregion
    //listed out the randomly selected messages the player can see
    //note to self, probably no time to find a better method but there has to be a better way to hide this because JESUS CHRIST MY EYES
    //Well, using an array helps a little bit. but Jesus christ I'm going to hide it behind a region

    public Text sassDisplay;
    float timer;
    //a list of messages that the player can be shown, along with the gameobject to display the text as well as the timer to count down to the next message
    public Text superiorDialogue;
    string[] purchaseText =
    {
        "Many thanks, now put my tech to good use!",
        "You can't afford that yet! Hack some more currency out of people's computers first!"
    };
    public GameObject techNuke;
    public GameObject worldHack;
    private void Start()
    {
        pointsIncreasedPerSecond = 0;
        increasePointsPerClick = 1;
        maxIncreasePointsPerClick = 1;
        superiorDialogue.text = ("Your mission is a simple one, how you go about it is up to you. You need to... HACK THE PLANET");
        techNuke.SetActive(false);


    }
    private void FixedUpdate()
    {
        points += pointsIncreasedPerSecond * Time.deltaTime;
        //if the player has any passive point upgrades, it will increase the score over time
        UpdateUI();
        increasePointsPerClick = maxIncreasePointsPerClick;
        //sets the value that upgrades the click 
        timer += Time.deltaTime;
        if (timer > 20)
        { timer -= 20;
            string randomSass = playerSass[Random.Range(0, playerSass.Length)];
            sassDisplay.text = randomSass;
        }
        //displays random message after the timer reaches 20
    }
    public void Update()
    {
        if(points == 9999999)
        {
            techNuke.SetActive(true);
        }
        //checks if the player's score is high enough and if so enables the final "upgrade
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
        hacksText.text = Mathf.FloorToInt(upgradeNo2) + " HackBots";
    }
    public void UpdateUpgradeText()
    {
        upgradeText1.text = costToUpgrade[0] + " Points";
    }
    public void UpdateUpgradeText2()
    {
        upgradeText2.text = costToUpgrade[1] + " Points";
    }
    public void UpdateUpgradeText3()
    {
        upgradeText3.text = costToUpgrade[2] + " Points";
    }
    //updates all the text to reflect the updated value after points are added and removed
    #endregion
    #region Purchase Upgrades
    public void AutomaticClicker()
    {
        if (points >= costToUpgrade[1])
        {
            points -= costToUpgrade[1];
            costToUpgrade[1] *= 2;
            pointsIncreasedPerSecond++;
            upgradeNo2++;
            UpdateUI();
            UpdateUpgradeText2();
            UpdateUpgradeDisplay2();
            superiorDialogue.text = purchaseText[0];
        }
        //purchases upgrade if points are high enough, displays purchase message
        else
        {
            superiorDialogue.text = purchaseText[1];
        }
        //shows error trying to purchase
    }
    public void UpgradePointsPerClick()
    {
        if (points >= costToUpgrade[0])
        {
            points -= costToUpgrade[0];
            costToUpgrade[0] *= 2;
            pointsPerClick += increasePointsPerClick;
            maxIncreasePointsPerClick *= 1.1f;
            upgradeNo1++;
            UpdateUpgradeDisplay1();
            UpdateUI();
            UpdateUpgradeText();
            superiorDialogue.text = purchaseText[0];
        }
        else
        {
            superiorDialogue.text = purchaseText[1];
        }

    }
    public void TechBoost()
    {
        if (points >= costToUpgrade[2])
        {
            costToUpgrade[0] *= 0.5f;
            costToUpgrade[1] *= 0.5f;
            costToUpgrade[2] *= 1.5f;
            superiorDialogue.text = purchaseText[0];
        }
        else
        {
            superiorDialogue.text = purchaseText[1];
        }
        UpdateUpgradeText();
        UpdateUpgradeText2();
        UpdateUpgradeText3();
    }
    public void HackTheWorld()
    {
        if(points >= costToUpgrade[3])
        {
            worldHack.SetActive(true);
        }
        //activates the "endgame" 
    }
    #endregion
    public void ObjectiveDialogue()
    {
        superiorDialogue.text = ("Need a reminder? Really? Hack everything you can get your hands on.");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
        //resets the game
    }
}
