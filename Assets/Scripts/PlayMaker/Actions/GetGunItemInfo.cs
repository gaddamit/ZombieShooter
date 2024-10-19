using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("Custom")]
	public class GetGunItemInfo : FsmStateAction
	{
		public FsmString gunName;
		public FsmString description;
		public FsmFloat fireRate;
		public FsmFloat range;
		public FsmInt maxAmmo;
		public FsmFloat recoil;
		public FsmBool isSpread;
		public FsmFloat bulletSpeed;
		public FsmFloat bulletLifeTime;
		[ObjectType(typeof(GameObject))]
		public FsmObject bulletPrefab;
		[ObjectType(typeof(Sprite))]
		public FsmObject levelSprite;
		[ObjectType(typeof(Sprite))]
		public FsmObject uiSprite;
		[ObjectType(typeof(GunSO))]
		public FsmObject ItemReference;
		// Code that runs on entering the state.
		public override void OnEnter()
		{
			gunName.Value = ((GunSO)ItemReference.Value).gunName;
			description.Value = ((GunSO)ItemReference.Value).description;
			fireRate.Value = ((GunSO)ItemReference.Value).fireRate;
			range.Value = ((GunSO)ItemReference.Value).range;
			maxAmmo.Value = ((GunSO)ItemReference.Value).maxAmmo;
			recoil.Value = ((GunSO)ItemReference.Value).recoil;
			isSpread.Value = ((GunSO)ItemReference.Value).spread;
			bulletSpeed.Value = ((GunSO)ItemReference.Value).bulletSpeed;
			bulletLifeTime.Value = ((GunSO)ItemReference.Value).bulletLifeTime;
			bulletPrefab.Value = ((GunSO)ItemReference.Value).bulletPrefab;
			levelSprite.Value = ((GunSO)ItemReference.Value).levelSprite;
			uiSprite.Value = ((GunSO)ItemReference.Value).uiSprite;
			Finish();
		}


	}

}
