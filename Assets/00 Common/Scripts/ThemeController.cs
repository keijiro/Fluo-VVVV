using UnityEngine;

namespace Fluo {

[System.Serializable]
struct ThemeSettings
{
#pragma warning disable 0649
    [ColorUsage(false)] public Color BGFXColor;
    [ColorUsage(false)] public Color RampColor1;
    [ColorUsage(false)] public Color RampColor2;
#pragma warning restore 0649
}

public sealed class ThemeController : MonoBehaviour
{
    [SerializeField] ThemeSettings[] _themes = null;

    void Start()
      => SelectTheme(0);

    public void SelectTheme(int index)
    {
        var t = _themes[index];
        if (t.BGFXColor != default) Shader.SetGlobalColor(ShaderID.FluoBGFXColor,  t.BGFXColor);
        if (t.RampColor1 != default) Shader.SetGlobalColor(ShaderID.FluoRampColor1, t.RampColor1);
        if (t.RampColor2 != default) Shader.SetGlobalColor(ShaderID.FluoRampColor2, t.RampColor2);
    }

#if UNITY_EDITOR
    [field:SerializeField] public int PreviewIndex { get; set; } = -1;

    void OnValidate()
    {
        if (PreviewIndex >= 0) SelectTheme(PreviewIndex);
    }
#endif
}

} // namespace Fluo
