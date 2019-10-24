using Assets.Game.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Misc
{
	class TimedExecution : MonoBehaviour
	{
		
		[SerializeField] private List<GameObject> targetObjects;
		[SerializeField] private bool isLooped;

		private float secondsBetweenSpawn;
		private float callRateIncreaser;

		//Keeping both operatable via scripts and inspector;

		public bool IsLooped
		{
			get { return isLooped; }
			set { isLooped = value; }
		}
		public bool IsRunning { get; private set; }

		private List<IExecutable> targets = new List<IExecutable>();

		private void Awake()
		{
			targetObjects.ForEach(target => targets.Add(target.GetComponent<IExecutable>()));
		}

		public void StartTimer(float secondsBetweenSpawn, float callRateIncreaser)
		{
			this.secondsBetweenSpawn = secondsBetweenSpawn;
			this.callRateIncreaser = callRateIncreaser;
			IsRunning = true;
			StartCoroutine(RunTimerCoroutine(secondsBetweenSpawn));
		}

		public void AddTarget(IExecutable target)
		{
			if (!targets.Contains(target))
			{
				targets.Add(target);
			}
			else
			{
				Debug.LogError("Adding duplicates to timer executables collection is not allowed.");
			}
		}

		private IEnumerator RunTimerCoroutine(float secondsBetweenCalls)
		{
			while (IsRunning)
			{
				yield return new WaitForSeconds(secondsBetweenCalls);
				targets.ForEach(target => target.Execute());

				secondsBetweenCalls -= callRateIncreaser;
				
				if (!IsLooped)
				{
					IsRunning = false;
				}
			}
		}
	}
}
