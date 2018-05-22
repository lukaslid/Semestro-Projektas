using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
//using UnityEditor;

public class EnemySpawnerTest {

	[Test]
	public void EnemyspawnerTestSimplePasses() {
		Transform enemyPrefab = Resources.Load ("Tests/enemy", typeof(Transform)) as Transform;
		var enemySpawner = new GameObject ().AddComponent<WaveSpawner> ();
		enemySpawner.enemy = enemyPrefab;
		enemySpawner.SpawnEnemy (enemySpawner.enemy);
		Assert.AreEqual (enemyPrefab.name, "enemy"); //palyginami gautas atsakymas su tuo kuri tikimes gauti
	}
}
