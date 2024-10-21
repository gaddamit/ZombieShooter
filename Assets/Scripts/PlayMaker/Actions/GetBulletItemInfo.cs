using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("Custom")]
	public class GetBulletItemInfo : FsmStateAction
	{
		public FsmString bulletName;
		
		public FsmFloat damage;
		public FsmFloat travelTime;
		public FsmFloat lifeTime;
		public FsmFloat size;

		[ObjectType(typeof(Sprite))]
		public FsmObject sprite;

		public FsmGameObject hitEffect;

		public FsmGameObject trailEffect;

		public FsmObject hitSound;
		public FsmObject shootSound;


		public FsmObject ItemReference;
		// Code that runs on entering the state.
		public override void OnEnter()
		{
			bulletName.Value = ((BulletSO)ItemReference.Value).bulletName;
			damage.Value = ((BulletSO)ItemReference.Value).damage;
			travelTime.Value = ((BulletSO)ItemReference.Value).travelTime;
			lifeTime.Value = ((BulletSO)ItemReference.Value).lifeTime;
			size.Value = ((BulletSO)ItemReference.Value).size;
			
			hitEffect.Value = ((BulletSO)ItemReference.Value).hitEffect;
			trailEffect.Value = ((BulletSO)ItemReference.Value).trailEffect;
			hitSound.Value = ((BulletSO)ItemReference.Value).hitSound;
			shootSound.Value = ((BulletSO)ItemReference.Value).shootSound;

			Finish();
		}


	}

}
