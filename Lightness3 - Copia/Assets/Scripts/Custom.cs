using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom : MonoBehaviour
{
    public GameObject chapelis;

    private void OnTriggerEnter2D(Collider2D other)
    {
        chapelis.SetActive(true);
        Destroy(this.gameObject);
    }
}
