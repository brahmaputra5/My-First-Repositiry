using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class ButtonsScript : MonoBehaviour
{
    private GameObject _localLockGO;
    public GameObject UnityAdsPanel;
    public GameObject RatePanel;
    public GameObject[] Panels;

    void Awake()
    {
        RatePanel.SetActive(true);
    }
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

    public void RateAnswer(bool answer)
    {
        if(answer == true)
            RateGame();
        RatePanel.SetActive(false);
    }


    public void RateGame()
    {
        #if UNITY_ANDROID
		Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
        #elif UNITY_IOS
        Application.OpenURL("https://itunes.apple.com/app/id" + GetComponent(ADSComponent.Instance.AppleId) + "?action=write-review");
        #endif
    }
}
