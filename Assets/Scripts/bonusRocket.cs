using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusRocket : MonoBehaviour
{
    private ShepController Ship;
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
            Ship.rocketCount += 3;
            sm.PlaySound(4);
        }
    }
}
