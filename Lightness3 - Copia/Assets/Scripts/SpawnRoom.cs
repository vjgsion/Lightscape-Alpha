using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    public LayerMask whatIsRoom;
    public LevelGeneration levelGen;
    public int inimigos;
    public GameObject[] emptyRooms;



    public void Spawn()
    {
        inimigos = GameObject.FindGameObjectsWithTag("Inimigo").Length;
            int rand = Random.Range(0, 9);
        if (rand == 0 || rand == 1)
        {
            Instantiate(levelGen.rooms[0], transform.position, Quaternion.identity);
        }
        else if (rand == 2 || rand == 3)
        {
            Instantiate(levelGen.rooms[1], transform.position, Quaternion.identity);
        }
        else if (rand == 4 || rand == 5)
        {
            Instantiate(levelGen.rooms[2], transform.position, Quaternion.identity);
        }
       else if (rand == 6 || rand == 7)
        {
            Instantiate(levelGen.rooms[3], transform.position, Quaternion.identity);
        }
       else if (rand == 8 && inimigos <= 2)
        {
            Instantiate(levelGen.rooms[4], transform.position, Quaternion.identity);  
        }
        else
        {
            int randemptyRoom = Random.Range(0, emptyRooms.Length);
            Instantiate(emptyRooms[randemptyRoom], transform.position, Quaternion.identity);
        }

        //Instantiate(levelGen.rooms[rand], transform.position, Quaternion.identity);       
    }

  
}

