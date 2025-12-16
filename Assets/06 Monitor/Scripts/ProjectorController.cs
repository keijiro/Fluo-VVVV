using UnityEngine;
using UnityEngine.UIElements;
using VJUITK;

namespace Fluo {

public sealed class ProjectorController : MonoBehaviour
{
    [SerializeField] UIDocument _monitor = null;

    VisualElement _projector;
    VJKnob _knob;

    void Start()
    {
        var displays = Display.displays;
        if (displays.Length > 1) displays[1].Activate();

        _projector = GetComponent<UIDocument>().rootVisualElement.Q("root");
        _knob = _monitor.rootVisualElement.Q<VJKnob>("knob-fadeout");
    }

    void Update()
      => _projector.style.unityBackgroundImageTintColor
           = new StyleColor(Grayscale(1 - _knob.value));

    static Color Grayscale(float v) => new Color(v, v, v);
}

} // namespace Fluo
