using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;

    public GameObject[] rooms; //index 0 --> DE, index 1 --> DEB, index 2 --> DET, index 3 --> DETB
    public GameObject[] pivots;
    public GameObject Player;
    public AstarPath scan;
    

    private int direction;
    public float moveAmount;
    private int downCounter;

    private float timeBtwnRoom;
    public float startTimeBtwnRoom = 0.25f;

    public float minX;
    public float maxX;
    public float minY;
    public bool stopGen;

    public LayerMask room;
    private void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        Player.transform.position = new Vector3 (startingPositions[randStartingPos].position.x, startingPositions[randStartingPos].position.y, -0.03f);
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);
    }
    private void Update()
    {
        if (timeBtwnRoom <= 0 && stopGen == false)
        {
            Move();
            timeBtwnRoom = startTimeBtwnRoom;
        }
        else
        {
            timeBtwnRoom -= Time.deltaTime;
        }
    }

    private void Move()
    {
        if (direction == 1 || direction == 2) //Mover pra direita
        {
            if (transform.position.x < maxX)
            {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
                if (direction == 3)
                {
                    direction = 2;
                }
                else if (direction == 4)
                {
                    direction = 5;
                }
            }
            else { direction = 5; }
        }
        else if (direction == 3 || direction == 4) //Mover pra esquerda
        {
            if (transform.position.x > minX)
            {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);

            }
            else { direction = 5; }
        }
        else if (direction == 5) //Mover pra baixo
        {
            downCounter++;

            if (transform.position.y > minY)
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 2, room);
                if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3)
                {
                    if (downCounter >= 2)
                    {
                        roomDetection.GetComponent<RoomType>().roomDestruction();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    }
                    else
                    {
                        roomDetection.GetComponent<RoomType>().roomDestruction();

                        int randBottomRoom = Random.Range(1, 4);
                        if (randBottomRoom == 2)
                        {
                            randBottomRoom = 1;
                        }
                        Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                        Debug.Log("ACHOOOW");
                    }
                }

                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;

                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
            }
            else
            {
                stopGen = true;
                foreach (GameObject gb in pivots)
                {
                    Vector2 point = new Vector2(gb.transform.position.x, gb.transform.position.y);
                    Collider2D roomDetection = Physics2D.OverlapCircle(point, 1f, room);
                    if (!roomDetection && stopGen == true)
                    {
                        gb.GetComponent<SpawnRoom>().Spawn();

                        //Debug.Log(gb.name);
                    }
                    Destroy(gb);
                    StartCoroutine(WaitScan());
                }
                
                }
           
        }
       

    }
    public IEnumerator WaitScan()
    {
        yield return new WaitForSeconds(0.5f);
        scan.Scan();
        StopCoroutine(WaitScan()); 
    }

}
