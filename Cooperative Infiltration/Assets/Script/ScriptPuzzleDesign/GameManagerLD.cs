using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManagerLD : MonoBehaviour
{
	public int[] Tab = new int[25];
	int[] TabSoluce = new int[25];
	int[] TabSoluce2 = new int[25];
	int[] TabSoluce3 = new int[25];
	int[] TabSoluce4 = new int[25];
	int[] TabSoluce5 = new int[25];
	int[] TabSoluce6 = new int[25];
	int[] TabSoluce7 = new int[25];
	int[] TabSoluce8 = new int[25];
	int[] TabSoluce9 = new int[25];

	[SerializeField] Sprite spdefaut;

	public string temp;
	public int nbCh1 = 0, nbCh2 = 0, nbCh3 = 0, nbCh4 = 0, nbCh5 = 0, nbCh6 = 0, choixPuzzle = 0;

	public Sprite spriteBase;

	public EventSystem eventsy;

	public GameObject debutP, debutC;

	public bool pActiver = false;


	// Start is called before the first frame update
	void Start()
	{


	}

	public void ChangeSprite(Sprite sp)
	{
		GameObject.Find(temp).GetComponent<Button>().GetComponent<Image>().sprite = sp;
	}


	public bool Verification()
	{

		bool win = true;

		if (choixPuzzle == 0)
		{
			if (!VSol1())
			{
				win = false;
			}
		}

		if (choixPuzzle == 1)
		{
			if (!VSol1() && !VSol2() && !VSol3() && !VSol4() && !VSol5() && !VSol6() && !VSol7() && !VSol8() && !VSol9())
			{
				win = false;
			}
		}

		if (choixPuzzle == 2)
		{
			if (!VSol1() && !VSol2() && !VSol3() && !VSol4() && !VSol5())
			{
				win = false;
			}
		}


		return win;

	}


	bool VSol1()
	{

		for (int i = 0; i < TabSoluce.Length; i++)
		{
			if (Tab[i] != TabSoluce[i])
			{
				return false;
			}
		}
		return true;
	}

	bool VSol2()
	{

		for (int i = 0; i < Tab.Length; i++)
		{
			if (Tab[i] != TabSoluce2[i])
			{
				return false;
			}
		}
		return true;
	}

	bool VSol3()
	{

		for (int i = 0; i < Tab.Length; i++)
		{
			if (Tab[i] != TabSoluce3[i])
			{
				return false;
			}
		}
		return true;
	}

	bool VSol4()
	{

		for (int i = 0; i < Tab.Length; i++)
		{
			if (Tab[i] != TabSoluce4[i])
			{
				return false;

			}

		}

		return true;
	}

	bool VSol5()
	{

		for (int i = 0; i < Tab.Length; i++)
		{
			if (Tab[i] != TabSoluce5[i])
			{
				return false;
			}
		}
		return true;
	}

	bool VSol6()
	{


		for (int i = 0; i < Tab.Length; i++)
		{
			if (Tab[i] != TabSoluce6[i])
			{
				return false;
			}
		}
		return true;
	}

	bool VSol7()
	{

		for (int i = 0; i < Tab.Length; i++)
		{
			if (Tab[i] != TabSoluce7[i])
			{
				return false;
			}
		}
		return true;
	}


	bool VSol8()
	{

		for (int i = 0; i < Tab.Length; i++)
		{
			if (Tab[i] != TabSoluce8[i])
			{
				return false;
			}
		}
		return true;
	}

	bool VSol9()
	{

		for (int i = 0; i < Tab.Length; i++)
		{
			if (Tab[i] != TabSoluce9[i])
			{
				return false;
			}
		}
		return true;
	}

	public void Init()
	{

		InitTab();
		InitSoluc();
		choixPuzzle = Random.Range(0, 3);

		RandomPuzzle(choixPuzzle);


	}

	public void InitTab()
	{
		spriteBase = spdefaut;
		for (int i = 0; i < Tab.Length; i++)
		{
			Tab[i] = 0;
			
			GameObject.Find(i.ToString()).GetComponent<Button>().GetComponent<Image>().sprite = spriteBase;
		}
	}

	public void InitSoluc()
	{
		for (int i = 0; i < TabSoluce.Length; i++)
		{

			TabSoluce[i] = 0;
			TabSoluce2[i] = 0;
			TabSoluce3[i] = 0;
			TabSoluce4[i] = 0;
			TabSoluce5[i] = 0;
			TabSoluce6[i] = 0;
			TabSoluce7[i] = 0;
			TabSoluce8[i] = 0;
			TabSoluce9[i] = 0;

		}
	}

	public void Unselect()
	{
		for (int i = 0; i < Tab.Length; i++)
		{
			GameObject.Find(i.ToString()).GetComponent<Button>().interactable = false;
		}

		eventsy.SetSelectedGameObject(debutC);


	}

	public void Selection()
	{
		for (int i = 0; i < Tab.Length; i++)
		{
			GameObject.Find(i.ToString()).GetComponent<Button>().interactable = true;
		}

		GameObject nPos = GameObject.Find(temp);
		eventsy.SetSelectedGameObject(nPos);
	}

	public void RandomPuzzle(int tPuzzle)
	{

		int typePuzzle = tPuzzle;
		//int typePuzzle = 2;

		// Affichage lettre A
		GameObject.Find("0").transform.GetChild(1).gameObject.SetActive(false);
		GameObject.Find("5").transform.GetChild(1).gameObject.SetActive(false);
		GameObject.Find("10").transform.GetChild(1).gameObject.SetActive(false);
		GameObject.Find("15").transform.GetChild(1).gameObject.SetActive(false);
		GameObject.Find("20").transform.GetChild(1).gameObject.SetActive(false);

		// Affichage lettre B
		GameObject.Find("4").transform.GetChild(1).gameObject.SetActive(false);
		GameObject.Find("9").transform.GetChild(1).gameObject.SetActive(false);
		GameObject.Find("14").transform.GetChild(1).gameObject.SetActive(false);
		GameObject.Find("19").transform.GetChild(1).gameObject.SetActive(false);
		GameObject.Find("24").transform.GetChild(1).gameObject.SetActive(false);


		switch (typePuzzle)
		{
			case 0:
				TabSoluce[10] = 1;
				TabSoluce[11] = 1;
				TabSoluce[12] = 1;
				TabSoluce[13] = 1;
				TabSoluce[14] = 1;
				nbCh1 = 5;
				nbCh2 = 0;
				nbCh3 = 0;
				nbCh4 = 0;
				nbCh5 = 0;
				nbCh6 = 0;

				GameObject.Find("10").transform.GetChild(1).gameObject.SetActive(true);
				GameObject.Find("14").transform.GetChild(1).gameObject.SetActive(true);

				break;

			case 1:
				//Soluce 1
				TabSoluce[10] = 1;
				TabSoluce[11] = 3;
				TabSoluce[16] = 5;
				TabSoluce[17] = 3;
				TabSoluce[22] = 5;
				TabSoluce[23] = 4;
				TabSoluce[18] = 2;
				TabSoluce[13] = 2;
				TabSoluce[8] = 6;
				TabSoluce[9] = 1;

				////soluce 2
				TabSoluce2[10] = 3;
				TabSoluce2[15] = 5;
				TabSoluce2[16] = 1;
				TabSoluce2[17] = 3;
				TabSoluce2[22] = 5;
				TabSoluce2[23] = 4;
				TabSoluce2[18] = 2;
				TabSoluce2[13] = 2;
				TabSoluce2[8] = 6;
				TabSoluce2[9] = 1;


				////soluce 3
				TabSoluce3[10] = 3;
				TabSoluce3[15] = 5;
				TabSoluce3[16] = 3;
				TabSoluce3[21] = 5;
				TabSoluce3[22] = 1;
				TabSoluce3[23] = 4;
				TabSoluce3[18] = 2;
				TabSoluce3[13] = 2;
				TabSoluce3[8] = 6;
				TabSoluce3[9] = 1;

				////soluce 4
				TabSoluce4[10] = 3;
				TabSoluce4[15] = 5;
				TabSoluce4[16] = 3;
				TabSoluce4[21] = 5;
				TabSoluce4[22] = 4;
				TabSoluce4[17] = 2;
				TabSoluce4[12] = 2;
				TabSoluce4[7] = 6;
				TabSoluce4[8] = 1;
				TabSoluce4[9] = 1;


				////soluce 5
				TabSoluce5[10] = 3;
				TabSoluce5[15] = 5;
				TabSoluce5[16] = 3;
				TabSoluce5[21] = 5;
				TabSoluce5[22] = 1;
				TabSoluce5[23] = 1;
				TabSoluce5[24] = 4;
				TabSoluce5[19] = 2;
				TabSoluce5[14] = 2;
				TabSoluce5[9] = 6;



				////soluce 6
				TabSoluce6[10] = 1;
				TabSoluce6[11] = 1;
				TabSoluce6[12] = 3;
				TabSoluce6[17] = 5;
				TabSoluce6[18] = 3;
				TabSoluce6[23] = 5;
				TabSoluce6[24] = 4;
				TabSoluce6[19] = 2;
				TabSoluce6[14] = 2;
				TabSoluce6[9] = 6;

				////soluce 7
				TabSoluce7[10] = 3;
				TabSoluce7[15] = 5;
				TabSoluce7[16] = 1;
				TabSoluce7[17] = 1;
				TabSoluce7[18] = 3;
				TabSoluce7[23] = 5;
				TabSoluce7[24] = 4;
				TabSoluce7[19] = 2;
				TabSoluce7[14] = 2;
				TabSoluce7[9] = 6;

				////soluce 8
				TabSoluce8[10] = 1;
				TabSoluce8[11] = 3;
				TabSoluce8[16] = 5;
				TabSoluce8[17] = 3;
				TabSoluce8[22] = 5;
				TabSoluce8[23] = 1;
				TabSoluce8[24] = 4;
				TabSoluce8[19] = 2;
				TabSoluce8[14] = 2;
				TabSoluce8[9] = 6;


				////soluce 9
				TabSoluce9[10] = 1;
				TabSoluce9[11] = 3;
				TabSoluce9[16] = 5;
				TabSoluce9[17] = 1;
				TabSoluce9[18] = 3;
				TabSoluce9[23] = 5;
				TabSoluce9[24] = 4;
				TabSoluce9[19] = 2;
				TabSoluce9[14] = 2;
				TabSoluce9[9] = 6;

				//nombre de piece
				nbCh1 = 2;
				nbCh2 = 2;
				nbCh3 = 2;
				nbCh4 = 1;
				nbCh5 = 2;
				nbCh6 = 1;

				GameObject.Find("10").transform.GetChild(1).gameObject.SetActive(true);
				GameObject.Find("9").transform.GetChild(1).gameObject.SetActive(true);
				break;

			case 2:

				TabSoluce[0] = 3;
				TabSoluce[5] = 5;
				TabSoluce[6] = 3;
				TabSoluce[11] = 5;
				TabSoluce[12] = 3;
				TabSoluce[17] = 5;
				TabSoluce[18] = 3;
				TabSoluce[23] = 5;
				TabSoluce[24] = 1;


				////soluce 2
				TabSoluce2[0] = 1;
				TabSoluce2[1] = 3;
				TabSoluce2[6] = 5;
				TabSoluce2[7] = 3;
				TabSoluce2[12] = 5;
				TabSoluce2[13] = 3;
				TabSoluce2[18] = 5;
				TabSoluce2[19] = 3;
				TabSoluce2[24] = 5;


				////soluce 3
				TabSoluce3[0] = 3;
				TabSoluce3[5] = 5;
				TabSoluce3[6] = 1;
				TabSoluce3[7] = 3;
				TabSoluce3[12] = 5;
				TabSoluce3[13] = 3;
				TabSoluce3[18] = 5;
				TabSoluce3[19] = 3;
				TabSoluce3[24] = 5;


				////soluce 4
				TabSoluce4[0] = 3;
				TabSoluce4[5] = 5;
				TabSoluce4[6] = 3;
				TabSoluce4[11] = 5;
				TabSoluce4[12] = 1;
				TabSoluce4[13] = 3;
				TabSoluce4[18] = 5;
				TabSoluce4[19] = 3;
				TabSoluce4[24] = 5;



				////soluce 5
				TabSoluce5[0] = 3;
				TabSoluce5[5] = 5;
				TabSoluce5[6] = 3;
				TabSoluce5[11] = 5;
				TabSoluce5[12] = 3;
				TabSoluce5[17] = 5;
				TabSoluce5[18] = 1;
				TabSoluce5[19] = 3;
				TabSoluce5[24] = 5;


				nbCh1 = 1;
				nbCh2 = 0;
				nbCh3 = 4;
				nbCh4 = 0;
				nbCh5 = 4;
				nbCh6 = 0;

				GameObject.Find("0").transform.GetChild(1).gameObject.SetActive(true);
				GameObject.Find("24").transform.GetChild(1).gameObject.SetActive(true);

				break;
		}

	}
}
