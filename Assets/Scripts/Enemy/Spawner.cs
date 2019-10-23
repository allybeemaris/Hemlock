using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mob;
    public int mobCount;
    public float spawnInterval;

    private float currentTime;
    private List<GameObject> mobs;

    void Start()
    {
        mobs = new List<GameObject>();
    }

    void Update()
    {
        // Remove destroyed mobs
        mobs = mobs.Where(s => s != null).ToList();

        var lapsedTime = Time.fixedDeltaTime;
        currentTime += lapsedTime;

        if (currentTime > spawnInterval)
        {
            currentTime -= spawnInterval;

            if (mobs.Count < mobCount)
            {
                mobs.Add(Instantiate(mob, transform.position, transform.rotation));
            }
        }
    }
}
