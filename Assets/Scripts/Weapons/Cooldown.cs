using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown {

    float coolDown;
    float coolDownCounter = 0;

    public Cooldown(float coolDown)
    {
        this.coolDown = coolDown;
    }

    public bool Ready  
    {
        get
        {
            return coolDownCounter <= 0;
        }
    }

    public void Update(float deltaTime, bool shoots)
    {
        if (shoots)
        {
            coolDownCounter = coolDown;
        } else
        {
            coolDownCounter -= deltaTime;
        }
    }
}
