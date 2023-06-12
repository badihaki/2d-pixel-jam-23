using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamController : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera camController;

    public void InitializeCamController(Player player)
    {
        GameObject obj = new GameObject("Player Camera Controller");

        camController = obj.AddComponent<CinemachineVirtualCamera>();

        camController.Follow = player.transform;
        camController.LookAt = player.transform;
        camController.Priority = 10;
        camController.m_Lens.Orthographic = true;
        camController.m_Lens.OrthographicSize = 1;
        
        CinemachineFramingTransposer framingTransposer = camController.AddCinemachineComponent<CinemachineFramingTransposer>();
        framingTransposer.m_CameraDistance = 10;
    }
}
