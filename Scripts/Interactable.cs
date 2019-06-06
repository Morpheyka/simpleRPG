using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent _playerAgent;
    private bool _hasInteracted;

    private void Update()
    {
        if(_playerAgent != null && !_playerAgent.pathPending && !_hasInteracted)
        {
            if(_playerAgent.remainingDistance <= _playerAgent.stoppingDistance)
            {
                Interact();
                _hasInteracted = true;
            }
        }
    }

    public virtual void MoveToInteraction(NavMeshAgent playerAgent, RaycastHit interactionInfo)
    {
        _playerAgent = playerAgent;
        _hasInteracted = false;
        playerAgent.stoppingDistance = 2f;
        playerAgent.destination = transform.position;
        LookAt(interactionInfo);
    }

    public void LookAt(RaycastHit interactionInfo)
    {
        Vector3 heightCorrentPoint =
                    new Vector3(interactionInfo.point.x, player.transform.position.y, interactionInfo.point.z);
        player.transform.LookAt(heightCorrentPoint);
    }

    public virtual void Interact()
    {
        Debug.Log("Interact with base class");
    }
}
