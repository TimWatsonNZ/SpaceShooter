using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable {
    float CollisionDamage
    {
        get;
    }
    void TakeHit(float damage, string tag);   
}
