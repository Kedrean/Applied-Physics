using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1;
    public Animator animator;
    public Rigidbody[] ragdollBodies;
    public Collider[] ragdollColliders;

    bool dead = false;

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

        animator.SetBool("dead", true);

        // Small delay so death animation blends before physics takes over
        Invoke(nameof(EnableRagdoll), 0.3f);

        GameManager.Instance.EnemyKilled();
    }

    void EnableRagdoll()
    {
        // Instead of disabling animator, just stop root motion
        animator.applyRootMotion = false;

        SetRagdoll(true);
    }

    void SetRagdoll(bool active)
    {
        foreach (var rb in ragdollBodies)
        {
            rb.isKinematic = !active;
        }

        foreach (var col in ragdollColliders)
        {
            col.enabled = active;
        }
    }
}