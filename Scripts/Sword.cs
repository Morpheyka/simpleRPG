using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator _animator;
    public List<BaseStat> Stats { get; set; }
    public float timeBetweenAttack;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        _animator.SetTrigger("BasicAttack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {

            other.GetComponent<IEnemy>().TakeDamage(Stats[StatsList.Power].CalculatedStatValue());
        }
    }
}
