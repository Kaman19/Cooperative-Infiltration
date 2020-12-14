using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using UnityEngine.Networking;

public class GameManagerScript : MonoBehaviour
{
	public int[] Tab = new int[25];
	
	public List<string> TabSolucte = new  List<string>();

	public string etatTab;

	string SaveSeparator = "%VALUE%";
	int nbS = 0;

	[SerializeField] Sprite spdefaut;

	public string temp;
	public int nbCh1 = 0, nbCh2 = 0, nbCh3 = 0, nbCh4 = 0, nbCh5 = 0, nbCh6 = 0,choixPuzzle=0;

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

		bool win = false;

		etatTab = Tab[0].ToString();
		for (int i = 1; i < Tab.Length; i++)
		{
			etatTab = etatTab + Tab[i].ToString();
		}


		for(int i=0;i<TabSolucte.Count;i++)
		{
			if(etatTab==TabSolucte[i])
			{
				win = true;
			}
		}


		//Debug.Log("verif");

		return win;
		
	}
	
	
	public void Init()
	{
		
		InitTab();
		InitSoluc();
		choixPuzzle = Random.Range(1, 11);
		
		

		RandomPuzzle(choixPuzzle);

		debutP = GameObject.Find("CPuzzle").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

		eventsy.SetSelectedGameObject(debutP);


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

		TabSolucte.Clear();
		
	}

	public void Unselect( )
	{
		debutC = GameObject.Find("CChoix").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

		for (int i=0;i<Tab.Length;i++)
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

	public void RandomPuzzle( int tPuzzle)
	{

		//int typePuzzle = tPuzzle;

		string saveString, nPuzzle, nSoluce;
		nbS = 1;
		string[] content = null; ;
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



		nPuzzle = tPuzzle.ToString();
		nSoluce = nbS.ToString();
		//saveString = File.ReadAllText(Application.dataPath + "/Save/Facile/P" + nPuzzle + "/Soluce" + nbS + ".txt");
		//content = saveString.Split(new[] { SaveSeparator }, System.StringSplitOptions.None);


		while (File.Exists(Application.dataPath + "/Save/Facile/P" + nPuzzle + "/Soluce" + nSoluce + ".txt"))
		{
			saveString = File.ReadAllText(Application.dataPath + "/Save/Facile/P" + nPuzzle + "/Soluce" + nSoluce + ".txt");
			content = saveString.Split(new[] { SaveSeparator }, System.StringSplitOptions.None);

			TabSolucte.Add(content[0]);

			nbS++;
			nSoluce = nbS.ToString();



		}


		nbCh1 = int.Parse(content[1]);
		nbCh2 = int.Parse(content[2]);
		nbCh3 = int.Parse(content[3]);
		nbCh4 = int.Parse(content[4]);
		nbCh5 = int.Parse(content[5]);
		nbCh6 = int.Parse(content[6]);

		GameObject.Find(content[7]).transform.GetChild(1).gameObject.SetActive(true);
		GameObject.Find(content[8]).transform.GetChild(1).gameObject.SetActive(true);


		

	}



}
