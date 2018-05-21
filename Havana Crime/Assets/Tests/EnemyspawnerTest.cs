using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor;

public class EnemyspawnerTest {

	[Test]
	public void EnemyspawnerTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator Instantiantes_GameObject_From_Prefab() {
		Transform enemyPrefab = Resources.Load ("Tests/enemy", typeof(Transform)) as Transform;
		var enemySpawner = new GameObject ().AddComponent<WaveSpawner> ();
		enemySpawner.enemy = enemyPrefab;
		enemySpawner.waveCountdown = 5;

		yield return null;
		var spawnedEnemy = GameObject.FindWithTag ("Enemy");
		var prefab = PrefabUtility.GetPrefabParent (spawnedEnemy);
		Assert.AreEqual (enemyPrefab, prefab);
	}
}
