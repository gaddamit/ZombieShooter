using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("Custom")]
	public class GetMousePosition2D : FsmStateAction
	{
        [RequiredField]
		[Tooltip("Store the position in this Vector3")]
		public FsmVector2 storeMousePosition;

		[Tooltip("Do this every frame?")]
		public bool everyFrame;

		[Tooltip("Get the position relative to the center of the screen? (note: doesn't work with Invert Y checked)")]
		public bool fromScreenCenter;

		[Tooltip("Invery Y. For use with GUI space.")]
		public bool invertY;

		[Tooltip("Normalize the Vector3 result?")]
		public bool normalized;

		
		public override void Reset()
		{
			storeMousePosition = new FsmVector2 { UseVariable = true };
			everyFrame = false;
			fromScreenCenter = false;
			normalized = false;
			invertY = false;
		}
		
		public override void OnEnter()
		{
			DoGetPosition();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoGetPosition();
		}

		void DoGetPosition()
		{
			var mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			if (invertY)
			{
				mousePos.y = Screen.height - mousePos.y;
			}

			if (fromScreenCenter)
			{
				mousePos.x -= Screen.width/2;
				mousePos.y -= Screen.height/2;
			}

			if (normalized)
			{
				mousePos.x /= Screen.width;
				mousePos.y /= Screen.height;
			}

			storeMousePosition.Value = mousePos;
		}
	}

}
