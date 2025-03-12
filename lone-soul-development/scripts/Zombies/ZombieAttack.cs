using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float minDamage = 10f;
    public float maxDamage = 20f;
    public AudioSource deathAudioSource;

    private Transform attackTarget;

    void Attack(Transform target)
    {
        Health targetHealth = target.GetComponent<Health>();
        float damage = Random.Range(minDamage, maxDamage);

        targetHealth.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Zombie"))
        {
            attackTarget = collision.gameObject.transform;
            Attack(attackTarget);
        }
    }
}
