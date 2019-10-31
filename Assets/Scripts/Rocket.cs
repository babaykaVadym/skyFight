using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public SoundManager sm;
    private void Start()
    {
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<SimpleEnemy>().Damage(10);
            Destroy(gameObject);
            sm.PlaySound(0);
        }
        if (collision.gameObject.CompareTag("enemyB"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            sm.PlaySound(0);
        }
        if (collision.gameObject.CompareTag("mine"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            sm.PlaySound(0);
        }
    }


}
