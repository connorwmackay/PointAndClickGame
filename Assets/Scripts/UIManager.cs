using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool isGameInputDisabled;

    // Start is called before the first frame update
    void Start()
    {
        isGameInputDisabled = false;
    }

    public void DisableGameInput()
    {
        isGameInputDisabled = true;
    }

    public void EnableGameInput()
    {
        isGameInputDisabled = false;
    }

    public bool GetIsGameInputDisabled()
    {
        return isGameInputDisabled;
    }
}
