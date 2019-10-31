using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusLife : MonoBehaviour
{
  public ShepController Ship;
    private SoundManager sm;

    // Start is called before the first frame update
    void Start()
    {
        Ship = GameObject.Find("Ship3").GetComponent<ShepController>();
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            Destroy(gameObject);
            if (Ship.Life_points < 9)
            {
                Ship.Life_points+=2;
            }
            else
            {
                Ship.Life_points = 10;
            }
            sm.PlaySound(4);
        }
    }
}
