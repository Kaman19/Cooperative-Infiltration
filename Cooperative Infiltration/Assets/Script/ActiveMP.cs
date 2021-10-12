using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMP : MonoBehaviour
{

    [SerializeField]
    GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
		{
            TogglePauseMenu();
		}
    }

    void TogglePauseMenu()
	{
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PauseMenu.isOn = pauseMenu.activeSelf;
       
	}
}
