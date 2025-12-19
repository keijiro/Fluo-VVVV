using UnityEngine;

namespace Fluo {

public sealed class ThemeController : MonoBehaviour
{
    [field:SerializeField, ColorUsage(false)] public Color BGFXColor { get; set; } = Color.white;
    [field:SerializeField, ColorUsage(false)] public Color RampColor1 { get; set; } = Color.red;
    [field:SerializeField, ColorUsage(false)] public Color RampColor2 { get; set; } = Color.blue;

    void Update()
    {
        Shader.SetGlobalColor(ShaderID.FluoBGFXColor, BGFXColor);
        Shader.SetGlobalColor(ShaderID.FluoRampColor1, RampColor1);
        Shader.SetGlobalColor(ShaderID.FluoRampColor2, RampColor2);
    }
}

} // namespace Fluo
