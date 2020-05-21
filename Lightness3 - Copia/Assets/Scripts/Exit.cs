using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject jg;
    public GameObject Canvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(jg);
            Debug.Log("caxumba");
            uiAdmin win = Canvas.GetComponent<uiAdmin>();
            win.Win.SetActive(true);
            win.setWin = true;
            win.Back.SetActive(true);
        }
        if (other.gameObject.CompareTag("Inimigo"))
        {
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        
    }
}
