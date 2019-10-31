using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int hs;
    public int coins;
    public Image[] ships;
    public int shipNum;
    public Image Selector;
    public Color[] shipColors, selectorColors;
    public GameObject priceInCoins, priceInDollars;
    public string[] PlayButtonTexts;
    public Text coinsT, HS_T, PlayBtnT;
    public Color[] playBtnColors;
    public bool[] shipUnlock;
    public bool sound;
    public Text soundBtn;
    public int intMenuCount = 0;
  
    public GameObject watchAdBtn;

    // Start is called before the first frame update
    void Start()
    {
        intMenuCount = PlayerPrefs.GetInt("IN", 0);
        if(intMenuCount == 3)
        {
            watchAdBtn.SetActive(true);
            PlayerPrefs.SetInt("IN", 0);
        }

        Time.timeScale = 1;

        if (AudioListener.volume == 0)
        {

            sound = false;
        }
        else
        {
            sound = true;
        }


        hs = PlayerPrefs.GetInt("HS", 0);
        coins = PlayerPrefs.GetInt("coins", 0);
        if (PlayerPrefs.GetInt("ship2") == 1)
        {
            shipUnlock[1] = true;
        }
        else
        {
            shipUnlock[1] = false;
        }
        ChangeShip(1);


    }



    // Update is called once per frame
    void Update()
    {
        coinsT.text = coins.ToString();
        HS_T.text = "HIGHSCORE: " + hs.ToString();

    }

    public void ChangeShip(int num)
    {
        switch (num)
        {
            case 1:
                Selector.transform.position = ships[0].transform.position;
                ships[0].color = shipColors[0];
                ships[1].color = shipColors[1];
                ships[2].color = shipColors[1];
                shipNum = 0;
                PlayBtnT.text = PlayButtonTexts[0];
                PlayBtnT.color = playBtnColors[0];
                priceInCoins.SetActive(false);
                Selector.GetComponent<Image>().color = selectorColors[0];
                break;

            case 2:
                Selector.transform.position = ships[1].transform.position;
                ships[0].color = shipColors[1];
                ships[1].color = shipColors[0];
                ships[2].color = shipColors[1];
                shipNum = 1;
                if (shipUnlock[1] == false)
                {
                    Selector.GetComponent<Image>().color = selectorColors[1];
                    priceInCoins.SetActive(true);
                    PlayBtnT.text = PlayButtonTexts[1];
                    PlayBtnT.color = playBtnColors[1];
                }
                else
                {
                    Selector.GetComponent<Image>().color = selectorColors[0];
                    priceInCoins.SetActive(false);
                    PlayBtnT.text = PlayButtonTexts[0];
                    PlayBtnT.color = playBtnColors[0];
                }
                break;

            case 3:
                Selector.transform.position = ships[2].transform.position;
                ships[0].color = shipColors[1];
                ships[1].color = shipColors[1];
                ships[2].color = shipColors[0];
                shipNum = 2;
                PlayBtnT.text = PlayButtonTexts[1];
                PlayBtnT.color = playBtnColors[1];
                break;

        }
    }

    public void PlayBtn()
    {
        if (shipNum == 0)
        {
            intMenuCount++;
            PlayerPrefs.SetInt("IN", intMenuCount);
            Application.LoadLevel("play");
           
        }
        if (shipNum == 1)
        {
            if (shipUnlock[1] == false)
            { 
                if (coins >= 1000)
                {
                    shipUnlock[1] = true;
                    PlayerPrefs.SetInt("ship2", 1);
                    ChangeShip(2);
                }
            }

            else
            {
                intMenuCount++;
                PlayerPrefs.SetInt("IN",intMenuCount);
                Application.LoadLevel("play");
            }
        }
        PlayerPrefs.SetInt("ship", shipNum);


    }

    public void Exit()
    {
        Application.Quit();

    }

    public void Sound()
    {
        if (sound == true)
        {
            AudioListener.volume = 0;
            sound = false;
            return;

        }
        if (sound == false)
        {
            AudioListener.volume = 1;
            sound = true;
            return;

        }
    }
}
