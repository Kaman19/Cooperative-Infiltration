using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoixPersoScript : MonoBehaviour
{
   Vector3 pos,pos2;

    private void Start()
    {
        pos = new Vector3(65f, 1f, -35f);
        pos2 = new Vector3(2f, -12f, -6f);
    }


    public void Choix1()
    {
       
        GameObject.Find("Player1").GetComponent<PlayerSetUp>().CmdChoixRole(1,pos,pos2);
        GameObject.Find("Player2").GetComponent<PlayerSetUp>().CmdChoixRole(1,pos,pos2);
        Destroy(GameObject.Find("CPerso").gameObject);
    }

    public void Choix2()
    {
        //pos = GameObject.Find("Player1").transform.position;
        //pos2 = GameObject.Find("Player2").transform.position;
        GameObject.Find("Player1").GetComponent<PlayerSetUp>().CmdChoixRole(2, pos, pos2);
        GameObject.Find("Player2").GetComponent<PlayerSetUp>().CmdChoixRole(2, pos, pos2);
        Destroy(GameObject.Find("CPerso").gameObject);
    }
}
