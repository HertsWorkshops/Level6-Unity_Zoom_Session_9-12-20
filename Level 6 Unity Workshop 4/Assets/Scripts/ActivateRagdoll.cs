using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
    public class ActivateRagdoll : MonoBehaviour
    {
        Collider[] RagdollColliders;
        public Collider MainCollider;
        Rigidbody rb;
        Rigidbody[] rigidbodies;
        Animator animator;
        ThirdPersonCharacter m_Character;
        ThirdPersonUserControl m_UserControl;

            private void Start()
            {
                RagdollColliders = GetComponentsInChildren<Collider>();
                MainCollider = GetComponent<CapsuleCollider>();
                rb = GetComponent<Rigidbody>();
                animator = GetComponent<Animator>();
                rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rbs in rigidbodies)
            {
                rbs.useGravity = false;
            }
                MainCollider.enabled = true;
                rb.useGravity = true;
                m_Character = GetComponent<ThirdPersonCharacter>();
                m_UserControl = GetComponent<ThirdPersonUserControl>();        
            }

            public void ragdoolEnabled(bool isRagdoll)
            {
            
                animator.enabled = !isRagdoll;
                m_Character.enabled = !isRagdoll;
                m_UserControl.enabled = !isRagdoll;

            foreach (var collider in RagdollColliders)
            {
                collider.enabled = isRagdoll;

            }
                MainCollider.isTrigger = isRagdoll;
       
            foreach (var rbs in rigidbodies)
            {
                rbs.useGravity = isRagdoll;
            }
                rb.useGravity = !isRagdoll;
                rb.drag = 100f;
            }

    }

