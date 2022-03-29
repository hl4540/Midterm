using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirm : MonoBehaviour
{
    public GameObject[] correctChoiseList;
    public GameObject[] Lines;
    public GameObject diactivateButton;
    public GameObject activateButton;
    //public Text navigation;
    private bool isActive;

    public Material dissolveMat;
    public float fade;

    float timeElapsed;
    public float lerpDuration = 1;


    void Awake()
    {
        fade = 1.4f;
        dissolveMat.SetFloat("_fade",fade);
        isActive = false;
    }



    public void CheckActive()
    {
        
        for(int i = 0; i < correctChoiseList.Length; i++)
        {
            if(correctChoiseList[i].activeInHierarchy)
            {
                isActive = true;
            }else
            {
                isActive = false;
                break;
            }
        }
        Debug.Log("all correct is:" + isActive);
        if(isActive == true)
        {
            StartCoroutine(ActivateLine());
            
        }else{
            //navigation.text = "not right";

        }
    }

    void Update()
    {
        if(isActive == true && timeElapsed < lerpDuration)
            {
                //Debug.Log(alpha);
                dissolveMat.SetFloat("_fade",fade);
                fade = Mathf.Lerp(1f, 0f, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
            }
    }

    IEnumerator ActivateLine()
    {
        for(int x = 0; x < Lines.Length; x++)
        {
            Lines[x].SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(2f);
        diactivateButton.SetActive(false);
        activateButton.SetActive(true);
        
        


        
        //navigation.text = "CONGRATULATIONS!!!!!!!this is the correct answer";
        //yield return new WaitForSeconds(3f);
        //navigation.text = "Yuri looked at the window and noticed the rain is over,";
        //yield return new WaitForSeconds(3f);
        //navigation.text = "but she still grabbed her umbrella because she's gonna go home.";
        
    }
}
