using System.Collections;
using UnityEngine;
using Firebase.Database;

public class NewsScrollView : MonoBehaviour
{
    [SerializeField]
    private GameObject newsPrefab;
    [SerializeField]
    private Canvas canvas;

    [SerializeField] private int newsAmount = 1;

    private DatabaseReference databaseReference;

    private void Awake()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        for (int i = 0; i < newsAmount; i++)
        {
            StartCoroutine(Load(i));
        }
    }

    private IEnumerator Load(int index)
    {
        var news = databaseReference.Child("News").Child(index.ToString()).GetValueAsync();

        yield return new WaitUntil(predicate: () => news.IsCompleted);

        if (news.Exception != null)
        {
            Debug.LogError(news.Exception);
        }
        else if (news.Result == null)
        {
            Debug.Log("Null");
        }
        else
        {
            DataSnapshot snapshot = news.Result;
            SpawnNewsInScrollView(snapshot.Child("Title").Value.ToString(), snapshot.Child("Body").Value.ToString());
        }
    }

    public void SpawnNewsInScrollView(string titleText, string bodyText)
    {
        var news = Instantiate(newsPrefab, transform.position, Quaternion.identity);
        news.transform.SetParent(canvas.transform);
        news.transform.localScale = new Vector3(1, 1, 1);
        news.transform.SetParent(this.gameObject.transform);
        news.GetComponent<NewsPrefab>().SpawnPrefab(titleText, bodyText);
    }
}
