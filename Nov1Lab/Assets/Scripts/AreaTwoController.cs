using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTwoController : XRSceneController
{
    public override void Init()
    {
        PlayerManager.Instance.hasVisited2 = true;
    }
}
