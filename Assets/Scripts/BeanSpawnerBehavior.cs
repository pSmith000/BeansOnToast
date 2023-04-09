using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanSpawnerBehavior : MonoBehaviour
{   static public bool CanSpawn;
    public GameObject Bean;
    private float random;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSpawn)
        {
            random = Random.Range(-2.0f, 2.0f);
            GameObject newObject = Instantiate(Bean, new Vector3(random, 10.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            //newObject.transform.localScale = new Vector3(.5f, .5f, .5f);
            CanSpawn = false;
        }
    }
}
