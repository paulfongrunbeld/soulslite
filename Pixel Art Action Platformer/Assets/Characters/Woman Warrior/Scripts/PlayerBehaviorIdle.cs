using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorIdle : BaseBehavior
{
	public override void Exit() => this.enabled = false;

}
