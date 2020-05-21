using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCreation : MonoBehaviour
{
    public GameObject Light;
    public GameObject Parent;
    public GameObject Jg;
    public bool lightOn;

    private void OnMouseDown()
    {
        foreach (Transform child in Parent.transform)
        {
            Destroy(child.gameObject);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Player player = Jg.gameObject.GetComponent<Player>();
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "LightCreation" && player.isMoving == false)
            {
                Vector3 pointPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                Debug.Log("Clicked a tile");
                Instantiate(Light, pointPosition, Quaternion.identity, Parent.transform);
                lightOn = true;
            }
        }
    }

   private void OnMouseUp()
    {
        foreach (Transform child in Parent.transform)
        {
          Destroy(child.gameObject);
          lightOn = false;
        }
    }

 

}
