using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CharStatSheet",menuName ="Characters/Create Stat Sheet")]
public class CharacterStatsSO : ScriptableObject
{
    [field: SerializeField] public int _Health { get; private set; }
    [field: SerializeField] public int _Attack { get; private set; }
    [field: SerializeField] public Vector2 _MoveForce { get; private set; }
}
