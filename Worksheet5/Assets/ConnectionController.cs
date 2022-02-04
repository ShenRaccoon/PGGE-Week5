using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace PGGE.Mutliplayer{
    public class ConnectionController : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        InputField Inputname;
        [SerializeField]
        Button JoinRoomButton;
        [SerializeField]
        Text connectionStatus;
        [SerializeField]
        int version;
        private bool isConnecting;

        [SerializeField]
        byte maxPlayersPerRoom = 5;

        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            JoinRoomButton.onClick.AddListener(delegate
            {
                Connect();
            });
        }

        public void Connect()
        {
            JoinRoomButton.gameObject.SetActive(false);
            Inputname.gameObject.SetActive(false);
            connectionStatus.gameObject.SetActive(true);
            PhotonNetwork.GameVersion = Application.version;

            // we check if we are connected or not, we join if we are, 
            // else we initiate the connection to the server.
            if (PhotonNetwork.IsConnected)
            {
                // Attempt joining a random Room. 
                // If it fails, we'll get notified in 
                // OnJoinRandomFailed() and we'll create one.
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                // Connect to Photon Online Server.
                isConnecting = PhotonNetwork.ConnectUsingSettings();
            }
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("OnJoinRandomFailed() was called by PUN. " +
                "No random room available" +
                ", so we create one by Calling: " +
                "PhotonNetwork.CreateRoom");

            // Failed to join a random room.
            // This may happen if no room exists or 
            // they are all full. In either case, we create a new room.
            PhotonNetwork.CreateRoom(null,
                new RoomOptions
                {
                    MaxPlayers = maxPlayersPerRoom
                });
        }

        public override void OnConnectedToMaster()
        {
            if (isConnecting)
            {
                Debug.Log("OnConnectedToMaster() was called by PUN");
                PhotonNetwork.JoinRandomRoom();
            }
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogWarningFormat("OnDisconnected() was called by PUN with reason {0} " + cause);
            isConnecting = false;
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("OnJoinedRoom() called by PUN. Client is in a room.");
            if (PhotonNetwork.IsMasterClient)
            {
                //SceneManager.LoadScene("MultiplayerScene1");
                Debug.Log("We load the default room for multiplayer");
                PhotonNetwork.LoadLevel("MultiplayerScene1");
            }
        }


    }
}

