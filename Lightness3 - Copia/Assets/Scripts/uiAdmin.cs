using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiAdmin : MonoBehaviour
{
    
    public GameObject luz;
    public GameObject jg;
    public GameObject Win;
    public GameObject Lose;
    public GameObject Back;
    public bool setWin;
    public Slider slider;
   

    public IEnumerator Reduzbarra()
    {
        
        LightCreation light = luz.GetComponent<LightCreation>();
        if (light.lightOn == false)
        {
            yield return new WaitForSeconds(0.5f);
            if (slider.value > 0 && setWin == false)
            {
                slider.value -= 0.005f;
                StartCoroutine(Reduzbarra());
                //Debug.Log("Reduzbarra");
              
            }
            else if (slider.value <= 0)
            {
                StopCoroutine(Reduzbarra());
                Destroy(jg);
                Lose.SetActive(true);
                Back.SetActive(true);
            }
        }
        else
        {
            StartCoroutine(PerdeBarra());
        }
       
    }
    public IEnumerator PerdeBarra()
    {
        
        LightCreation light = luz.GetComponent<LightCreation>();
        if (light.lightOn == true)
        {
            yield return new WaitForSeconds(0.3f);
            if (slider.value > 0)
            {
                slider.value -= 0.025f;
                StartCoroutine(PerdeBarra());
                //Debug.Log("PerdeBarra");
            }
            else
            {
                StopCoroutine(PerdeBarra());
                Destroy(jg);
                Lose.SetActive(true);
                Back.SetActive(true);
            }
        }
        else
        {
            StartCoroutine(Reduzbarra());
        }
    }

    public void MenuReturn()
    {
        SceneManager.LoadScene("Menu");
    }

    void Start()
    {
        StartCoroutine(Reduzbarra());
        Win.SetActive(false);
        Lose.SetActive(false);
        Back.SetActive(false);
        setWin = false;
    }

  
    void Update()
    {
        
    }
}
