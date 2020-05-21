using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject Canvas;
    private Pathfinding.AIPath call;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
        Destroy(Player);
        uiAdmin text = Canvas.GetComponent<uiAdmin>();
        text.Lose.SetActive(true);
        text.Back.SetActive(true);
        }
        if (other.gameObject.CompareTag("Light"))
        {
            Debug.Log("FUK U");
            call.maxSpeed = 3;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            Debug.Log("FUK U");
            call.maxSpeed = 0;
        }
    }
    void Start()
    {
        Pathfinding.AIDestinationSetter target = GetComponent<Pathfinding.AIDestinationSetter>();
        Player = GameObject.Find("Player");
        target.target = Player.transform;
        Canvas = GameObject.Find("Canvas");
        call = GetComponent<Pathfinding.AIPath>();
        call.maxSpeed = 0;
    }

  
    void Update()
    {
       
    }
}
