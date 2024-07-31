using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] items;

    private float minY = -2.48f, maxY = 2.48f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnItems(1f));
    }

    IEnumerator spawnItems(float time){
        yield return new WaitForSecondsRealtime(time);
        Vector3 temp = new Vector3(transform.position.x,Random.Range(minY,maxY),0);
        Instantiate(items[Random.Range(0,items.Length)],temp,Quaternion.identity);
        StartCoroutine(spawnItems(Random.Range(1f,2f)));
    }
}
