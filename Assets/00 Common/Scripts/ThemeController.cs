using UnityEngine;

namespace Fluo {

public sealed class ThemeController : MonoBehaviour
{
    [field:SerializeField, Range(0, 1)] public float BGFXHue { get; set; }
    [field:SerializeField, Range(0, 1)] public float BGFXSaturation { get; set; }

    void Update()
    {
        var bgfx = Color.HSVToRGB(BGFXHue, BGFXSaturation, 1);
        Shader.SetGlobalColor(ShaderID.FluoBGFXColor, bgfx);
    }
}

} // namespace Fluo
