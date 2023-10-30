using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CastleHealth>().OnCastleDown += SetTimeZero;
    }

    void SetTimeZero()
    {
        Time.timeScale = 0;
    }

}
