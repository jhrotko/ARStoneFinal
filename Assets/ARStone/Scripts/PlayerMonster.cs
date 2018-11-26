using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonster : Monster
{
    private bool attacking = false;
    private bool defending = false;

    private float AttackTimer = 0.0f;
    private float DefendTimer = 0.0f;

    public float GetAttackTimer()
    {
        return AttackTimer;
    }

    public float GetDefendTimer()
    {
        return DefendTimer;
    }

    public void SetAttackTimer(float time)
    {
        AttackTimer = time;
    }

    public void SetDefendTimer(float time)
    {
        DefendTimer = time;
    }

    public void Attacking(bool atck)
    {
        attacking = atck;
    }

    public bool GetAttacking()
    {
        return attacking;
    }

    public void Defending(bool dfnd)
    {
        defending = dfnd;
    }

    public bool GetDefending()
    {
        return defending;
    }

}
