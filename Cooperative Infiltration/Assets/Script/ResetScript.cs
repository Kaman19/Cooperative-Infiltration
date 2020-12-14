using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{

	GameManagerScript gm;

	SelectPiece[] TabButton;

	private void Start()
	{
		gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
	}

	public void Recommencer()
	{
		//gm.Init();
		int rstTypePuzzle = gm.choixPuzzle;

		gm.RandomPuzzle(rstTypePuzzle);
		gm.InitTab();

		TabButton = FindObjectsOfType<SelectPiece>();

		for(int i=0;i<TabButton.Length;i++)
		{
			TabButton[i].Init();
		}
	}
}
