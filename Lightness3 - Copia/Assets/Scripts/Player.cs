using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public bool isMoving = false;

    public Sprite Vela;
    public Sprite Abajur;

    public GameObject canvas;
    public GameObject lightCreation;
    public GameObject innerLight;
    public GameObject bombLight;
    public bool blowUp;
   
    private void changeCharacter()
    {
        SpriteRenderer Jogator = gameObject.GetComponent<SpriteRenderer>();
        if (Input.GetKeyUp("e"))
        {
            Debug.Log("EEEEEEEEEEEEEEEEE");
            if (Jogator.sprite == Abajur && blowUp == false)
            {
                Jogator.sprite = Vela;
                Light2D radius = innerLight.gameObject.GetComponent<Light2D>();
                radius.pointLightOuterRadius = 3.5f;
                lightCreation.SetActive(false);
            }
            else if (Jogator.sprite == Vela && blowUp == false)
            {
                Jogator.sprite = Abajur;
                Light2D radius = innerLight.gameObject.GetComponent<Light2D>();
                radius.pointLightOuterRadius = 5f;
                lightCreation.SetActive(true);
            }
        }
    }

    private void Movement()
    {
        Vector2 movement = Vector2.zero;
        if (Input.GetAxis("Vertical") != 0)
        {
            movement = new Vector2(0, Input.GetAxis("Vertical"));
            isMoving = true;
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            movement = new Vector2(Input.GetAxis("Horizontal"), 0);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        transform.Translate(movement * speed * Time.deltaTime);
    }
       
    void Lightness()
    {
        LightCreation Light = lightCreation.GetComponent<LightCreation>();

        if (Light.lightOn == true)
        {
            speed = 0;
        }
        else
        {
            speed = 10;
            Movement();
        }
    }

    private void Explosion()
    {
        SpriteRenderer Jogator = gameObject.GetComponent<SpriteRenderer>();
        if (blowUp == false && Jogator.sprite == Vela && Input.GetMouseButton(0))
        {
            Debug.Log("indo?");
            bombLight.SetActive(true);
            Light2D radius = bombLight.gameObject.GetComponent<Light2D>();
            radius.pointLightOuterRadius = 16f;
            StartCoroutine(LightUp());
            uiAdmin adm = canvas.gameObject.GetComponent<uiAdmin>();
            adm.slider.value -= 0.10f;
        }
    }
    public IEnumerator LightUp()
    {
        blowUp = true;
        Light2D radius = bombLight.gameObject.GetComponent<Light2D>();
        radius.pointLightOuterRadius -= 0.32f;
        yield return new WaitForSeconds(0.05f);
        if (radius.pointLightOuterRadius <= 0)
        {
            StopCoroutine(LightUp());
            bombLight.SetActive(false);
            innerLight.SetActive(true);
            blowUp = false;
        }
        else
        {
            StartCoroutine(LightUp());
            innerLight.SetActive(false);
        }
    }
    private void Start()
    {
       
    }

    void Update()
    {
        changeCharacter();
        Lightness();
        Explosion();
    }

   
}
