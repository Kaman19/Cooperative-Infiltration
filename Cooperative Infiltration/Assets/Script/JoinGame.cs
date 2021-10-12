using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class JoinGame : MonoBehaviour
{

	List<GameObject> roomList = new List<GameObject>();

	[SerializeField]
	Text status;

	[SerializeField]
	GameObject roomListItemPrefab;

	[SerializeField]
	Transform roomListParent;

	private NetworkManager networkManager;



	private void Start()
	{
		networkManager = NetworkManager.singleton;
		if(networkManager.matchMaker==null)
		{
			networkManager.StartMatchMaker();
		}

		RefeshRoomList();
	}

	public void RefeshRoomList()
	{
		ClearRoomList();
		networkManager.matchMaker.ListMatches(0, 10, "", false, 0, 0, OnMatchList);
		status.text = "Refreshing...";
	}

	public void OnMatchList(bool sucess, string extendedInfo, List<MatchInfoSnapshot> matchList)
	{
		status.text = "";
		if(matchList==null)
		{
			status.text = "couldn't get match list.";
			return;
		}

		

		foreach(MatchInfoSnapshot match in matchList)
		{
			GameObject _roomListItemGo = Instantiate(roomListItemPrefab);
			_roomListItemGo.transform.SetParent(roomListParent);
			_roomListItemGo.transform.localScale = new Vector3(1, 1, 1);

			RoomListItem _roomListItem = _roomListItemGo.GetComponent<RoomListItem>();

			if(_roomListItem!=null)
			{
				_roomListItem.Setup(match,JoinRoom);
			}

			roomList.Add(_roomListItemGo);
		}

		if(roomList.Count==0)
		{
			status.text = "No rooms available";
		}
	}

	void ClearRoomList()
	{
		for (int i = 0; i < roomList.Count; i++)
		{
			Destroy(roomList[i]);
		}

		roomList.Clear();
	}


	public void JoinRoom(MatchInfoSnapshot _match)
	{
		networkManager.matchMaker.JoinMatch(_match.networkId, "", "", "", 0, 0, networkManager.OnMatchJoined);
		ClearRoomList();
		status.text = "JOINING...";
	}

}
