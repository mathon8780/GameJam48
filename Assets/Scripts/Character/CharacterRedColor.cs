using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRedColor : MonoBehaviour, CharacterColor
{
    

    void Awake()
    {
    }
    public void OnAttack( CharacterColor.AttackAction attackAction)
    {
        Debug.Log("Red Attack");
    }
    
    public void OnBeAttacked(CharacterColor.AttackAction beAttackedAction)
    {
        Debug.Log("Red BeAttacked");
    }
}
