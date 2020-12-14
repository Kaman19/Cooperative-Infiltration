using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
	[SerializeField]
	GameObject Choix;

	GameManagerScript gm;

    // Start is called before the first frame update
    void Start()
    {
		gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
		Choix = GameObject.Find("Player2").GetComponent<PlayerSetUp>().Choix;
    }

	public void WriteX()
	{

		gm.temp = gameObject.name;



		Choix.SetActive(true);
		//GameObject.Find("CChoix").SetActive(true);
		gm.Unselect();


		for (int i=1;i<7;i++)
		{
			Choix.transform.GetChild(0).transform.GetChild(i).GetComponent<SelectPiece>().UpdateAffiche();
		}
		

		//GetComponentInChildren<Text>().text = "♀";
		//GetComponent<Button>().interactable = false;
		//gm.Tab[int.Parse(gameObject.name)] = "X";

		
	}

	
}
