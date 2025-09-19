using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CharacterColorTag
{
    Red,
    Blue,
    Green
}

public interface CharacterColor
{
    public delegate void AttackAction();
    public void OnAttack(AttackAction attackAction);
    public void OnBeAttacked(AttackAction beAttackedAction);
}
