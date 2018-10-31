using UnityEngine;
using UnityEngine.EventSystems;

public class Transformation_Functions : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler {

    public Direction direction;
    public Action action;
    public float Move_Speed = 1f;
    bool pressing = false;
    public static bool Can_Detect = true;
    public AudioSource BTNAUDIO;
    Transform T;
    //Rigidbody R;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressing = true;
        Can_Detect = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressing = false;
        Can_Detect = true;
    }

    void Update()
    {
        if (pressing)
        {
            if (GetClickedObject.LastClickedObject != null)
            {
                if (DefaultTrackableEventHandler.MyBool)
                {
                    T = GetClickedObject.LastClickedObject.transform;
                    //R = GetClickedObject.LastClickedObject.GetComponent<Rigidbody>();
                    switch (action)
                    {
                        case Action.Translate:
                            switch (direction)
                            {
                                case Direction.Right:
                                    T.Translate(Vector3.right * Time.deltaTime * Move_Speed, Space.World);
                                    //T.Translate(Vector3.right * Time.deltaTime * Move_Speed, Space.Self);
                                    //R.AddForce(T.right * Time.deltaTime * Move_Speed);
                                    break;
                                case Direction.Left:
                                    T.Translate(Vector3.left * Time.deltaTime * Move_Speed, Space.World);
                                    //T.Translate(Vector3.left * Time.deltaTime * Move_Speed, Space.Self);
                                    //R.AddForce(-T.right * Time.deltaTime * Move_Speed);
                                    break;
                                case Direction.Up:
                                    T.Translate(Vector3.up * Time.deltaTime * Move_Speed, Space.World);
                                    //T.Translate(Vector3.forward * Time.deltaTime * Move_Speed, Space.Self);
                                    //R.AddForce(T.forward * Time.deltaTime * Move_Speed);
                                    break;
                                case Direction.Down:
                                    T.Translate(Vector3.down * Time.deltaTime * Move_Speed, Space.World);
                                    //T.Translate(Vector3.back * Time.deltaTime * Move_Speed, Space.Self);
                                    //R.AddForce(-T.forward * Time.deltaTime * Move_Speed);
                                    break;
                            }
                            break;
                        case Action.Rotate:
                            switch (direction)
                            {
                                case Direction.Right:
                                    T.Rotate(0f, 0f, Time.deltaTime * 90f, Space.World);
                                    break;
                                case Direction.Left:
                                    T.Rotate(0f, 0f, Time.deltaTime * -90f, Space.World);
                                    break;
                            }
                            break;
                        case Action.Scale_X:
                            switch (direction)
                            {
                                case Direction.Right:
                                    T.localScale += new Vector3(0.3F, 0, 0) * Time.deltaTime;
                                    break;
                                case Direction.Left:
                                    if (T.localScale.x > 0)
                                        T.localScale -= new Vector3(0.3F, 0, 0) * Time.deltaTime;
                                    break;
                            }
                            break;
                        case Action.Scale_Y:
                            switch (direction)
                            {
                                case Direction.Right:
                                    T.localScale += new Vector3(0, 0.3F, 0) * Time.deltaTime;
                                    break;
                                case Direction.Left:
                                    if (T.localScale.y > 0)
                                        T.localScale -= new Vector3(0, 0.3F, 0) * Time.deltaTime;
                                    break;
                            }
                            break;
                        case Action.Scale_Z:
                            switch (direction)
                            {
                                case Direction.Right:
                                    T.localScale += new Vector3(0, 0, 0.3F) * Time.deltaTime;
                                    break;
                                case Direction.Left:
                                    if (T.localScale.z > 0)
                                        T.localScale -= new Vector3(0, 0, 0.3F) * Time.deltaTime;
                                    break;
                            }
                            break;
                        case Action.Scale_all:
                            switch (direction)
                            {
                                case Direction.Right:
                                    T.localScale += new Vector3(0.3F, 0.3F, 0.3F) * Time.deltaTime;
                                    break;
                                case Direction.Left:
                                    if (T.localScale.z > 0)
                                        T.localScale -= new Vector3(0.3F, 0.3F, 0.3F) * Time.deltaTime;
                                    break;
                            }
                            break;
                    }
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BTNAUDIO.Play();
    }
}
