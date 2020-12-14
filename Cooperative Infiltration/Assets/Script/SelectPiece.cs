using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPiece : MonoBehaviour
{

	GameObject can;

	GameManagerScript gm;

	Image img;
	Sprite sp;
	public int nbPiece = 0;

	private void Awake()
	{
		gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
	}

	private void Start()
	{
		can = GameObject.Find("CChoix");
		//gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

		Init();
		//Debug.Log("test");
		//GetComponentInChildren<Text>().text = nbPiece.ToString();
	}

	//private void Update()
	//{
	//	if(can.activeInHierarchy)
	//	{
	//		Debug.Log("test");
	//	}
	//}

	public void ChoixElement()
	{
		
		UpdateAffiche();
		//GetComponentInChildren<Text>().text = nbPiece.ToString();
		int casChange = gm.Tab[int.Parse(gm.temp)];
		gm.Tab[int.Parse(gm.temp)] = int.Parse(gameObject.name);
		sp = GetComponent<Button>().GetComponent<Image>().sprite;
		gm.ChangeSprite(sp);

		EnlevePiece();
		//nbPiece--;
		if(casChange!=0)
		{
			//can.transform.GetChild(0).gameObject.transform.GetChild(casChange).GetComponent<Button>().GetComponent<Image>().color = Color.blue;

			//can.transform.GetChild(0).gameObject.transform.GetChild(casChange).GetComponent<SelectPiece>().nbPiece++;
			RajoutPiece(casChange);
			

		}






		//if(nbPiece!=0 && gameObject.name != "0")
		//{
		//	GetComponent<Button>().interactable = true;
		//}



		//if (gm.Verification())
		//{

		//	//GameObject.FindGameObjectWithTag
		//	GameObject.Find("CPuzzle").SetActive(false);
		//}
		can.SetActive(false);
		//Destroy(can.gameObject);
		gm.Selection();
	}

	//public void ChoixDeBase()
	//{

	//	if(gm.Tab[int.Parse(gm.temp)]!=0)
	//	{
	//		GameObject.Find()
	//	}
	//	gm.Tab[int.Parse(gm.temp)] = int.Parse(gameObject.name);

	//	sp = GetComponent<Button>().GetComponent<Image>().sprite;
	//	gm.ChangeSprite(sp);



	//	can.SetActive(false);
	//}

	public void Init()
	{
		UpdateAffiche();
		GetComponent<Button>().interactable = true;
		GetComponentInChildren<Text>().text = nbPiece.ToString();
	}

	void EnlevePiece()
	{
		if (int.Parse(gameObject.name) == 1)
		{
			 gm.nbCh1--;
		}
		if (int.Parse(gameObject.name) == 2)
		{
			gm.nbCh2--;
		}
		if (int.Parse(gameObject.name) == 3)
		{
			gm.nbCh3--;
		}
		if (int.Parse(gameObject.name) == 4)
		{
			gm.nbCh4--;
		}
		if (int.Parse(gameObject.name) == 5)
		{
			gm.nbCh5--;
		}
		if (int.Parse(gameObject.name) == 6)
		{
			gm.nbCh6--;
		}

		UpdateAffiche();
	}

	public void UpdateAffiche()
	{
		if (int.Parse(gameObject.name) == 1)
		{
			nbPiece = gm.nbCh1;
		}
		if (int.Parse(gameObject.name) == 2)
		{
			nbPiece = gm.nbCh2;
		}
		if (int.Parse(gameObject.name) == 3)
		{
			nbPiece = gm.nbCh3;
		}
		if (int.Parse(gameObject.name) == 4)
		{
			nbPiece = gm.nbCh4;
		}
		if (int.Parse(gameObject.name) == 5)
		{
			nbPiece = gm.nbCh5;
		}
		if (int.Parse(gameObject.name) == 6)
		{
			nbPiece = gm.nbCh6;
		}
		GetComponentInChildren<Text>().text = nbPiece.ToString();
		if (nbPiece == 0 && gameObject.name != "0")
		{
			GetComponent<Button>().interactable = false;
		}
		if (nbPiece != 0 && gameObject.name != "0")
		{
			GetComponent<Button>().interactable = true;
		}
		//Debug.Log("c'est moi", gameObject);
	}

	void RajoutPiece(int cases)
	{
		if (cases == 1)
		{
			gm.nbCh1++;
			can.transform.GetChild(0).gameObject.transform.GetChild(cases).GetComponentInChildren<Text>().text = gm.nbCh1.ToString();
		}
		if (cases == 2)
		{
			gm.nbCh2++;
			can.transform.GetChild(0).gameObject.transform.GetChild(cases).GetComponentInChildren<Text>().text = gm.nbCh2.ToString();
		}
		if (cases == 3)
		{
			gm.nbCh3++;
			can.transform.GetChild(0).gameObject.transform.GetChild(cases).GetComponentInChildren<Text>().text = gm.nbCh3.ToString();
		}
		if (cases == 4)
		{
			gm.nbCh4++;
			can.transform.GetChild(0).gameObject.transform.GetChild(cases).GetComponentInChildren<Text>().text = gm.nbCh4.ToString();
		}
		if (cases == 5)
		{
			gm.nbCh5++;
			can.transform.GetChild(0).gameObject.transform.GetChild(cases).GetComponentInChildren<Text>().text = gm.nbCh5.ToString();
		}
		if (cases == 6)
		{
			gm.nbCh6++;
			can.transform.GetChild(0).gameObject.transform.GetChild(cases).GetComponentInChildren<Text>().text = gm.nbCh6.ToString();
		}
		UpdateAffiche();
	}
}
