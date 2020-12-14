using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetecteZoneTerm : MonoBehaviour
{
	//a modifier pour indiquer quel type de difficulter le puzzle doit etre

	public GameObject cPuzzle = null, challenge, nouvelleZone;

	Vector3 temp, tempRot;

	GameManagerScript gm;

	public int nPorte;

	Animator anim;
	Collider col;
	//bool activer = false;
	
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
		if (gm.Verification() && gm.pActiver && Isme )
		{

			Debug.Log("1");
			cPuzzle = GameObject.Find("CPuzzle");



			//GameObject.Find("Timer").GetComponent<TimerScript>().Stop();
			//challenge.SetActive(false);
			//anim.SetBool("open", true);
			//col.enabled = false;
			//GameObject.Find("Player1").transform.position = temp;
			//GameObject.Find("Player1").transform.eulerAngles = tempRot;
			cPuzzle.SetActive(false);
			GameObject.Find("Player2").GetComponent<Player2script>().CmdRetourPlayer();
			GameObject.Find("Player2").GetComponent<Player2script>().OuvrePorte(2);
			GameObject.Find("Player2").GetComponent<Player2script>().Carte();

			
			gm.pActiver = false;
			Isme = false;

		}
	}


	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			if (Input.GetKeyDown(KeyCode.M) && !gm.pActiver)
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



}
