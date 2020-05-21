using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ItemManager Player = other.gameObject.GetComponent<ItemManager>();
        Player.items += 1;
        Destroy(gameObject);
    }

    public IEnumerator CoolDown()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(2f);
        GetComponent<BoxCollider2D>().enabled = true;
    }

   


    void Update()
    {
        
    }
}
