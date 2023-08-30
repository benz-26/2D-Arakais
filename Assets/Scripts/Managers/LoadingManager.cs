using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private GameObject loadingPanel;

    private void Start()
    {
        ShowLoadingPanel();
        Invoke("HideLoadingPanel", 2f);
    }

    private void ShowLoadingPanel()
    {
        loadingPanel.SetActive(true);
    }

    private void HideLoadingPanel()
    {
        loadingPanel.SetActive(false);
    }
}
