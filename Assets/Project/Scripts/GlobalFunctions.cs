using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Lean.Touch;

public class GlobalFunctions : MonoBehaviour {

    public GameObject ScrollView, PanelButtons1, PanelButtons2, PanelControlls, PanelInfo;
    public Text ButtonTxt;
    bool Changer = false;

    public ColorPicker pickerInspector;
    public static ColorPicker picker;
    public Button ShowBtn;
    public Sprite Hide, Show;

    private void Start()
    {
        picker = pickerInspector;
    }

    public void On_Show_Controlls_BTN_Click()
    {
        ScrollView.SetActive(Changer);
        PanelButtons1.SetActive(Changer);
        PanelButtons2.SetActive(Changer);
        PanelControlls.SetActive(Changer);
        picker.gameObject.SetActive(false);
        ButtonTxt.text = (Changer)? "Hide\nButtons" : "Show\nButtons";
        ShowBtn.gameObject.GetComponent<Image>().sprite = (Changer) ? Hide : Show;
        Changer = !Changer;
    }

    public void ResetTransform()
    {
        if (GetClickedObject.LastClickedObject != null)
        {
            if (DefaultTrackableEventHandler.MyBool)
            {
                GetClickedObject.LastClickedObject.transform.position = GetClickedObject.LastClickedPosition;
                GetClickedObject.LastClickedObject.transform.rotation = GetClickedObject.LastClickedRotation;
                GetClickedObject.LastClickedObject.transform.localScale = GetClickedObject.LastClickedScale;
                GetClickedObject.LastClickedObject.GetComponent<Renderer>().material.color = GetClickedObject.LastClickedColor;
            }
        }
    }

    public static void Color_Picker_method()
    {
        picker.CurrentColor = GetClickedObject.LastClickedColor;
        picker.onValueChanged.RemoveAllListeners();
        picker.onValueChanged.AddListener(color =>
        {
            if (DefaultTrackableEventHandler.MyBool)
                GetClickedObject.LastClickedObject.GetComponent<Renderer>().material.color = color;
        });
    }

    public void ScreenShot()
    {
        StartCoroutine(Shotr());
    }

    IEnumerator Shotr()
    {
        On_Show_Controlls_BTN_Click();
        ShowBtn.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();
        ScreenCapture.CaptureScreenshot("/ScreenShot-" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg");
        yield return new  WaitForEndOfFrame();
        On_Show_Controlls_BTN_Click();
        ShowBtn.gameObject.SetActive(true);
        //PanelInfo.transform.GetChild(0).gameObject.GetComponent<Text>().text = Application.persistentDataPath;
        //PanelInfo.SetActive(true);
    }

    public void DeleteObject()
    {
        if (GetClickedObject.LastClickedObject != null)
        {
            if (DefaultTrackableEventHandler.MyBool)
            {
                Destroy(GetClickedObject.LastClickedObject);
                GetClickedObject.LastClickedObject = null;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

}
