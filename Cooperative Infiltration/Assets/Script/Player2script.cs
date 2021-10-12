using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;

public class Player2script : NetworkBehaviour
{

    //Faire la même chose pour la deuxième porte

    GameManagerScript gm;

    [SerializeField]
    GameObject playerUIPrefab,cBtn,cBtn2;

   
    //public GameObject   nouvelleZone;

    //Vector3 temp, tempRot;

    //string solution = "";
    //string SaveSeparator = "%VALUE%";
    //string sauvSol = "Soluce1.txt";

    string namePorte = "", namePartie= "";

    // Start is called before the first frame update
    void Start()
    {
        playerUIPrefab = GetComponent<PlayerSetUp>().playerUIPrefab;
        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
       // nouvelleZone = GameObject.Find("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // Sauvegard();
            //CmdDamage("Player2");
        }
    }

    [ClientRpc]
    public void RpcTest(string porte,int cas)
    {
        if(isLocalPlayer)
        {

            Debug.Log("coucougjkgkgfjhgf");
            cBtn = GameObject.Find("CBouton");
            cBtn2 = GameObject.Find("CBouton2");
           if(cBtn!=null)
           {
                Debug.Log("Cbtn");
                cBtn.SetActive(false);
                
           }
           if (cBtn2 != null)
           {
                Debug.Log("Cbtn2");
                cBtn2.SetActive(false);
                
           }

            playerUIPrefab.SetActive(true);
            playerUIPrefab.transform.GetChild(2).gameObject.GetComponent<TimerScript>().Go();
            //GameObject.Find("CPuzzle").SetActive(true);

            namePorte = porte;
          //  Debug.Log(namePorte);
            gm.Init();
            gm.pActiver = true;
            if(cas==1)
            {
                GameObject.Find(namePorte).GetComponent<DetecteZoneScript>().Isme = true;
            }
            if(cas==2)
            {
                if(namePorte== "PorteSP1")
                {
                    GameObject.Find("TabBord").GetComponent<DetecteZoneTerm>().Isme = true;
                }
                if (namePorte == "PorteSP2")
                {
                    GameObject.Find("TabBord (1)").GetComponent<DetecteZoneTerm>().Isme = true;
                }
                
            }

            //GameObject.Find("Timer").GetComponent<TimerScript>().Go();
            //GameObject.Find("Timer").GetComponent<TimerScript>().PosRetour(temp, tempRot);
        }
    }

    

    [ClientRpc]
    public void RpcTestT(string partie)
    {
        if (isLocalPlayer)
        {

            cBtn = GameObject.Find("CBouton");
            cBtn2 = GameObject.Find("CBouton2");
            if (cBtn != null)
            {
                Debug.Log("Cbtn");
                cBtn.SetActive(false);

            }
            if (cBtn2 != null)
            {
                Debug.Log("Cbtn2");
                cBtn2.SetActive(false);

            }
            playerUIPrefab.SetActive(true);
            playerUIPrefab.transform.GetChild(2).gameObject.GetComponent<TimerScript>().Go();
            //GameObject.Find("CPuzzle").SetActive(true);

            namePartie = partie;
            //  Debug.Log(namePorte);
            gm.Init();
            gm.pActiver = true;
            if(namePartie== "CBouton")
            {
                GameObject.Find("TerCarte").GetComponent<TerminalCarte>().Isme = true;
            }
            if (namePartie == "CBouton2")
            {
                GameObject.Find("TerCarte2").GetComponent<TerminalCarte>().Isme = true;
            }

            //GameObject.Find("Timer").GetComponent<TimerScript>().Go();
            //GameObject.Find("Timer").GetComponent<TimerScript>().PosRetour(temp, tempRot);
        }
    }

    //[ClientRpc]
    //public void RpcPosJ1(Collider other)
    //{
    //    temp = other.gameObject.transform.position;
    //    tempRot = other.gameObject.transform.eulerAngles;
    //    other.gameObject.transform.position = nouvelleZone.transform.position;
    //    other.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
    //}

    public void OuvrePorte(int typePorte)
    {
        Debug.Log(namePorte + "player2");
        GameObject.Find(namePorte).transform.GetChild(0).GetComponentInChildren<Animator>().SetBool("open", true);
        GameObject.Find(namePorte).GetComponent<BoxCollider>().enabled = false;
        GameObject.Find(namePorte).transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.green;
        if (typePorte==1)
        {
            GameObject.Find(namePorte).GetComponent<DetecteZoneScript>().activer = true;
        }
        

        
        
    }

    public void Carte()
    {
        if (cBtn != null)
        {

            cBtn.SetActive(true);

        }
        if (cBtn2 != null)
        {

            cBtn2.SetActive(true);

        }
    }

    [Command]
    public void CmdRetourPlayer()
    {
        
        RpcRetour();
       

    }

    [Command]
    public void CmdRetourPlayerT()
    {

        RpcRetourT();


    }


    [ClientRpc]
    public void RpcRetour()
    {
        
       
        GameObject.Find("Player1").GetComponent<PlayerScript>().RpcRetourTest();
    }

    [ClientRpc]
    public void RpcRetourT()
    {


        GameObject.Find("Player1").GetComponent<PlayerScript>().RpcRetourTestT();
    }



    public void ControlePorte(string tPorte, bool isOpen)
    {
        CmdContrlePorte(tPorte, isOpen);
        
    }

    [Command]
    void CmdContrlePorte(string tPorte,bool isOpen)
    {
        RpcControlePorte(tPorte,  isOpen);
       
    }

    [ClientRpc]
    void RpcControlePorte(string tPorte, bool isOpen)
    {
        
        GameObject tPorteN = GameObject.Find(tPorte);
        tPorteN.GetComponentInChildren<Animator>().SetBool("open", isOpen);
        tPorteN.transform.GetChild(0).GetComponentInChildren<Animator>().SetBool("open", isOpen);
        tPorteN.GetComponent<DetecteZoneScript>().activer = isOpen;
        if(isOpen)
        {
            tPorteN.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (!isOpen)
        {
            tPorteN.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.red;
        }

    }

    [Command]
    public void CmdStopPuzzle()
	{
        RpcStopPuzzle();


	}

    [ClientRpc]
    void RpcStopPuzzle()
	{
        gm.pActiver = false;
        gm.timeOver = false;

        GameObject.Find("Player1").GetComponent<PlayerScript>().RpcStopPuzzle();
    }


    [Command]
    public void CmdFinGame()
    {
        RpcFinGame();
    }


    void RpcFinGame()
    {
        GameObject uiFinGame = GameObject.Find("GameHUD");

        uiFinGame.transform.GetChild(1).gameObject.SetActive(true);
    }

    //public void Sauvegard()
    //{


    //    solution = "test";


    //    string[] content = new string[]
    //    {
    //       solution

    //    };

    //    string saveString = string.Join(SaveSeparator, content);

    //    Directory.CreateDirectory(Application.dataPath + "/test/test4");

    //    //if (File.Exists(Application.dataPath + "/test/SaveH/Facile/" + sauvSol))
    //    //{
    //    //    Debug.Log("oucou");
    //    //    int nb = 1;
    //    //    string savSo = "Soluce";
    //    //    while (File.Exists(Application.dataPath + "/SaveH/Facile/" + sauvSol))
    //    //    {
    //    //        nb++;
    //    //        sauvSol = savSo + nb.ToString() + ".txt";
    //    //    }
    //    //}

    //    //// Directory.CreateDirectory(Application.dataPath+"/test/test4");


    //    // File.WriteAllText(Application.dataPath + "/SaveH/Facile/" + sauvSol, saveString);

    //    Debug.Log("Sauvegardé");
    //}


}
