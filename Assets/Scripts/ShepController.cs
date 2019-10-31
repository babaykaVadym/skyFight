using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShepController : MonoBehaviour
{
    public int Life_points, Armore;
    public float minY, maxY;
    public float minX, maxX;
    public float speed;

    public GameObject bullet;
    public GameObject rocket;
    public int rocketCount, coinsCount, scoreCount;
    public Text RocketText, coinsCountT, scoreCountT, LifeCount, ArmoreCount;
    public float shootDelay;
    public Transform[] shootPoits;
    public bool isFire;
    public bool isReadyShoots;
    public int bulletDmg;
    public SoundManager sm;

    public Sprite[] ships;
    public bool isOver;
    public GameObject gameOverPanel;
    public ParticleSystem DeadFX;
    public SimpleAds Ad;
    public int DeatCount = 0;

    private void Start()
    {
        int shipNum = PlayerPrefs.GetInt("ship");
        GetComponent<SpriteRenderer>().sprite = ships[shipNum];
        isReadyShoots = true;
        isFire = false;
        coinsCount = PlayerPrefs.GetInt("coins",0);
        DeatCount = PlayerPrefs.GetInt("DC", 0);
    }


    void Save()
    {
        PlayerPrefs.SetInt("DC", DeatCount);
        PlayerPrefs.SetInt("coin", coinsCount);
        PlayerPrefs.SetInt("NewScore", scoreCount);
        if (!PlayerPrefs.HasKey("HS"))
        {
            PlayerPrefs.SetInt("HS", scoreCount);
        }
        else
        {
            int hs = PlayerPrefs.GetInt("HS");
            if (hs < scoreCount)
            {
                PlayerPrefs.SetInt("HS", scoreCount);
            }
        }
    }

    void GameOver()
    {
        DeatCount++;
        isOver = true;
        gameOverPanel.SetActive(true);
        DeadFX.Play();
        Save();
        Hide();
        if(DeatCount == 3)
        {
            Ad.ShowAd();
        }

    }
    void Hide()
     {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
       
    }
    private void OnApplicationQuit()
    {
        Save();
    }

    public void Move(Vector2 dir)
         {
        transform.Translate(dir * Time.deltaTime * speed);
        }



    void ChangeLife()
    {
       
    }



    private void Update()
    {
        coinsCountT.text = coinsCount.ToString();
        scoreCountT.text = scoreCount.ToString();
        RocketText.text = rocketCount.ToString();

        LifeCount.text = Life_points.ToString();
        ArmoreCount.text = Armore.ToString();

        Vector2 curPos = transform.localPosition;
        curPos.y = Mathf.Clamp(transform.localPosition.y, minY, maxY);
        curPos.x = Mathf.Clamp(transform.localPosition.x, minX, maxX);

        transform.localPosition = curPos;

        if (isFire && isReadyShoots)
        {

            Shoot();
        }

        if(Life_points <= 0 && !isOver)
        {
            GameOver();
        }
                       
    }


    void Shoot()
    {

        foreach (Transform sp in shootPoits)
        {
            GameObject b = Instantiate(bullet, sp.position, Quaternion.identity) as GameObject;
            Destroy(b, 6);
            if (sp == shootPoits[shootPoits.Length - 1])
            {

                StartCoroutine(ShootsDilay());
            }
        }

        sm.PlaySound(3);

    }

    public void RocketShoot()
    {
        if (rocketCount > 0)
        {
            sm.PlaySound(2);
            GameObject r = Instantiate(rocket, transform.position, Quaternion.identity) as GameObject;
            rocketCount--;
            Destroy(r, 10);
        }
    }



    public void Fire(bool fire)
    {
        isFire = fire;
    }



    IEnumerator ShootsDilay()
    {
        isReadyShoots = false;
        yield return new WaitForSeconds(shootDelay);
        isReadyShoots = true;
    }


   public void Damage(int dmg)
    {
        Life_points -= dmg;
        if (Life_points < 0)
        {
            Life_points = 0;
        }
       
    }

    public void AddScore(int scoreAdd)
    {
        scoreCount += scoreAdd;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemyB"))
        {
            Damage(1);
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
             coinsCount++;
            sm.PlaySound(4);
            AddScore(10);

        }
        if(collision.gameObject.CompareTag("enemy"))
        {
            Damage(2);
            Destroy(collision.gameObject);
            sm.PlaySound(0);
        }
    }
}
