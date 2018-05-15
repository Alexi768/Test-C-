using UnityEngine;
using System.Collections;

public class Enigma_Base : MonoBehaviour
{

    public bool isEnabled;
    public bool isResolved;
    public bool isVisible;

    public virtual void setVisible(bool isVisible)
    {
    }
}
