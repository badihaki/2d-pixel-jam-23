using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int _CurrentHealth { get; private set; }
    [field: SerializeField] public int _MaxHealth { get; private set; }
    public void InitializeHealth(int health)
    {
        _MaxHealth = health;
        _CurrentHealth = _MaxHealth;
    }
    public void Heal(int healAmount)
    {
        _CurrentHealth += healAmount;
    }
    public void Damage(int damageAmount)
    {
        _CurrentHealth -= damageAmount;
    }
}
