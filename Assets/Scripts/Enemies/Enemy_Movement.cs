using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_Movement : MonoBehaviour
{
    private int currentHealth;
    private int maxHealth;

    public abstract IEnumerator Move();

    public abstract void TakeDamage(int dmg);

    public abstract void Stun();
}
