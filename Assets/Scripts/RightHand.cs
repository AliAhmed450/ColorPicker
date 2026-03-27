using Meta.XR;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RightHand : MonoBehaviour
{
    [SerializeField] private Material m_material;
    [SerializeField] private Image m_image;
    [SerializeField] private PassthroughCameraAccess m_cameraAccess;
    [SerializeField] private saveColor Container;
    private void Start()
    {
    }
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            OnButtonPressed();
        }
    }
    private void OnButtonPressed()
    {
        var tex = GetTexture();
        var color = tex.GetPixel(tex.width / 2, tex.height / 2);
        if (m_material != null)
            m_material.color = color;
        if (m_image != null)
            m_image.color = color;

        Container.gameObject.SetActive(true);
        Container.Initialize(color);
    }
    public Texture2D GetTexture()
    {
        if (!m_cameraAccess.IsPlaying) return null;
        var mainTexture = m_cameraAccess.GetTexture();
        var texture2D = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);

        var currentRT = RenderTexture.active;

        var renderTexture = new RenderTexture(mainTexture.width, mainTexture.height, 32);
        Graphics.Blit(mainTexture, renderTexture);

        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        RenderTexture.active = currentRT;

        return texture2D;
    }
}
