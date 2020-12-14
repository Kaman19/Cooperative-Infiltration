using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPieceLD : MonoBehaviour
{
	GameObject can;

	GestionD gd;


	Image img;
	Sprite sp;
	public int  nbPiece=0;


	private void Awake()
	{
		gd = GameObject.Find("GestionDonné").GetComponent<GestionD>();
	}

	private void Start()
	{
		can = GameObject.Find("CChoixLD");

		Init();
	}

	public void Init()
	{
		UpdateAffiche();
		GetComponent<Button>().interactable = true;
		GetComponentInChildren<Text>().text = nbPiece.ToString();
	}


	public void ChoixElement()
	{
		UpdateAffiche();

		int casChange = gd.Tab[int.Parse(gd.temp)];
		gd.Tab[int.Parse(gd.temp)] = int.Parse(gameObject.name);
		sp = GetComponent<Button>().GetComponent<Image>().sprite;
		gd.ChangeSprite(sp);

		AjoutePiece();
		//nbPiece--;
		if (casChange != 0)
		{

			RetirePiece(casChange);


		}

		can.SetActive(false);
		gd.Selection();
	}


	public void UpdateAffiche()
	{
		if (int.Parse(gameObject.name) == 1)
		{
			nbPiece = gd.nbCh1;
		}
		if (int.Parse(gameObject.name) == 2)
		{
			nbPiece = gd.nbCh2;
		}
		if (int.Parse(gameObject.name) == 3)
		{
			nbPiece = gd.nbCh3;
		}
		if (int.Parse(gameObject.name) == 4)
		{
			nbPiece = gd.nbCh4;
		}
		if (int.Parse(gameObject.name) == 5)
		{
			nbPiece = gd.nbCh5;
		}
		if (int.Parse(gameObject.name) == 6)
		{
			nbPiece = gd.nbCh6;
		}
		GetComponentInChildren<Text>().text = nbPiece.ToString();
		//if (nbPiece == 0 && gameObject.name != "0")
		//{
		//	GetComponent<Button>().interactable = false;
		//}
		//if (nbPiece != 0 && gameObject.name != "0")
		//{
		//	GetComponent<Button>().interactable = true;
		//}
		//Debug.Log("c'est moi", gameObject);
	}

	void AjoutePiece()
	{
		if (int.Parse(gameObject.name) == 1)
		{
			gd.nbCh1++;
		}
		if (int.Parse(gameObject.name) == 2)
		{
			gd.nbCh2++;
		}
		if (int.Parse(gameObject.name) == 3)
		{
			gd.nbCh3++;
		}
		if (int.Parse(gameObject.name) == 4)
		{
			gd.nbCh4++;
		}
		if (int.Parse(gameObject.name) == 5)
		{
			gd.nbCh5++;
		}
		if (int.Parse(gameObject.name) == 6)
		{
			gd.nbCh6++;
		}

		UpdateAffiche();
	}

	void RetirePiece(int cases)
	{
		if (cases == 1)
		{
			gd.nbCh1--;
			can.transform.GetChild(0).gameObject.transform.GetChild(cases).GetComponentInChildren<Text>().text = gd.nbCh1.ToString();
		}
		if (cases == 2)
		{
			gd.nbCh2--;
			can.transform.GetChild(0).gameObject.transform.GetChild(cases).GetComponentInChildren<Text>().text = gd.nbCh2.ToString();
		}
		if (cases == 3)
		{
			gd.nbCh3--;
			can.transform.GetChild(0).gameObject.transform.GetChild(cases).GetComponentInChildren<Text>().text = gd.nbCh3.ToString();
		}
		if (cases == 4)
		{
			gd.nbCh4--;
			can.transform.GetChild(0).gameObject.transform.GetChild(cases).GetComponentInChildren<Text>().text = gd.nbCh4.ToString();
		}
		if (cases == 5)
		{
			gd.nbCh5--;
			can.transform.GetChild(0).gameObject.transform.GetChild(cases).GetComponentInChildren<Text>().text = gd.nbCh5.ToString();
		}
		if (cases == 6)
		{
			gd.nbCh6--;
			can.transform.GetChild(0).gameObject.transform.GetChild(cases).GetComponentInChildren<Text>().text = gd.nbCh6.ToString();
		}
		UpdateAffiche();
	}

}
