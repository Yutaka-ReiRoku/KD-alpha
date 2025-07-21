using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject allyPrefab;

    public void OnClickCard()
    {
        MouseControl.ally = allyPrefab;
        Debug.Log("Card Selected");
    }
}
