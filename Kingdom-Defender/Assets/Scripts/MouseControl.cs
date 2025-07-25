using Unity.VisualScripting;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public static GameObject ally;
    private GameObject temp;
    private GameObject currentPlot;

    [SerializeField] private LayerMask interact;
    private Vector2 mousePos;

    void Update()
    {
        if (ally == null) return;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, interact);

        int cost = ally.GetComponent<Ally>().cost;

        if (hit.collider != null && hit.collider.gameObject.GetComponent<Plot>().isOccupied == false && GoldManager.Instance.HasEnoughGold(cost))
        {
            if (hit.collider.CompareTag("Plot") && temp == null)
            {
                currentPlot = hit.collider.gameObject;
                temp = Instantiate(ally, hit.collider.transform.position, Quaternion.identity);
                Color color = temp.GetComponent<SpriteRenderer>().color;
                color.a = 0.5f;
                temp.GetComponent<SpriteRenderer>().color = color;
            }
            else if (Input.GetMouseButtonDown(0) && temp != null && hit.collider.gameObject == currentPlot)
            {
                GoldManager.Instance.SpendGold(cost);
                Destroy(temp);
                temp = Instantiate(ally, hit.collider.transform.position, Quaternion.identity);
                Color color = temp.GetComponent<SpriteRenderer>().color;
                color.a = 1f;
                temp.GetComponent<SpriteRenderer>().color = color;
                temp.GetComponent<Ally>().isPlaced = true;
                hit.collider.gameObject.GetComponent<Plot>().isOccupied = true;
                temp = null;
                ally = null;
            }
            else if (hit.collider.gameObject != currentPlot)
            {
                Destroy(temp);
            }
        }
        else
        {
            Destroy(temp);
        }
    }
}