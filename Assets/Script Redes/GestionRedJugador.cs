using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionRedJugador : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectToPhoton();
    }

    void ConnectToPhoton()
    {
        if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("Conectando a Photon...");
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado a Photon Master Server.");
        JoinOrCreateRoom();
    }

    void JoinOrCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions { MaxPlayers = 2 };

        // Intenta unirse a una sala existente
        PhotonNetwork.JoinRandomRoom();

        Debug.Log("Intentando unirse a una sala existente...");


        // Si no hay salas disponibles, crea una nueva sala
        if (!PhotonNetwork.InRoom)
        {
            Debug.Log("No se pudo unir a una sala existente. Creando nueva sala...");
            PhotonNetwork.CreateRoom(null, roomOptions, TypedLobby.Default);
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No se pudo unir a una sala existente. Creando nueva sala...");
        RoomOptions roomOptions = new RoomOptions { MaxPlayers = 2 };
        PhotonNetwork.CreateRoom(null, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        int jugadoresConectados = PhotonNetwork.CurrentRoom.PlayerCount;

            Vector3 spawnPosition = new Vector3(0, 0, 0);
            PhotonNetwork.Instantiate("Player", spawnPosition, Quaternion.identity);
            Debug.Log("Jugador 1 unido a la sala");
        
     

    }

}
