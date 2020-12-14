using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class PlayerSetUp : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Behaviour[] contentToDisable;


    Camera sceneCamera;

    /// <summary>
    /// UI
    /// </summary>
    public GameObject playerUIPrefab,playerHUD;
    public GameObject Choix;
    public GameObject playerUIInstance;
    public GameObject cBouton, cBouton2;


    public GameObject pointMap;

    GameObject player2;

    int idtest=0;



    private void Start()
    {
        
        idtest = int.Parse(GetComponent<NetworkIdentity>().netId.ToString());
        string _ID = "Player" + idtest;
        transform.name = _ID;

        if (!isLocalPlayer)
        {
            for (int i = 0; i < contentToDisable.Length; i++)
            {
                contentToDisable[i].enabled = false;

            }


        }
        else
        {

            
                playerUIInstance = Instantiate(playerUIInstance);
                playerUIInstance.name = "CPerso";
            

            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                Camera.main.gameObject.SetActive(false);
            }
            playerHUD = Instantiate(playerHUD);
            playerHUD.name = "GameHUD";
            //playerUIPrefab = Instantiate(playerUIPrefab);



            //if (idtest == 2)
            //{
            //    for (int i = 0; i < contentToDisable.Length; i++)
            //    {
            //        contentToDisable[i].enabled = false;
            //    }
            //    // contentToDisable[1].enabled = true;
            //    pointMap.SetActive(false);
            //    gameObject.transform.GetChild(1).gameObject.SetActive(true);
            //    gameObject.transform.GetChild(2).gameObject.SetActive(true);
            //    playerUIPrefab = Instantiate(playerUIPrefab);
            //    playerUIPrefab.name = "CPuzzle";

            //    GetComponent<Player2script>().enabled = true;

            //    Choix = Instantiate(Choix);
            //    Choix.name = "CChoix";

            //    cBouton = Instantiate(cBouton);
            //    cBouton.name = "CBouton";

            //    cBouton2 = Instantiate(cBouton2);
            //    cBouton2.name = "CBouton2";

            //    GameObject.Find("TerCarte").GetComponent<TerminalCarte>().controleZone = cBouton;
            //    GameObject.Find("CBouton").SetActive(false);

            //    GameObject.Find("TerCarte2").GetComponent<TerminalCarte>().controleZone = cBouton2;
            //    GameObject.Find("CBouton2").SetActive(false);
            //}
        }




        Debug.Log(idtest);

    }


    public void CmdChoixRole(int choixr, Vector3 pos, Vector3 pos2)
    {
        if (choixr == 1)
        {
           if(isLocalPlayer)
            {
                
                if(idtest==2)
                {
                    transform.position = new Vector3( pos.x,pos.y+2f,pos.z);
                }
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }
            //CmdTestChoix(pos, pos2);
        }
        if (choixr == 2)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);

            if (isLocalPlayer)
            {
                GameObject.Find("GameHUD").SetActive(false);
                if(idtest==1)
                {
                    transform.position = new Vector3(pos2.x, pos2.y + 2f, pos2.z); 
                }

               

                for (int i = 0; i < contentToDisable.Length; i++)
                {
                    contentToDisable[i].enabled = false;
                }
                // contentToDisable[1].enabled = true;
                pointMap.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                playerUIPrefab = Instantiate(playerUIPrefab);
                playerUIPrefab.name = "CPuzzle";

                GetComponent<Player2script>().enabled = true;

                Choix = Instantiate(Choix);
                Choix.name = "CChoix";

                cBouton = Instantiate(cBouton);
                cBouton.name = "CBouton";

                cBouton2 = Instantiate(cBouton2);
                cBouton2.name = "CBouton2";

                GameObject.Find("TerCarte").GetComponent<TerminalCarte>().controleZone = cBouton;
                GameObject.Find("CBouton").SetActive(false);

                GameObject.Find("TerCarte2").GetComponent<TerminalCarte>().controleZone = cBouton2;
                GameObject.Find("CBouton2").SetActive(false);
            }
            //CmdTestChoix2( pos,  pos2);
            

        }

    }



    [Command]
    void CmdTestChoix2(Vector3 pos, Vector3 pos2)
    {
        RpcTestChoix2(pos, pos2);
    }

    [Command]
    void CmdTestChoix(Vector3 pos, Vector3 pos2)
    {
        //RpcTestChoix(pos, pos2);
       

    }

    [ClientRpc]
   void RpcTestChoix2(Vector3 pos, Vector3 pos2)
    {
        GameObject.Find("Player1").transform.position = pos2;
        GameObject.Find("Player2").transform.position = pos;

        if(isLocalPlayer)
        {
            if(idtest==1)
            {
                for (int i = 0; i < contentToDisable.Length; i++)
                {
                    contentToDisable[i].enabled = false;
                }
                // contentToDisable[1].enabled = true;
                pointMap.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                playerUIPrefab = Instantiate(playerUIPrefab);
                playerUIPrefab.name = "CPuzzle";

                GetComponent<Player2script>().enabled = true;

                Choix = Instantiate(Choix);
                Choix.name = "CChoix";

                cBouton = Instantiate(cBouton);
                cBouton.name = "CBouton";

                cBouton2 = Instantiate(cBouton2);
                cBouton2.name = "CBouton2";

                GameObject.Find("TerCarte").GetComponent<TerminalCarte>().controleZone = cBouton;
                GameObject.Find("CBouton").SetActive(false);

                GameObject.Find("TerCarte2").GetComponent<TerminalCarte>().controleZone = cBouton2;
                GameObject.Find("CBouton2").SetActive(false);
            }
        }
    }

    [ClientRpc]
    void RpcTestChoix(Vector3 pos, Vector3 pos2)
    {


        Debug.Log("prout");
        GameObject pl2 = GameObject.Find("Player2");
            
                 Debug.Log("prout2");
                for (int i = 0; i < contentToDisable.Length; i++)
                {
                    pl2.GetComponent<PlayerSetUp>().contentToDisable[i].enabled = false;
                }
            // contentToDisable[1].enabled = true;
                pl2.GetComponent<PlayerSetUp>().pointMap.SetActive(false);
                pl2.GetComponent<PlayerSetUp>().gameObject.transform.GetChild(1).gameObject.SetActive(true);
                pl2.GetComponent<PlayerSetUp>().gameObject.transform.GetChild(2).gameObject.SetActive(true);
                pl2.GetComponent<PlayerSetUp>().playerUIPrefab = Instantiate(playerUIPrefab);
                pl2.GetComponent<PlayerSetUp>().playerUIPrefab.name = "CPuzzle";

                pl2.GetComponent<Player2script>().enabled = true;

                pl2.GetComponent<PlayerSetUp>().Choix = Instantiate(Choix);
                pl2.GetComponent<PlayerSetUp>().Choix.name = "CChoix";

                pl2.GetComponent<PlayerSetUp>().cBouton = Instantiate(cBouton);
                pl2.GetComponent<PlayerSetUp>().cBouton.name = "CBouton";

                pl2.GetComponent<PlayerSetUp>().cBouton2 = Instantiate(cBouton2);
                pl2.GetComponent<PlayerSetUp>().cBouton2.name = "CBouton2";

                GameObject.Find("TerCarte").GetComponent<TerminalCarte>().controleZone = cBouton;
                GameObject.Find("CBouton").SetActive(false);

                GameObject.Find("TerCarte2").GetComponent<TerminalCarte>().controleZone = cBouton2;
                GameObject.Find("CBouton2").SetActive(false);
            
        
    }

    [Command]
    void CmdChoix2(Vector3 pos, Vector3 pos2)
    {
        RpcChoix2(pos, pos2);
    }

    [ClientRpc]
    void RpcChoix2(Vector3 pos, Vector3 pos2)
    {
        if (GetComponent<PlayerScript>().enabled)
        {
            transform.position = pos;
            print("Changealalal?");
        }
        else
        {
            transform.position = pos2;
            transform.eulerAngles = new Vector3(0, 0, 0);
            //player2 = GameObject.Find("Player2");
            //player2.transform.position = pos;
            //player2.GetComponent<Player2script>().enabled = false;
            //player2.GetComponent<PlayerScript>().enabled = false;
            //player2.GetComponent<PlayerSetUp>().pointMap.SetActive(true);
            //player2.GetComponent<PlayerSetUp>().gameObject.transform.GetChild(1).gameObject.SetActive(false);




            print("change?");

        }
    }

    [Command]
    void CmdChoix()
    {
        RpcChoix();
    }

    [ClientRpc]
    void RpcChoix()
    {
        contentToDisable[1].enabled = true;
        pointMap.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        playerUIPrefab = Instantiate(playerUIPrefab);
        playerUIPrefab.name = "CPuzzle";

        GetComponent<Player2script>().enabled = true;

        Choix = Instantiate(Choix);
        Choix.name = "CChoix";
    }

    public void OnDisable()
    {

    }
}
