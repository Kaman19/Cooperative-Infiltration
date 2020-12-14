using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GestionD : MonoBehaviour
{
    //public int[] Tab = new int[25];
    public int[] Tab = new int[25];


    public EventSystem eventsy;

    public GameObject debutP, debutC;

    public string temp;

    public int nbCh1 = 0, nbCh2 = 0, nbCh3 = 0, nbCh4 = 0, nbCh5 = 0, nbCh6 = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    public void ChangeSprite(Sprite sp)
    {
        GameObject.Find(temp).GetComponent<Button>().GetComponent<Image>().sprite = sp;
    }

    public void Unselect()
    {
        for (int i = 0; i < Tab.Length; i++)
        {
            GameObject.Find(i.ToString()).GetComponent<Button>().interactable = false;
        }

        eventsy.SetSelectedGameObject(debutC);


    }

    public void Selection()
    {
        for (int i = 0; i < Tab.Length; i++)
        {
            GameObject.Find(i.ToString()).GetComponent<Button>().interactable = true;
        }

        GameObject nPos = GameObject.Find(temp);
        eventsy.SetSelectedGameObject(nPos);
    }
}
