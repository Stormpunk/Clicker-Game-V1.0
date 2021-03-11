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
    public Text upgradeText1;
    public Text upgradeText2;
    public float pointsIncreasedPerSecond;
    private void Start()
    {
        pointsIncreasedPerSecond = 0;
        
    }
    private void FixedUpdate()
    {
        points += pointsIncreasedPerSecond * Time.deltaTime;
        UpdateUI();
    }
    public void IncreaseScore()
    {
        points += pointsPerClick;
        //will trigger every time the button is clicked, increasing score by 1
        Debug.Log("score");
        UpdateUI();
    }
    private void UpdateUI()
    {
        scoreText.text = "Score:" + Mathf.FloorToInt(points).ToString();
        //updates the score text to be reflective of the players current points/currency
    }
    public void UpgradePointsPerClick()
    {
        if (points >= costToUpgrade1)
        {
            points -= costToUpgrade1;
            costToUpgrade1 = costToUpgrade1 * 2;
            pointsPerClick++;
            UpdateUI();
            UpdateUpgradeText();
        }
    }
    public void UpdateUpgradeText()
    {
        upgradeText1.text = costToUpgrade1 + " Points";
    }
    public void UpdateUpgradeText2()
    {
        upgradeText2.text = costToUpgrade2 + " Points";
    }
    public void AutomaticClicker()
    {
        if (points >= costToUpgrade2)
        {
            points -= costToUpgrade2;
            costToUpgrade2 = costToUpgrade2 * 2;
            pointsIncreasedPerSecond++;
            UpdateUI();
            UpdateUpgradeText2();
        }
    }

}
