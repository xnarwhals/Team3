using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdentityChangeUI : MonoBehaviour
{
    public Slider identityBarSlider;

    public void Start()
    {
        identityBarSlider = GetComponent<Slider>();

    }

    public void SetMaxIndentity(int maxIdentity)
    {
        identityBarSlider.maxValue = maxIdentity;
        identityBarSlider.value = maxIdentity;
    }

    public void SetIdentity(int Identity)
    {
        identityBarSlider.value = Identity;
    }
}
