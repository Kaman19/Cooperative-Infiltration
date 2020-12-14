using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionLevelD : MonoBehaviour
{
	[SerializeField]
	GameObject Choix;

	GestionD gd;

	// Start is called before the first frame update
	void Start()
	{
		gd = GameObject.Find("GestionDonné").GetComponent<GestionD>();
	}

	public void WriteX()
	{
		//Debug.Log(gameObject.name);
		gd.temp = gameObject.name;

		//Debug.Log(gd.temp);

		Choix.SetActive(true);
		gd.Unselect();


		for (int i = 1; i <7; i++)
		{
			Choix.transform.GetChild(0).transform.GetChild(i).GetComponent<SelectPieceLD>().UpdateAffiche();
		}


		//GetComponentInChildren<Text>().text = "X";
	}

}
