using Assets.Game.Scripts.SO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Scripts.Interfaces
{
	public interface ISpawnedUnit
	{
		event EventHandler OnUnitDied;
		void Init(SpawnUnitConfig unitConfig);
	}
}
