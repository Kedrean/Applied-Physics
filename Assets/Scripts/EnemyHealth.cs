using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1;
    public Animator animator;
    public Rigidbody[] ragdollBodies;

    [Tooltip("Time before ragdoll activates")]
    public float ragdollDelay = 2.1f;

    bool dead;

    void Start()
    {
        SetRagdoll(false);
    }

    public void TakeDamage(int dmg)
    {
        if (dead) return;

        health -= dmg;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        dead = true;

        animator.SetTrigger("Die");

        StartCoroutine(DeathSequence());

        GameManager.Instance.EnemyKilled();
    }

    IEnumerator DeathSequence()
    {
        // Apply gravity immediately to prevent floating
        foreach (var rb in ragdollBodies)
            rb.useGravity = true;

        yield return new WaitForSeconds(ragdollDelay);

        EnableRagdoll();
    }

    void EnableRagdoll()
    {
        animator.enabled = false;

        foreach (var rb in ragdollBodies)
            rb.isKinematic = false;
    }

    void SetRagdoll(bool active)
    {
        foreach (var rb in ragdollBodies)
        {
            rb.isKinematic = !active;
            rb.useGravity = active;
        }
    }
}