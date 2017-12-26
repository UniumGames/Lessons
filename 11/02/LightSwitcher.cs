using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSwitcher : MonoBehaviour {
	// публичное свойство, чтобы передать ссылку на источник света
	public Light light;
	Text textField;

	void Start () {
		Button switchButton = GetComponent<Button>();
		textField = GetComponentInChildren<Text>();
		switchButton.onClick.AddListener(SwitchLight);
	}
	
	void SwitchLight () {
		// если свет включен
		if (light.intensity == 1) {
			// то выключаем
			light.intensity = 0;
			// и меняем текст на кнопке
			textField.text = "Выключено";
		}
		// если свет выключен,
		// то все наоборот
		else {
			light.intensity = 1;
			textField.text = "Включено";
		}
	}
}
