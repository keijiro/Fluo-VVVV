using UnityEngine;
using Unity.Mathematics;
using Klak.Math;

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
    [SerializeField] int _themeIndex = 0;
    [SerializeField] float _transitionSpeed = 4;

    (float3 bgfx, float3 ramp1, float3 ramp2) _current;

    float3 C2V3(Color c) => math.float3(c.r, c.g, c.b);
    Color V32C(float3 v) => new Color(v.x, v.y, v.z);

    public void SelectTheme(int index)
        => _themeIndex = index;

    void start()
    {
        _current.bgfx = C2V3(_themes[_themeIndex].BGFXColor);
        _current.ramp1 = C2V3(_themes[_themeIndex].RampColor1);
        _current.ramp2 = C2V3(_themes[_themeIndex].RampColor2);
    }

    void Update()
    {
        _current.bgfx = ExpTween.Step(_current.bgfx, C2V3(_themes[_themeIndex].BGFXColor), _transitionSpeed);
        _current.ramp1 = ExpTween.Step(_current.ramp1, C2V3(_themes[_themeIndex].RampColor1), _transitionSpeed);
        _current.ramp2 = ExpTween.Step(_current.ramp2, C2V3(_themes[_themeIndex].RampColor2), _transitionSpeed);

        Shader.SetGlobalColor(ShaderID.FluoBGFXColor, V32C(_current.bgfx));
        Shader.SetGlobalColor(ShaderID.FluoRampColor1, V32C(_current.ramp1));
        Shader.SetGlobalColor(ShaderID.FluoRampColor2, V32C(_current.ramp2));
    }
}

} // namespace Fluo
