using UnityEngine;
using UnityEngine.UI;

// The interface for classes that need to update the UIManager's properties
public interface IUIManagerObserver
{
    void OnUpdateUIManager(UIManager uiManager);
}