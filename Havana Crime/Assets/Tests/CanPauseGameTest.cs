using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CanPauseGameTest {

	[Test]
	public void PauseGameTestPasses() {
		var menu = new GameObject ().AddComponent<CharacteristicsMenu> ();
		menu.isPaused = false;
		menu.charMenu = new GameObject ();
		menu.Pause ();
		menu.Resume ();
		if (! menu.isPaused)
			menu.Pause ();
		Assert.AreEqual (menu.isPaused, true); //palyginami gautas atsakymas su tuo kuri tikimes gauti
	}
}
