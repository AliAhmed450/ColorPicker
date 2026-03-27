using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class saveColor : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Image colorShowcaseImage;
    [SerializeField] private TextMeshProUGUI text;
    public void Initialize(Color color)
    {
        inputField.text = string.Empty;
        colorShowcaseImage.color = color;
    }
    public void OnButtonPressed()
    {
        text.text = $"{inputField.text} Saved";
        gameObject.SetActive(false);
    }

}
