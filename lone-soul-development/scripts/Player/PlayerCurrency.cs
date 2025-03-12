using UnityEngine;
using TMPro;

public class PlayerCurrency : MonoBehaviour
{
    public bool paymentSuccess = true;
    public int defaultCurrency = 100;
    public int Currency { get; private set; }

    [SerializeField] private TMP_Text currencyDisplayText;

    void Start()
    {
        Currency = defaultCurrency;
    }

    private void Update()
    {
        currencyDisplayText.text = $"{Currency}";
    }

    public void AddCurrencyValue(int value)
    {
        Currency += value;
    }

    public void ReduceCurrencyValue(int value)
    {
        if (Currency - value >= 0) { 
            Currency -= value;
            paymentSuccess = true;
        }
        else
        {
            paymentSuccess = false;
        }
    }
}
