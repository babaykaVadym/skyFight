 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public int Life_points;
    public GameObject bullet;
    public float shootDelay;
    public Transform[] shootPoits;
    public ShepController Ship;
    public bool isDead = false;
    public SoundManager sm;
    public GameObject coin;
 

    void Shoot()
    {
        foreach (Transform sp in shootPoits)
        {
            GameObject b = Instantiate(bullet, sp.position, Quaternion.identity);
            Destroy(b, 6);
            
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
        Ship = GameObject.Find("Ship3").GetComponent<ShepController>();
        InvokeRepeating("Shoot", 1, shootDelay);
    }

    private void Update()
    {
        if(Life_points == 0 && !isDead)
        {
            Boom();
        }
    }

    void Boom()
    {
        isDead = true;
        Destroy(gameObject);
        sm.PlaySound(0);
        SpawnCoin();
        Ship.GetComponent<ShepController>().AddScore(50);
    }

    void SpawnCoin()
    {
        GameObject c = Instantiate(coin, transform.position, Quaternion.identity) as GameObject;
    }

   public void Damage(int dmg)
    {
        Life_points -= dmg;
        if(Life_points < 0)
        {
            Life_points = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("shipB"))
        {
            Damage(Ship.bulletDmg);
            Destroy(collision.gameObject);
            sm.PlaySound(0);
            
        }
        //if (collision.gameObject.CompareTag("enemyB"))
        //{
        //    Damage(0);
        //    Destroy(collision.gameObject);
        //    sm.PlaySound(0);
        //}
    }
}
