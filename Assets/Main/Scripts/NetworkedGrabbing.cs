using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkedGrabbing : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{

    PhotonView m_photonView;

    private void Awake()
    {
        m_photonView = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void TransferOwnership()
    { 
        m_photonView.RequestOwnership();
    }

    public void OnSelectEntered()
    {
        Debug.Log("Grabbed");
        TransferOwnership();
    }

    public void OnSelectedExited()
    {
        Debug.Log("Released");
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        Debug.Log($"Ownership Requested for: {targetView.name} from {requestingPlayer.NickName}");
        m_photonView.TransferOwnership(requestingPlayer);
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.Log($"OnOwnership Transfered to {targetView.name} from {previousOwner.NickName}");
    }

    public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
    {
        
    }
}
