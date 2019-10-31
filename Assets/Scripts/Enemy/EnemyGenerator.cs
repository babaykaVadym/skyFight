using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] Enemeys;
   
    public float minDelay, maxDelay;
    public float minY, maxY;
    public GameObject Bonus;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
            
    }

      void Repeat()
    {
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        Vector2 pos = new Vector2(transform.position.x, Random.Range(minY, maxY));
        GameObject e = Instantiate(Enemeys[Random.Range(0, Enemeys.Length)], pos, Quaternion.identity) as GameObject;
        int bon = Random.Range(0, 100);
        Vector2 Bonuspos = new Vector2(transform.position.x, Random.Range(minY, maxY));
        Destroy(e, 25);
        if (bon <= 15)
            
        {
            GameObject b = Instantiate(Bonus,Bonuspos, Quaternion.identity) as GameObject;
            Destroy(b, 35);
        }

        Repeat();
    }
}
