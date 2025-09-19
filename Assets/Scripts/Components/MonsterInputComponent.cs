using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.Events;

public class MonsterInputComponent : MonoBehaviour
{

    public UnityAction OnBow;
    public UnityAction OnRoar;
    public UnityAction OnSpitting;

    IAtk _iAtk;

    private void Start()
    {
        _iAtk = GetComponent<IAtk>();

        OnBow += _iAtk.Bow;
        OnRoar += _iAtk.Roar;
        OnSpitting += _iAtk.Spitting;
    }

    
    private void Update()
    {
        
    }
}
