using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float Speed;
    public GameObject Ship;
    // Start is called before the first frame update
    void Start()
    {
        Ship = GameObject.Find("PlayZone");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * Speed,Space.World);
        if(transform.position.x < Ship.transform.position.x - 10)
        {
            Destroy(gameObject);
        }
    }
}
