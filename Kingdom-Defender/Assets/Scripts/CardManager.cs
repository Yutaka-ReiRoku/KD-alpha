using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject allyPrefab;
    public static GameObject selectedAllyPrefab;

    public void OnClickCard()
    {
        selectedAllyPrefab = allyPrefab;
    }

    public void SelectCard()
    {
        Debug.Log("Card Selected");
        CardManager.selectedAllyPrefab = allyPrefab;
    }
}
