using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject Ship;
    public float distToActive, Speed;
    public SoundManager sm;


    // Start is called before the first frame update
    void Start()
    {
        Ship = GameObject.Find("Ship3");
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, Ship.transform.position)<= distToActive && !Ship.GetComponent<ShepController>().isOver)
        {
            transform.position = Vector2.MoveTowards(transform.position, Ship.transform.position, Speed * Time.deltaTime);
        }

        if(Vector2.Distance(transform.position, Ship.transform.position) <= 0.3f && !Ship.GetComponent<ShepController>().isOver)
        {
            Ship.GetComponent<ShepController>().Damage(3);
            Destroy(gameObject);
            sm.PlaySound(0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("shipB"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            sm.PlaySound(0);
            Ship.GetComponent<ShepController>().AddScore(100);
            
        }
    }
} 
