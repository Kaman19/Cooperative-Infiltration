using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class PlayerScript : NetworkBehaviour
{
	//[SerializeField] float speed=4f,rot=80f, shootForce = 100f;

	//[SerializeField] GameObject tir, balle;

	//float axisH, axisV,axiMX,axiMY;

	//public float pv = 100;
	GameManagerScript gm;

	GameObject HUDGame; 

	//public GameObject nouvelleZone;

	//[SerializeField]
	//Vector3 temp, tempRot;

	string namePorte = "",namePartie="";

	public List<PatrolPath> ListPath = new List<PatrolPath>();



	// Start is called before the first frame update
	void Start()
    {
		gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
		//nouvelleZone = GameObject.Find("Spawn");

		foreach (var patrol in FindObjectsOfType<PatrolPath>())
		{
			ListPath.Add(patrol);
		}
	}

    // Update is called once per frame
    void Update()
    {

		//if (Input.GetKeyDown(KeyCode.F))
		//{
		//	//Shoot();
		//}





	}

	//private void FixedUpdate()
	//{
	//	axisH = Input.GetAxis("Horizontal");
	//	axisV = Input.GetAxis("Vertical");

	//	axiMX = Input.GetAxis("Mouse X");
	//	axiMY = Input.GetAxis("Mouse Y");

	//	transform.Translate(Vector3.right * axisH * speed * Time.deltaTime);
	//	transform.Translate(Vector3.forward * axisV * speed * Time.deltaTime);

	//	transform.Rotate(Vector3.up * axiMX * rot * Time.deltaTime);

	//	if (Input.GetKeyDown(KeyCode.Space))
	//	{
	//		//CmdDamage("Player2");
	//	}
	//}

	[Command]
	public void CmdDamage(string _playerID, string porte,int cas)
	{

		//Debug.Log(porte);
		RpcTakeDammage(_playerID,porte,cas);
	}

	[Command]
	public void CmdDamageT(string _playerID, string partieC)
	{

		//Debug.Log(porte);
		RpcTakeDammageT(_playerID, partieC);

	}

	[Command]
	public void CmdFinGame(bool _isWin)
	{
		RpcFinGame(_isWin);
	}

	[ClientRpc]
	void RpcFinGame(bool isWin)
	{
		GameObject uiFinGame = GameObject.Find("GameHUD");

		uiFinGame.transform.GetChild(1).gameObject.SetActive(true);
		uiFinGame.GetComponent<EndGameScipt>().EcritAnnaonce(isWin);

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		//GameObject p2 = GameObject.Find("Player2");

		//p2.GetComponent<Player2script>().CmdFinGame();
	}



	[ClientRpc]
	void RpcTakeDammage(string _playerID,string porte, int cas)
	{
		GameObject p2 = GameObject.Find(_playerID);
		//p2.Vie--;
		p2.GetComponent<Player2script>().RpcTest(porte,cas);

	}

	[ClientRpc]
	void RpcTakeDammageT(string _playerID, string partieC)
	{
		GameObject p2 = GameObject.Find(_playerID);
		//p2.Vie--;
		p2.GetComponent<Player2script>().RpcTestT(partieC);

	}

	[ClientRpc]
	public void RpcRetourTest()
	{
		//transform.position = temp;
		//transform.eulerAngles = tempRot;
		gm.pActiver = false;
		Debug.Log(namePorte);
		GameObject.Find(namePorte).transform.GetChild(0).GetComponentInChildren<Animator>().SetBool("open", true);
		
		GameObject.Find(namePorte).GetComponent<BoxCollider>().enabled = false;

	}

	[ClientRpc]
	public void RpcRetourTestT()
	{
		//transform.position = temp;
		//transform.eulerAngles = tempRot;
		gm.pActiver = false;
		

	}

	[Command]
	public void CmdSpawnE(GameObject ennPreb,GameObject pos)
	{
		//Transform pos = GameObject.Find("SpawnE").transform;

		GameObject e = Instantiate(ennPreb,pos.transform);
		//e.transform.position = spawn.transform.position;
		NetworkServer.Spawn(e);

		foreach (var chemin in ListPath)
		{
			for (int i = 0; i < chemin.enemiesToAssign.Count; i++)
			{
				if (chemin.enemiesToAssign[i] == null)
				{
					chemin.enemiesToAssign[i] = e.GetComponent<EnemyController>();
					chemin.enemiesToAssign[i].patrolPath = chemin.GetComponent<PatrolPath>();


				}
			}
		}
	}


	[Command]
	public void CmdStopPuzzle()
	{
		//RpcStopPuzzle();
		gm.pActiver = false;
		gm.timeOver = false;

	}

	[ClientRpc]
	public void RpcStopPuzzle()
	{
		gm.pActiver = false;
		gm.timeOver = false;
	}


	void InstantiateHUD()
	{
		HUDGame = GameObject.Find("GameHUD");
	}

	//void Shoot()
	//{
	//	GameObject b;


	//	b = Instantiate(balle, tir.transform.position, Quaternion.identity);
	//	b.GetComponent<Rigidbody>().velocity = tir.transform.up * shootForce;
	//}

	//public void TakeDamage()
	//{
	//	pv -= 10;
	//}

	private void OnTriggerEnter(Collider other)
	{
		if((other.tag=="Porte" || other.tag == "TermPorteSp" || other.tag == "TermZone") && isLocalPlayer)
		{
			InstantiateHUD();
			HUDGame.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if ((other.tag == "Porte" || other.tag == "TermPorteSp" || other.tag == "TermZone") && isLocalPlayer)
		{
			
			HUDGame.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Porte")
		{
			if (Input.GetKeyDown(KeyCode.E) && !gm.pActiver)
			{
				//Debug.Log("cas1");
				//temp = gameObject.transform.position;
				//tempRot = gameObject.transform.eulerAngles;
				//gameObject.transform.position = nouvelleZone.transform.position;
				//gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
				Debug.Log("test");
				//CmdDamage("Player2");
				other.GetComponent<DetecteZoneScript>().Pz();
				namePorte = other.name;
				CmdDamage("Player2",other.name,1);

				//cPuzzle.GetComponentInChildren<Button>().GetComponent<ResetScript>().Recommencer();
			}
		}

		if (other.tag == "TermPorteSp")
		{
			if (Input.GetKeyDown(KeyCode.E) && !gm.pActiver)
			{
			//	Debug.Log("cas2");
			//	temp = gameObject.transform.position;
			//	tempRot = gameObject.transform.eulerAngles;
			//	gameObject.transform.position = new Vector3(113, 6, -43);
			//	//gameObject.transform.position = nouvelleZone.transform.position;
			//	gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
				Debug.Log("test");
				//CmdDamage("Player2");
				other.GetComponent<DetecteZoneTerm>().Pz();
				if(other.GetComponent<DetecteZoneTerm>().nPorte==1)
				{
					namePorte = "PorteSP1";
				}
				if (other.GetComponent<DetecteZoneTerm>().nPorte == 2)
				{
					namePorte = "PorteSP2";
				}

				CmdDamage("Player2", namePorte,2);

				//cPuzzle.GetComponentInChildren<Button>().GetComponent<ResetScript>().Recommencer();
			}
		}



		if (other.tag == "TermZone")
		{
			if (Input.GetKeyDown(KeyCode.E) && !gm.pActiver)
			{
				//Debug.Log("cas3");
				//temp = gameObject.transform.position;
				//tempRot = gameObject.transform.eulerAngles;
				//gameObject.transform.position = nouvelleZone.transform.position;
				//gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
				//Debug.Log("test");
				other.GetComponent<TerminalCarte>().Pz();
				if (other.GetComponent<TerminalCarte>().nTerm == 1)
				{
					namePartie = "CBouton";
				}
				if (other.GetComponent<TerminalCarte>().nTerm == 2)
				{
					namePartie = "CBouton2";
				}
				CmdDamageT("Player2", namePartie);
				//CmdDamage2("Player2");

				//cPuzzle.GetComponentInChildren<Button>().GetComponent<ResetScript>().Recommencer();
			}
		}

	}

	
}
