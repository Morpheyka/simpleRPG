using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    List<BaseStat> Stats { get; set; }

    void TakeDamage(int damage);
    void PerformAttack();
}
