using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
