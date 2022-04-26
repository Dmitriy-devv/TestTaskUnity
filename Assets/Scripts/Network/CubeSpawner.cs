using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public GameObject Spawn()
    {
        var obj = Instantiate(prefab);
        var rnd = Random.Range(0, 255);
        var rndP = Random.Range(0, 1f);
        obj.GetComponent<MeshRenderer>().material.color = new Color(rnd, rnd, rnd);
        obj.transform.position = new Vector3(rndP, 0f, rndP);

        return obj;
    }
}
