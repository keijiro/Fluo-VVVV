using Klak.TestTools;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Properties;
using Cursor = UnityEngine.Cursor;

namespace Fluo {

public sealed class SourceSelector : MonoBehaviour
{
    #region Scene object references

    [SerializeField] ImageSource _imageSource = null;

    #endregion

    #region Data source accessor for UI Toolkit

    [CreateProperty] public List<string> SourceList => GetCachedSourceList();

    #endregion

    #region Predefined settings

    const string PrefKey = "VideoSourceName";
    const float CacheInterval = 1;

    #endregion

    #region Source list cache

    (List<string> list, float time) _sourceList
      = (new List<string>(), -1000);

    bool ShouldUpdateSourceList
      => Time.time - _sourceList.time > CacheInterval;

    List<string> GetCachedSourceList()
    {
        if (ShouldUpdateSourceList)
        {
            var uvc = WebCamTexture.devices.Select(dev => dev.name);
            _sourceList.list = uvc.ToList();
            _sourceList.time = Time.time;
        }
        return _sourceList.list;
    }

    #endregion

    #region UI properties/methods

    VisualElement UIRoot
      => GetComponent<UIDocument>().rootVisualElement;

    DropdownField UISelector
      => UIRoot.Q<DropdownField>("source-selector");

    void SelectSource(string name)
    {
        _imageSource.SourceName = name;
        PlayerPrefs.SetString(PrefKey, name);
    }

    #endregion

    #region MonoBehaviour implementation

    void Start()
    {
        // This component as a UI data source
        UISelector.dataSource = this;

        // Dropdown selection callback
        UISelector.RegisterValueChangedCallback(evt => SelectSource(evt.newValue));

        // Initial source selection
        if (PlayerPrefs.HasKey(PrefKey))
            SelectSource(UISelector.value = PlayerPrefs.GetString(PrefKey));
    }

    #endregion
}

} // namespace Fluo
