using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Save : MonoBehaviour
{

    [SerializeField] GameObject barreA,barreB;

    GestionD gd;

    public string solution, posA, posB;
    public int nbP1, nbP2, nbP3, nbP4, nbP5, nbP6;
    public int[] tab = new int[25];
    string SaveSeparator = "%VALUE%";
    string sauvSol = "Soluce1.txt";

    // Start is called before the first frame update
    void Start()
    {
        gd = GameObject.Find("GestionDonné").GetComponent<GestionD>();

       
    }


    public void Sauvegard()
    {
        for (int i = 0; i < gd.Tab.Length; i++)
        {
            tab[i] = gd.Tab[i];
        }

        solution = tab[0].ToString();
       for(int i=1;i<tab.Length;i++)
       {
            solution = solution + tab[i].ToString();
       }

        nbP1 = gd.nbCh1;
        nbP2 = gd.nbCh2;
        nbP3 = gd.nbCh3;
        nbP4 = gd.nbCh4;
        nbP5 = gd.nbCh5;
        nbP6 = gd.nbCh6;


        posA = barreA.GetComponent<Dropdown>().captionText.text;
        posB = barreB.GetComponent<Dropdown>().captionText.text;

        string[] content = new string[]
        {
           solution,
           nbP1.ToString(),
           nbP2.ToString(),
           nbP3.ToString(),
           nbP4.ToString(),
           nbP5.ToString(),
           nbP6.ToString(),
           posA,
           posB
        };

        string saveString = string.Join(SaveSeparator, content);

        if(File.Exists(Application.dataPath + "/Save/Facile/P7/" + sauvSol))
        {
            Debug.Log("oucou");
            int nb = 1;
            string savSo = "Soluce";
            while(File.Exists(Application.dataPath + "/Save/Facile/P7/" + sauvSol))
            {
                nb++;
                sauvSol = savSo + nb.ToString()+".txt";
            }
        }

        //Directory.CreateDirectory(Application.dataPath+"/test/test4");
        

        File.WriteAllText(Application.dataPath + "/Save/Facile/P7/" + sauvSol, saveString);
        
        Debug.Log("Sauvegardé");
    }

    
}
