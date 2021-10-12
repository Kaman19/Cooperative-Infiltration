using UnityEngine;
using UnityEngine.Networking;

public class HostGame : MonoBehaviour
{
	private uint roomSize = 2;

	private string roomName;

	private NetworkManager networkManager;

	private void Start()
	{
		networkManager = NetworkManager.singleton;
		if(networkManager.matchMaker==null)
		{
			networkManager.StartMatchMaker();
		}
	}

	public void SetRoomName(string _name)
	{
		roomName = _name;
	}

	public void  CreateRoom()
	{
		if(roomName!="" && roomName!=null)
		{
			Debug.Log("Créaction de la partie : " + roomName + " avec " + roomSize + " place.");

			//créer la partie
			networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);

		}
	}
}
