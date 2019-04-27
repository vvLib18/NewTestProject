using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class FlexibleUIButton : FlexibleUI {

	public enum ButtonType {
		Default,
		Decline,
		Confirm,
		Warning
	}

	Image image;
	Button button;
	Image icon;
	public ButtonType buttonType;

	protected override void OnSkinUI() {
		base.OnSkinUI();
		image = GetComponent<Image>();
		button = GetComponent<Button>();
		
		icon = GameObject.Find("Icon").GetComponent<Image>();

		button.transition = Selectable.Transition.SpriteSwap;
		button.targetGraphic = image;

		image.sprite = skinData.buttonSprite;
		image.type = Image.Type.Sliced;
		button.spriteState = skinData.buttonSpriteState;

		switch(buttonType){
			case ButtonType.Default:
				icon.color = skinData.defaultColor;
				break;
			case ButtonType.Decline:
				icon.color = skinData.declineColor;
				break;
			case ButtonType.Confirm:
				icon.color = skinData.confirmColor;
				break;
			case ButtonType.Warning:
				icon.color = skinData.warningColor;
				break;
		}
	}
}
