using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TestAbstract : MonoBehaviour
{
    public virtual void Interact() { print("oi"); }
}

public class HerdaAbstract : TestAbstract
{
    public override void Interact()
    {
        base.Interact();
        
    }
}
