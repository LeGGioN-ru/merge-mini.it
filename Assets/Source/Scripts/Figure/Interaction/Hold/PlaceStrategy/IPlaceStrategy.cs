using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaceStrategy 
{
    public void Place(IHoldable holdable);
}
