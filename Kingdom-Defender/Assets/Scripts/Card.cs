using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject allyPrefab;
    private int cost;

    void Start()
    {
        if (allyPrefab != null)
        {
            Ally ally = allyPrefab.GetComponent<Ally>();
            if (ally != null)
            {
                cost = ally.cost;
            }
        }
    }

    public void OnClickCard()
    {
        if (GoldManager.Instance.HasEnoughGold(cost) == false)
        {
            Debug.Log("Not Enough Gold");
        }
        MouseControl.ally = allyPrefab;
        Debug.Log("Card Selected");
    }
}
