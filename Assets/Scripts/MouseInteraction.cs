using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    public LayerMask deck;
    public Deck_Spawner deckSpawnerScript;


    //void Update()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {

    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        if (Physics.Raycast(ray, out hit, 100f))
    //        {
    //            GameObject clickedObj = hit.collider.gameObject;

    //            if (clickedObj == deckSpawnerScript.currentTopCard)
    //            {
    //                int lastInd = deckSpawnerScript.cardOrder.Count - 1;
    //                deckSpawnerScript.cardOrder.RemoveAt(lastInd);
    //                Destroy(deckSpawnerScript.currentTopCard);

    //                SetNewTopCard();

    //                Debug.DrawLine(ray.origin, hit.point, Color.green, 2f); print("hit");

    //            }
    //            else
    //            {
    //                print("missed");
    //            }

    //        }
    //    }
    //}

    //void SetNewTopCard()
    //{
    //    int lastInd = deckSpawnerScript.cardOrder.Count - 1;
        
    //    deckSpawnerScript.currentTopCard = deckSpawnerScript.cardOrder[lastInd];
    //}
}
