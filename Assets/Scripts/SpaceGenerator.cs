using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGenerator : MonoBehaviour
{
    public GameObject[] stars;
    public float minY, maxY;
    public float minSpeed, maxSpeed;
    public float minScale, maxScale;
    public Color[] colors;

    public float interval;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, interval);
    }
        void Spawn()
        {
            GameObject star = stars[Random.Range(0, stars.Length)];
            Vector2 pos = new Vector2(transform.position.x, Random.Range(minY, maxY));
            float scl = Random.Range(minScale, maxScale);
            Vector3 scale = new Vector3(scl, scl, scl);
            float speeds = Random.Range(minSpeed, maxSpeed);
            Color color = colors[Random.Range(0, colors.Length)];
             
            GameObject s = Instantiate(star, pos, Quaternion.identity) as GameObject;
            s.GetComponent<MoveEnemy>().Speed = speeds;
            s.transform.localScale = scale;
            s.GetComponent<SpriteRenderer>().color = color;

        }
    }

