using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPorteScript : MonoBehaviour
{

    public GameObject Porte;
   
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name== "BPorte1")
        {
            Porte = GameObject.Find("PorteTest");
        }
        if (gameObject.name == "BPorte2")
        {
            Porte = GameObject.Find("PorteTest (1)");
        }
        if (gameObject.name == "BPorte3")
        {
            Porte = GameObject.Find("PorteTest (2)");
        }
        if (gameObject.name == "BPorte4")
        {
            Porte = GameObject.Find("PorteTest (3)");
        }
        if (gameObject.name == "BPorte5")
        {
            Porte = GameObject.Find("PorteTest (9)");
        }
        if (gameObject.name == "BPorte6")
        {
            Porte = GameObject.Find("PorteTest (4)");
        }
        if (gameObject.name == "BPorte7")
        {
            Porte = GameObject.Find("PorteTest (5)");
        }
        if (gameObject.name == "BPorte8")
        {
            Porte = GameObject.Find("PorteTest (8)");
        }
        if (gameObject.name == "BPorte9")
        {
            Porte = GameObject.Find("PorteTest (10)");
        }
        if (gameObject.name == "BPorte10")
        {
            Porte = GameObject.Find("PorteTest (6)");
        }
        if (gameObject.name == "BPorte11")
        {
            Porte = GameObject.Find("PorteTest (7)");
        }
    }

    

    public void OpenClose()
    {
        if(Porte.GetComponent<DetecteZoneScript>().activer)
        {
            
            GameObject.Find("Player2").GetComponent<Player2script>().ControlePorte(Porte.name, false);
        }
        else
        {
            GameObject.Find("Player2").GetComponent<Player2script>().ControlePorte(Porte.name, true);
           
        }
    }
}
