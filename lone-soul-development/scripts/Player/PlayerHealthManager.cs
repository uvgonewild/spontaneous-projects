using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    private Health playerHealth;

    void Start()
    {
        playerHealth = GetComponent<Health>();
        healthBar.maxValue = playerHealth.maxHealth;
    }

    void Update()
    {
        healthBar.value = playerHealth.CurrentHealth;
    }
}
