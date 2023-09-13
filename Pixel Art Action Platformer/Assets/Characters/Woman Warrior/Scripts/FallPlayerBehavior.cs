using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlayerBehavior : BaseBehavior
{
    public override void Exit() => this.enabled = false;
}
