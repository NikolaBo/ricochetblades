using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int scoreCap;
    public int redScore;
    public int blueScore;
    public Text redScoreText;
    public Text blueScoreText;
    public GameObject redWins;
    public GameObject blueWins;
    private bool won = false;
    public GameObject redPlayer;
    public GameObject bluePlayer;
    public GameObject[] shields;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R) && won) {
            //won = false;
            //redScore = 0;
            //redScoreText.text = "0";
            //redWins.SetActive(false);
            //blueScore = 0;
            //blueScoreText.text = "0";
            //blueWins.SetActive(false);
            //bluePlayer.SendMessage("Reset");
            //redPlayer.SendMessage("Reset");
            SceneManager.LoadScene(0);
        }
	}

    public void AddPoint(bool red) {
        if (redScore < scoreCap && blueScore < scoreCap)
        {
            if (red)
            {
                redScore++;
                redScoreText.text = redScore.ToString();
                if (redScore == scoreCap)
                {
                    Win(true);
                }
            }
            else
            {
                blueScore++;
                blueScoreText.text = blueScore.ToString();
                if (blueScore == scoreCap)
                {
                    Win(false);
                }
            }
            if ((redScore + blueScore) % 5 == 0) {
                SpawnShields();
            }
        }
    }
    void Win(bool red) {
        won = true;
        if (red)
        {
            redWins.SetActive(true);
        }
        else {
            blueWins.SetActive(true);
        }
    }
    void SpawnShields() {
        foreach (GameObject shield in shields) {
            shield.SetActive(true);
        }
    }
}
