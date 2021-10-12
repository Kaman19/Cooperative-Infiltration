using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleMort : MonoBehaviour
{

    GameObject back;
    // Start is called before the first frame update
    void Start()
    {
        back = GameObject.Find("Ennemi");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("coucouc");
            back.GetComponent<EnemyController>().isBack = true;

        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("plplplplplllplpppl");
            back.GetComponent<EnemyController>().isBack = false;
        }
    }
}
