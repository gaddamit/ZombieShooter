using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("Custom")]
	[Tooltip("Flips gameobject direction to face target, only works to face left and right.")]
	public class FaceTarget : FsmStateAction
	{
		[RequiredField]
        [Tooltip("The game object to examine.")]
        public FsmOwnerDefault gameObject;
		[RequiredField]
		[Tooltip("Target GameObject.")]
        public FsmGameObject target;
		[Tooltip("Repeat every frame.")]
        public bool everyFrame;
		
		private Vector2 vector_2d;
		private Vector2 vector_2d_target;
		private Vector2 vector_2d_direction;
		private Vector3 vector_3d_scale;
		public override void Reset()
		{
			gameObject = null;
			target = null;
			everyFrame = true;
		}

        public override void Awake()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
		    if (go == null)
		    {
		        return;
		    }

			vector_3d_scale = go.transform.localScale;
        }

        // Code that runs on entering the state.
        public override void OnEnter()
		{
			DoFaceTarget();

		    if (!everyFrame)
		    {
		        Finish();
		    }
		}

		// Code that runs every frame.
		public override void OnUpdate()
		{
			DoFaceTarget();
		}

		private void DoFaceTarget()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
		    if (go == null || target.Value == null)
		    {
		        return;
		    }

			vector_2d = go.transform.position;
			vector_2d_target = target.Value.transform.position;
			vector_2d_direction = vector_2d_target - vector_2d;
			
			Vector3 scale = vector_3d_scale;
			scale.x = Mathf.Abs(scale.x);

			if(vector_2d_direction.x < 0)
			{
				scale.x *= -1;
			}

			go.transform.localScale = scale;
		}
	}
}
