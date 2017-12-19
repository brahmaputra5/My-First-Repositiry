using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class ButtonsScript : MonoBehaviour
{
    private GameObject _localLockGO;
    public GameObject UnityAdsPanel;
    public GameObject[] Panels;
    void Start()
    {
        ChoosePanel(0);
        UnityAdsPanel.SetActive(false);
        EventScript.OnClicked += HandleButtonPadlockPressed;
        UnityAdsPanel.SetActive(false);
        DOTween.Init(false, true, LogBehaviour.Default);
        Camera.main.transform.position = new Vector3(0, 0, -10);
    }
    public GameObject cameraMain;

    public void ChoosePanel(int x)
    {
        foreach (GameObject obj in Panels)
        {
            if(obj== Panels[x])
                obj.SetActive(true);
            else
                obj.SetActive(false);
        }
    }


    public void SetOffThePanel()
    {
        UnityAdsPanel.SetActive(false);
    }

    public void HandleButtonPadlockPressed(GameObject go)
    {
        Debug.Log(go);
        PressOnLock();
        SaveLockName(gameObject);
        GetComponent<UnityADS>().GetTheLockName(go);
    }

    public void SaveLockName(GameObject go)
    {
        _localLockGO = go;
    }

    public void PressOnLock()
    {
        UnityAdsPanel.SetActive(true);
    }

    public void PressYes()
    {
        GetComponent<UnityADS>().ShowRewardedAd();
    }

    public void AppAds(string Adv)
    {
        Application.OpenURL(Adv);
    }

    public void moreGames(string Link)
    {
		Application.OpenURL(Link);
    }
}
