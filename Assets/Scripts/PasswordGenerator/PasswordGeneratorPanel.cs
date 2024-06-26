using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PasswordGeneratorPanel : MonoBehaviour
{
    [SerializeField]
    private Slider passwordLenghtSlider;
    [SerializeField] 
    private TextMeshProUGUI passwordLenghtText;
    [SerializeField] 
    private TMP_InputField passwordInputField;

    [Space(13)]
    
    [SerializeField] 
    private Button generateButton;
    [SerializeField] 
    private Button copyButton;

    private string password;
    string[] symbols = { "1","2","3","4","5","6","7","8","9","B","C","D","F","G","H","J","K","L","M","N","P","Q","R","S","T","V","W","X","Z","b","c","d","f","g","h","j","k","m","n","p","q","r","s","t","v","w","x","z","A","E","U","Y","a","e","i","o","u","y" };

    private void OnEnable()
    {
        password = string.Empty;
        passwordLenghtSlider.value = 1;
        passwordInputField.text = string.Empty;
        ButtonClickAction();
    }

    private void Update()
    {
        passwordLenghtText.text = passwordLenghtSlider.value.ToString();
    }

    private void GeneratePassword(int lenght)
    {
        for (int i = 0; i < lenght; i++)
        {
            password = password + symbols[Random.Range(0, symbols.Length - 1)];
        }
    }

    private void ButtonClickAction()
    {
        if (generateButton != null)
        {
            generateButton.onClick.RemoveAllListeners();
            generateButton.onClick.AddListener(() =>
            {
                password = string.Empty;
                GeneratePassword((int)passwordLenghtSlider.value);
                passwordInputField.text = password;
            });
        }

        if (copyButton != null)
        {
            copyButton.onClick.RemoveAllListeners();
            copyButton.onClick.AddListener(() =>
            {
                GUIUtility.systemCopyBuffer = password;
            });
        }
    }
}
