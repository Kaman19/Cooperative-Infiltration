using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DetecteZoneScript : MonoBehaviour
{
	
	public GameObject cPuzzle=null,challenge,nouvelleZone;

	

	Vector3 temp,tempRot;

	GameManagerScript gm;

	Animator anim;
	Collider col;
	public bool activer = false;

	
	public bool Isme = false;
	

	// Start is called before the first frame update
	void Start()
    {
		gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
		anim = GetComponentInChildren<Animator>();
		//anim = transform.GetChild(0).GetComponent<Animator>();
		col = GetComponent<BoxCollider>();

	}


	private void Update()
	{
		if(gm.Verification() && gm.pActiver && Isme )
		{

			Debug.Log("2");
			cPuzzle = GameObject.Find("CPuzzle");
			
			

			//GameObject.Find("Timer").GetComponent<TimerScript>().Stop();
			challenge.SetActive(false);
			//anim.SetBool("open", true);
			//col.enabled = false;
			//GameObject.Find("Player1").transform.position = temp;
			//GameObject.Find("Player1").transform.eulerAngles = tempRot;
			GameObject.Find("Player2").GetComponent<Player2script>().CmdRetourPlayer();
			GameObject.Find("Player2").GetComponent<Player2script>().OuvrePorte(1);
			GameObject.Find("Player2").GetComponent<Player2script>().Carte();

			cPuzzle.SetActive(false);
			gm.pActiver = false;
			Isme = false;

		}
	}


	private void OnTriggerStay(Collider other)
	{
		if(other.tag=="Player")
		{
			if(Input.GetKeyDown(KeyCode.M) && !gm.pActiver)
			{
				temp = other.gameObject.transform.position;
				tempRot = other.gameObject.transform.eulerAngles;
				other.gameObject.transform.position = nouvelleZone.transform.position;
				other.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
				//ActivePuzzle("Player2");
				challenge.SetActive(true);
				challenge.gameObject.GetComponent<ChallengeScript>().activation = true;

				//cPuzzle.GetComponentInChildren<Button>().GetComponent<ResetScript>().Recommencer();
			}
		}
	}


	public void Pz()
	{
		//temp = other.gameObject.transform.position;
		//tempRot = other.gameObject.transform.eulerAngles;
		//other.gameObject.transform.position = nouvelleZone.transform.position;
		//other.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
		gm.pActiver = true;
		//Isme = true;
		//ActivePuzzle("Player2");
		challenge.SetActive(true);
		challenge.gameObject.GetComponent<ChallengeScript>().activation = true;

	}

	////[Command]
	//void ActivePuzzle( string _playerID)
	//{

	//	//cPuzzle.SetActive(true);
	//	Rpctest(_playerID);

	//	//gm.Init();
	//	//gm.pActiver = true;

	//	//GameObject.Find("Timer").GetComponent<TimerScript>().Go();
	//	//GameObject.Find("Timer").GetComponent<TimerScript>().PosRetour(temp, tempRot);
	//}
	
	////[ClientRpc]
	//void Rpctest(string _playerID)
	//{
	//	GameObject p2 = GameObject.Find(_playerID);
	//	Debug.Log(p2);
	//	p2.GetComponent<Player2script>().RpcTest();
	//}
}
