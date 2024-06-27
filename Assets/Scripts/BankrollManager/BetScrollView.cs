using System;
using System.Collections.Generic;
using UnityEngine;

public class BetScrollView : MonoBehaviour
{
    [SerializeField] 
    private GameObject betPrefab;

    [SerializeField]
    private Canvas canvas;

    private List<GameObject> bets = new List<GameObject>();
    private List<int> betsIndex;

    public void SpawnPrefabsInScrollView()
    {
        betsIndex = BetData.Instance.GetBetIndexList();
        Debug.Log(betsIndex.Count);

        for (int i = 0; i < betsIndex.Count; i++)
        {
            var bet = Instantiate(betPrefab, transform.position, Quaternion.identity);
            bet.transform.SetParent(canvas.transform);
            bet.transform.localScale = new Vector3(1, 1, 1);
            bet.transform.SetParent(this.gameObject.transform);
            bet.GetComponent<BetPrefab>().SpawnPrefab(betsIndex[i]);
            bets.Add(bet);
        }
    }

    public void ResetAllBets()
    {
        if (bets != null)
        {
            for (int i = 0; i < bets.Count; i++)
            {
                Destroy(bets[i]);
                bets.RemoveAt(i);
                ResetAllBets();
            }
        }
    }
}
