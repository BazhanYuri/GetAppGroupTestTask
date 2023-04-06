using UnityEngine;
using Cinemachine;


[System.Serializable]
public class CameraManager 
{
    [SerializeField] private CinemachineVirtualCamera _playerCamera;
    



    public void SetPlayer(Transform player)
    {
        _playerCamera.Follow = player;
    }
}
