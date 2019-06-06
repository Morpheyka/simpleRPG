using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ogre : MonoBehaviour, IEnemy
{
    public LayerMask aggroLayerMask;
    public NavMeshAgent navAgent;
    public List<BaseStat> Stats { get; set; }
    private Collider[] _aggroColliders;
    private Player _player;

    public void PerformAttack()
    {
        _player.TakeDamage(Stats[StatsList.Power].CalculatedStatValue());
    }

    private void FixedUpdate()
    {
        _aggroColliders = Physics.OverlapSphere(transform.position, 10, aggroLayerMask);
        if(_aggroColliders.Length > 0)
        {
            Chase(_aggroColliders[0].GetComponent<Player>());
        }
    }

    public void TakeDamage(int damage)
    {
        Stats[StatsList.CurHP].BaseValue -= damage;
        Debug.Log("HP: " + Stats[StatsList.CurHP].CalculatedStatValue());
        if(Stats[StatsList.CurHP].BaseValue <= 0)
        {
            Die();
        }
    }

    private void Chase(Player player)
    {
        navAgent.SetDestination(player.transform.position);
        _player = player;
        if(navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            if (!IsInvoking("PerformAttack"))
            {
                InvokeRepeating("PerformAttack", 1f, 2f);
            }
            else
            {
                CancelInvoke("PerformAttack");
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

        Stats = new List<BaseStat>(3);
        Stats.Add(new BaseStat(1, "Power", "Ogre power level."));
        Stats.Add(new BaseStat(10, "MaxHP", "Ogre maximum health."));
        Stats.Add(new BaseStat(Stats[StatsList.MaxHP].BaseValue, "CurrentHP", "Ogre current hp."));
    }

    void Update()
    {
        
    }
}
