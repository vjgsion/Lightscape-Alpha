using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject[] uiItems;
    public GameObject useItem;
    

    public int items;
   


    public void UseItem()
    {
        if (items >= 1 && Input.GetKeyDown("f"))
        {
           // Debug.Log("pirocona");
            items -= 1;
           GameObject item = Instantiate(useItem, gameObject.transform.position, Quaternion.identity);
           StartCoroutine(item.GetComponent<Item>().CoolDown());   
        }
    }

  

    private void ui()
    {
        if (items > 4)
        {
            items = 4;
        }
        else
        {
            if (items == 0)
            {
                uiItems[0].GetComponent<Image>().enabled = false;
                uiItems[1].GetComponent<Image>().enabled = false;
                uiItems[2].GetComponent<Image>().enabled = false;
                uiItems[3].GetComponent<Image>().enabled = false;
            }
            else if (items == 1)
            {
                uiItems[0].GetComponent<Image>().enabled = true;
                uiItems[1].GetComponent<Image>().enabled = false;
                uiItems[2].GetComponent<Image>().enabled = false;
                uiItems[3].GetComponent<Image>().enabled = false;
            }
            else if (items == 2)
            {
                uiItems[0].GetComponent<Image>().enabled = true;
                uiItems[1].GetComponent<Image>().enabled = true;
                uiItems[2].GetComponent<Image>().enabled = false;
                uiItems[3].GetComponent<Image>().enabled = false;
            }
            else if (items == 3)
            {
                uiItems[0].GetComponent<Image>().enabled = true;
                uiItems[1].GetComponent<Image>().enabled = true;
                uiItems[2].GetComponent<Image>().enabled = true;
                uiItems[3].GetComponent<Image>().enabled = false;
            }
            else if (items == 4)
            {
                uiItems[0].GetComponent<Image>().enabled = true;
                uiItems[1].GetComponent<Image>().enabled = true;
                uiItems[2].GetComponent<Image>().enabled = true;
                uiItems[3].GetComponent<Image>().enabled = true;
            }
        }
    }
    
    void Update()
    {
        UseItem();
        ui();
    }
}
