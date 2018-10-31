using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Touch;

public class PopulateContent : MonoBehaviour {

    public List<ClassParentItem> ItemsToDisplay;
    public GameObject ButtonPrefab;
    public Transform InstantiatePosition;
    public GameObject pnl;

    GameObject newObj;
    bool IsParent = true;

    void Start () {
        Populate_Grid();
    }

    void Populate_Grid()
    {
        IsParent = true;
        foreach (ClassParentItem item in ItemsToDisplay)
        {
            newObj = (GameObject)Instantiate(ButtonPrefab, transform);
            newObj.GetComponent<UnityEngine.UI.Image>().sprite = item.Image;
            newObj.GetComponent<Button>().onClick.AddListener(() => On_Parent_item_click(item));
        }
    }

    void On_Parent_item_click(ClassParentItem Parent)
    {
        IsParent = false;
        for (int i = transform.childCount - 1; i >= 0 ; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        foreach (ClassChildItem item in Parent.Children)
        {
            newObj = (GameObject)Instantiate(ButtonPrefab, transform);
            newObj.GetComponent<UnityEngine.UI.Image>().sprite = item.Image;
            newObj.GetComponent<Button>().onClick.AddListener(() => On_Child_item_click(item));
        }
    }

    void On_Child_item_click(ClassChildItem Child)
    {
        if (DefaultTrackableEventHandler.MyBool)
        {
            GameObject Obj = Instantiate(Child.Model, InstantiatePosition);
            GetClickedObject.LastClickedObject = Obj;
            GetClickedObject.LastClickedPosition = Obj.transform.position;
            GetClickedObject.LastClickedScale = Obj.transform.localScale;
            GetClickedObject.LastClickedRotation = Obj.transform.rotation;
            //GetClickedObject.LastClickedColor = Obj.GetComponent<Renderer>().material.color;
            //GlobalFunctions.Color_Picker_method();

            if (GetClickedObject.Previous_Object != null)
                Destroy(GetClickedObject.Previous_Object);
            LeanTranslate LS = GetClickedObject.LastClickedObject.AddComponent<LeanTranslate>();
            LS.IgnoreStartedOverGui = false;
            GetClickedObject.Previous_Object = LS;
        }
    }

    public void Back_Btn_Click()
    {
        if (!IsParent)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            Populate_Grid();
        }
    }

    private void Update()
    {
        if (DefaultTrackableEventHandler.MyBool)
        {
            pnl.SetActive(true);
        }
        else
            pnl.SetActive(false);
    }

}
