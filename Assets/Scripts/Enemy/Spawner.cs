using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mob;
    public float secondInterval;

    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var lapsedTime = Time.fixedDeltaTime;
        currentTime += lapsedTime;

        if (currentTime > secondInterval) {
            Instantiate(mob, transform.position, transform.rotation);
            currentTime -= secondInterval;
        }
    }
}
