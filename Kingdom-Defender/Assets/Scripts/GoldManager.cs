using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance;
    public float gold;
    public TextMeshProUGUI goldText;
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateGoldUI();
    }

    public void AddGold(float amount)
    {
        gold += amount;
        UpdateGoldUI();
    }

    public void SpendGold(float amount)
    {
        gold -= amount;
        UpdateGoldUI();
    }
    public bool HasEnoughGold(float amount)
    {
        return gold >= amount;
    }

    void UpdateGoldUI()
    {
        if (goldText != null)
            goldText.text = gold.ToString("0");
    }
}
