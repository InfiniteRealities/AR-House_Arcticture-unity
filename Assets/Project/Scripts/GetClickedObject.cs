using UnityEngine;
using UnityEngine.EventSystems;
using Lean.Touch;

public class GetClickedObject : MonoBehaviour {

    public static GameObject LastClickedObject;
    public static Vector3 LastClickedPosition;
    public static Vector3 LastClickedScale;
    public static Quaternion LastClickedRotation;
    public static Color LastClickedColor;
    public static LeanTranslate Previous_Object;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //if not over ui
                //if (!(EventSystem.current.IsPointerOverGameObject() ))
                //if (!(EventSystem.current.IsPointerOverGameObject() || EventSystem.current.currentSelectedGameObject != null))
                if(Transformation_Functions.Can_Detect)
                {
                    if (hit.transform.gameObject.tag != "House")
                    {
                        LastClickedObject = hit.transform.gameObject;
                        LastClickedPosition = hit.transform.position;
                        LastClickedScale = hit.transform.localScale;
                        LastClickedRotation = hit.transform.rotation;
                        //LastClickedColor = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                        //GlobalFunctions.Color_Picker_method();

                        if (Previous_Object != null)
                            Destroy(Previous_Object);
                        LeanTranslate LS = LastClickedObject.AddComponent<LeanTranslate>();
                        LS.IgnoreStartedOverGui = false;
                        Previous_Object = LS;
                    }
                }
            }
        }
    }
}
