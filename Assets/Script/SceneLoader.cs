using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractable))]
public class SceneLoader : MonoBehaviour
{
    [Tooltip("Name of the scene to load when this card is selected")]
    [SerializeField] private string sceneToLoad;

    private XRBaseInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnCardSelected);
    }

    private void OnCardSelected(SelectEnterEventArgs args)
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.Log($"[{gameObject.name}] Loading scene: {sceneToLoad}");
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene to load is not assigned on " + gameObject.name);
        }
    }

    void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnCardSelected);
    }
}
