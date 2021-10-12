using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class EndGameScipt : MonoBehaviour
{
    [SerializeField]
    Text txtAnnonce;

	NetworkManager networkManager;

	private void Start()
	{
		networkManager = NetworkManager.singleton;
	}

	public void LeaveRoomButtonEndGame()
	{
		MatchInfo matchInfo = networkManager.matchInfo;
		networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, networkManager.OnDropConnection);
		networkManager.StopHost();
	}




	public void EcritAnnaonce(bool isWin)
	{
        if(isWin)
		{
            txtAnnonce.text = "Victoire";
		}
        else
		{
            txtAnnonce.text = "Défaite";
        }

        Debug.Log(txtAnnonce.text);
	}
}
