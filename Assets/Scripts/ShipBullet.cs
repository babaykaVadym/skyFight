using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullet : MonoBehaviour
{
    public SoundManager sm;
    private void Start()
    {
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemyB"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            sm.PlaySound(1);
        }
    }
}
