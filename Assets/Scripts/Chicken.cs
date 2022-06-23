using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    float spawnx;
    float spawny;


    // Start is called before the first frame update
    void Start()
    {
        spawnx = transform.position.x;
        spawny = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetSpawnx()
    {
        return spawnx;
    }
    public float GetSpawny()
    {
        return spawny;
    }
}
