using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    float percentage;
    public Image fill;

    public float width;

    void Start()
    {
        width = fill.preferredWidth;
    }

	public void SetPercentage(float percentage)
    {
        this.percentage = percentage;
        Vector2 scale = fill.transform.localScale;
        scale.x = this.percentage;
        fill.transform.localScale = scale;
    }
}
