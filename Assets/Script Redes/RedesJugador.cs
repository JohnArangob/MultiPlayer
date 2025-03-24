using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class RedesJugador : MonoBehaviour
{
    public MonoBehaviour[] codigosQueIgnorar;


    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            foreach (var codigo in codigosQueIgnorar)
            {
                codigo.enabled = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
