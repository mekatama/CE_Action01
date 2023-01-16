using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;

namespace MoreMountains.CorgiEngine
{
	[AddComponentMenu("")]
	//■判別しやすいようにpath変更している
	[FeedbackPath("FloatingText_Score")]

	[FeedbackHelp("This feedback lets you trigger the appearance of a floating text, that will reflect the damage done to the target Health component." +
	              "This requires that a MMFloatingTextSpawner be correctly setup in the scene, otherwise nothing will happen." +
	              "To do so, create a new empty object, add a MMFloatingTextSpawner to it. Drag (at least) one MMFloatingText prefab into its PooledSimpleMMFloatingText slot." +
	              "You'll find such prefabs already made in the MMTools/Tools/MMFloatingText/Prefabs folder, but feel free to create your own.")]
	public class MMFeedbackCorgiEngineFloatingText_Score : MMFeedbackFloatingText
	{
		[Header("Corgi Engine Settings")]

		/// the Health component where damage data should be read
		[Tooltip("the Health component where damage data should be read")]

		//■新規で作ったHealthを参照
		public Health_Enemy TargetHealth;

		/// the number formatting of your choice, 
		/// check https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings?redirectedfrom=MSDN#NFormatString for examples
		[Tooltip("the number formatting of your choice, feel free to leave it blank")]
		public string Formatting = "";

		[Header("Direction")]
		/// whether or not the direction of the damage should impact the direction of the floating text 
		[Tooltip("whether or not the direction of the damage should impact the direction of the floating text")]
		public bool DamageDirectionImpactsTextDirection = true;
		/// the multiplier to apply to the damage direction. Usually you'll want it to be less than 1. With a value of 0.5, a character being hit from the left will spawn a floating text at a 45° up/right angle
		[Tooltip("the multiplier to apply to the damage direction. Usually you'll want it to be less than 1. With a value of 0.5, a character being hit from the left will spawn a floating text at a 45° up/right angle")]
		public float DamageDirectionMultiplier = 0.5f;

		//■新規変数
		private string hitobj;
		private int newPoint;

		/// <summary>
		/// On play, we ask for a floating text to be spawned
		/// </summary>
		/// <param name="position"></param>
		/// <param name="attenuation"></param>
		protected override void CustomPlayFeedback(Vector3 position, float attenuation = 1.0f)
		{
			//■ダメージ与えたobjectを入れる
			hitobj = TargetHealth.hitObjectName;
			//■enemyのHPがゼロになった場合
			if (TargetHealth.CurrentHealth <= 0)
			{
				if (TargetHealth == null)
				{
					return;
				}

				if (DamageDirectionImpactsTextDirection)
				{
					Direction = TargetHealth.LastDamageDirection.normalized * DamageDirectionMultiplier;
				}

				//■トドメ攻撃の判定
				if(hitobj == "PlayerWeapon2(Clone)DamageArea (UnityEngine.GameObject)"){
					newPoint = TargetHealth.meleeScore;
				}else{
					newPoint = TargetHealth.shotScore;
				}

				//enemyのscoreを指定
				Value = newPoint.ToString(Formatting);

				_playPosition = (PositionMode == PositionModes.FeedbackPosition) ? this.transform.position : TargetTransform.position;
				MMFloatingTextSpawnEvent.Trigger(Channel, _playPosition, Value, Direction, Intensity, ForceLifetime, Lifetime, ForceColor, AnimateColorGradient);
			}
		}
	}
}