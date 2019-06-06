using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private NavMeshAgent _playerAgent;
    private WeaponControl _weaponController;
    private CharacterStats _charStats;
        
    private void Start()
    {
        _playerAgent = GetComponent<NavMeshAgent>();
        _weaponController = GetComponent<WeaponControl>();
        _charStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GetInteraction();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _weaponController.Attack();
        }
    }

    private void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if(Physics.Raycast(interactionRay, out interactionInfo))
        {
            GameObject interactionObject = interactionInfo.collider.gameObject;
            if(interactionObject.tag == "Interactable object" || interactionObject.tag == "Enemy")
            {
                interactionObject.GetComponent<Interactable>().MoveToInteraction(_playerAgent, interactionInfo);
            }
            else if(!EventSystem.current.IsPointerOverGameObject())
            {
                _playerAgent.stoppingDistance = 0f;
                _playerAgent.destination = interactionInfo.point;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        _charStats.stats[StatsList.CurHP].FinalValue -= damage;
        Debug.Log("WOW I TAKE " + damage + " damage!");
        _charStats.CalculateHP();
        if(_charStats.stats[StatsList.CurHP].CalculatedStatValue() <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
