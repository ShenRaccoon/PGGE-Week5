using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    string PlayerPrefabName;
    [SerializeField]
    Spawner mSpawner;

    private GameObject mPlayerGameObject;
    private ThirdPersonCamera mThirdPersonCamera;


    private void Start()
    {
        CreatePlayer();
    }

    public void CreatePlayer()
    {
        mPlayerGameObject = PhotonNetwork.Instantiate(PlayerPrefabName, mSpawner.GetSpawnPoint().position, mSpawner.GetSpawnPoint().rotation);

        mPlayerGameObject.GetComponent<PlayerMovement>().mFollowCameraForward = false;
        mThirdPersonCamera = Camera.main.gameObject.AddComponent<ThirdPersonCamera>();
        mThirdPersonCamera.mPlayer = mPlayerGameObject.transform;
        mThirdPersonCamera.mDamping = 20.0f;
        mThirdPersonCamera.mCameraType = CameraType.Follow_Track_Pos_Rot;
    }

}
