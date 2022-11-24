using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    private void OnApplicationFocus(bool focus)
    {
        Cursor.visible = false;
    }
}
