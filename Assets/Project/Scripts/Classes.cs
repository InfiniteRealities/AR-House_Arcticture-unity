using System.Collections.Generic;
using UnityEngine;

public class Classes {}

[System.Serializable]
public class ClassParentItem
{
    public string Name;
    public Sprite Image;
    public List<ClassChildItem> Children;
}

[System.Serializable]
public class ClassChildItem
{
    //public string Name;
    public Sprite Image;
    public GameObject Model;
}

[System.Serializable]
public enum Direction
{
    Right = 0, Left = 1, Up = 2, Down = 3
}

[System.Serializable]
public enum Action
{
    Translate = 0, Rotate = 1, Scale_X = 2, Scale_Y = 3, Scale_Z = 4, Scale_all = 5
}
