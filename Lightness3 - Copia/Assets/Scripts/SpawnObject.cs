using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] PBPC;
    public GameObject[] PD;
    public GameObject[] PE;
    public GameObject[] CSE;
    public GameObject[] CIE;
    public GameObject[] CSD;
    public GameObject[] CID;
    public GameObject[] floor;

    private void Start()
    {
        if (gameObject.tag == "PCPB")
        {
            CreateTile(PBPC);
        }
        if (gameObject.tag == "PD")
        {
            CreateTile(PD);
        }
        if (gameObject.tag == "PE")
        {
            CreateTile(PE);
        }
        if (gameObject.tag == "CSE")
        {
            CreateTile(CSE);
        }
        if (gameObject.tag == "CIE")
        {
            CreateTile(CIE);
        }
        if (gameObject.tag == "CSD")
        {
            CreateTile(CSD);
        }
        if (gameObject.tag == "CID")
        {
            CreateTile(CID);
        }  
        if (gameObject.tag == "Floor")
            {
            CreateTile(floor);
        }
    }
    private void CreateTile(GameObject[] arrayTile)
    {
        int rand = Random.Range(0, arrayTile.Length);
        GameObject instance = (GameObject)Instantiate(arrayTile[rand], transform.position, Quaternion.identity);
        instance.transform.parent = transform;
        instance.transform.rotation = transform.localRotation;
    }
}
