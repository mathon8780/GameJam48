using Assets.Scripts.DataConfig;
using Interfaces;
using Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    /// <summary>
    /// 角色移动脚本
    /// </summary>
    public class CharacterMoveComponent : MonoBehaviour
    {
        Rigidbody2D rb;
        CapsuleCollider2D capsuleCollider2D;
        IAttribute _iAttributes;

        Vector2 moveInput = Vector2.zero;

        public ContactFilter2D contactFilter;
        RaycastHit2D[] groundResults = new RaycastHit2D[5];


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            _iAttributes = GetComponent<AttributesComponent>();
            capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }

        public void OnMove(Vector2 move)
        {
            moveInput = move;
            transform.localScale = new Vector3(moveInput.x == 0 ? transform.localScale.x : moveInput.x, transform.localScale.y, transform.localScale.z);
            _iAttributes.SetRunTimeAttributeValue(ERunTimeAttributeType.IsMoving, moveInput != Vector2.zero);
        }

        public void OnJump()
        {
            if (_iAttributes.GetRunTimeAttributeValue(ERunTimeAttributeType.IsGround))
            {
                rb.velocity = new Vector2(rb.velocity.x, _iAttributes.GetAttributesValue(EAttributeType.JumpHeight));
            }
        }

        void Update()
        {
            rb.velocity = new Vector2(moveInput.x * _iAttributes.GetAttributesValue(EAttributeType.MoveSpeed), rb.velocity.y);
            if (!_iAttributes.GetRunTimeAttributeValue(ERunTimeAttributeType.IsGround))
            {
                rb.velocity += new Vector2(0, -9.8f * Time.deltaTime * 1.1f);
            }
        }

        private void FixedUpdate()
        {
            int hitCount = capsuleCollider2D.Cast(Vector2.down, contactFilter, groundResults, 0.05f);
            bool isGround = hitCount > 0;
            _iAttributes.SetRunTimeAttributeValue(ERunTimeAttributeType.IsGround, isGround);
        }
    }
}