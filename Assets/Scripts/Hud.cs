using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    public Image healthbar;
    public Image shieldbar;

    Transform startingTransform;

    void Start()
    {
        startingTransform = healthbar.transform;
    }

    public void UpdateHud(float healthPercentage, float shieldPercentage)
    {
        healthbar.transform.localScale = new Vector3(1, healthPercentage, 1);
        shieldbar.transform.localScale = new Vector3(1, shieldPercentage, 1);
    }
}
