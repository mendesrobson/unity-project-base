using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Unity.Cinemachine;
using StarterAssets;

public class MoveManager : MonoBehaviourPun
{
    private ThirdPersonController _thirdPerson;
    private PlayerInput _playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _thirdPerson = GetComponent<ThirdPersonController>();
        _playerInput = GetComponent<PlayerInput>();
        var vcam = GetComponentInChildren<CinemachineCamera>();

        // Impede que todos os jogadores tenham controle sobre a câmera e o personagem, garantindo que cada jogador controle apenas seu próprio personagem.
        var isLocalPlayer = photonView.IsMine;

        if (!isLocalPlayer)
        {
            // Desativa o controle do personagem e da câmera para os jogadores que não são locais
            if (_thirdPerson != null) _thirdPerson.enabled = false;
            if(_playerInput != null) _playerInput.enabled = false;

            // Desativa a câmera para os jogadores que não são locais
            if (vcam != null) vcam.Priority = 0;
        }
        else
        {
            // Ativa o controle do personagem e da câmera para o jogador local
            if (_thirdPerson != null) _thirdPerson.enabled = true;
            if (_playerInput != null) _playerInput.enabled = true;

            // Ativa a câmera para o jogador local
            if (vcam != null) vcam.Priority = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
