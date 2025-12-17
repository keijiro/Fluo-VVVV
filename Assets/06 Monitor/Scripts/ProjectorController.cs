using UnityEngine;
using UnityEngine.UIElements;

namespace Fluo {

public sealed class ProjectorController : MonoBehaviour
{
    public void SetFadeout(float value)
      => _projector.style.unityBackgroundImageTintColor
           = new StyleColor(Grayscale(1 - value));

    static Color Grayscale(float v) => new Color(v, v, v);

    VisualElement _projector;

    void Start()
    {
        var displays = Display.displays;
        if (displays.Length > 1) displays[1].Activate();
        _projector = GetComponent<UIDocument>().rootVisualElement.Q("root");
    }
}

} // namespace Fluo
