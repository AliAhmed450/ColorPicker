using System;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class saveColor : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Image colorShowcaseImage;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject[] toActivate;
    [SerializeField] private NonNativeKeyboard m_nonNativeKeyboard;
    public Color savedColor { get { return color; } }
    private Color color;
    public void Initialize(Color color)
    {
        inputField.text = string.Empty;
        this.color = color;
        colorShowcaseImage.color = color;
    }
    public void OnButtonPressed()
    {
        text.text = $"{inputField.text}  Saved ";
        string a = ColorUtility.ToHtmlStringRGB(color);
        text.text += a;
        foreach (GameObject go in toActivate)
        {
            go.SetActive(false);
        }
    }
    public void activateObjects()
    {
        foreach (GameObject obj in toActivate)
        {
            obj.SetActive(true);
        }
        inputField.text = string.Empty;
        m_nonNativeKeyboard.PresentKeyboard();
    }
}
