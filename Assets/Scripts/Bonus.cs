using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public GameObject[] bonuses;
    public int lifePoins = 4;
    public bool isDead = false;
    public SoundManager sm;


    // Start is called before the first frame update
    void Start()
    {
        
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();

    }
    private void Update()
    {
        if(lifePoins == 0 && !isDead)
        {
            Boom();
            
        }
    }

    // Start is called before the first frame update
    void Boom()
    {
        isDead = true;
        GameObject bonus = bonuses[Random.Range(0, bonuses.Length)];
        GameObject b = Instantiate(bonus, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
        sm.PlaySound(0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("shipB"))
        {
            lifePoins--;
            Destroy(collision.gameObject);
            sm.PlaySound(1);
        }
        if (collision.gameObject.CompareTag("shipR"))
        {
            lifePoins=0;
            Destroy(collision.gameObject);
            
        }
    }
}
