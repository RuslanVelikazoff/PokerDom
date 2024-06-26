using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryPanel : MonoBehaviour
{
    [SerializeField] 
    private Button searchButton;
    [SerializeField] 
    private TMP_InputField searchInputField;

    [Space(13)]
    
    [SerializeField] 
    private GameObject[] termGameObject;
    [SerializeField] 
    private TextMeshProUGUI[] termText;

    [SerializeField] private Transform spawnPosition;

    private string searchString;
    private int matchedIndex;

    private void OnEnable()
    {
        searchString = string.Empty;
        searchInputField.text = string.Empty;
        Search(searchString);
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (searchButton != null)
        {
            searchButton.onClick.RemoveAllListeners();
            searchButton.onClick.AddListener(() =>
            {
                searchString = searchInputField.text;
                Search(searchString);
            });
        }
    }

    private void Search(string search)
    {
        if (search != string.Empty)
        {
            for (int i = 0; i < termText.Length; i++)
            {
                bool isMatched = termText[i].text.Contains(search);

                if (isMatched)
                {
                    matchedIndex = i;
                    
                    for (int j = 0; j < termGameObject.Length; j++)
                    {
                        if (matchedIndex != j)
                        {
                            termGameObject[j].SetActive(false);
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < termGameObject.Length; i++)
            {
                termGameObject[i].SetActive(true);
            }
        }
    }
}
