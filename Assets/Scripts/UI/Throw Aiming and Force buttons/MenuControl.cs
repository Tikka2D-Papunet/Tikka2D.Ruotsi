using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuControl : MonoBehaviour
{
    [SerializeField] AutomaticAimingButton automaticAimingButton;
    [SerializeField] MouseAimingButton manualAimingButton;
    [SerializeField] AutomaticThrowForceButton automaticThrowForceButton;
    [SerializeField] ControlledThrowForceButton manualThrowForceButton;
    private void Start()
    {
        automaticAimingButton.GetComponent<AutomaticAimingButton>();
        manualAimingButton.GetComponent<MouseAimingButton>();
        automaticThrowForceButton.GetComponent<AutomaticThrowForceButton>();
        manualThrowForceButton.GetComponent<ControlledThrowForceButton>();

    }
    public void LoadControlMouseTargeting()
    {
        Crosshair.controlMouseTargeting = true;
        Crosshair.automaticMouseTargeting = false;
        FollowCursor.controlMouseTargeting = true;
        FollowCursor.automaticMouseTargeting = false;
        Rotate.controlMouseTargeting = true;
        Rotate.automaticMouseTargeting = false;
        MouseAimingButton.controlMouseTargeting = true;
        MouseAimingButton.automaticMouseTargeting = false;
        AutomaticAimingButton.controlMouseTargeting = true;
        AutomaticAimingButton.automaticMouseTargeting = false;
        manualAimingButton.buttonImage.sprite = manualAimingButton.spriteClicked;
        automaticAimingButton.buttonImage.sprite = automaticAimingButton.originalSprite;
    }
    public void LoadAutomaticMouseTargeting()
    {
        Crosshair.automaticMouseTargeting = true;
        Crosshair.controlMouseTargeting = false;
        FollowCursor.automaticMouseTargeting = true;
        FollowCursor.controlMouseTargeting = false;
        Rotate.automaticMouseTargeting = true;
        Rotate.controlMouseTargeting = false;
        MouseAimingButton.automaticMouseTargeting = true;
        MouseAimingButton.controlMouseTargeting = false;
        AutomaticAimingButton.automaticMouseTargeting = true;
        AutomaticAimingButton.controlMouseTargeting = false;
        automaticAimingButton.buttonImage.sprite = automaticAimingButton.spriteClicked;
        manualAimingButton.buttonImage.sprite = automaticAimingButton.originalSprite;
    }
    public void AutomaticThrowForce()
    {
        MouseAndDartManager.automaticThrowForce = true;
        MouseAndDartManager.controlledThrowForce = false;
        AutomaticThrowForceButton.automaticThrowForce = true;
        AutomaticThrowForceButton.controlledThrowForce = false;
        ControlledThrowForceButton.automaticThrowForce = true;
        ControlledThrowForceButton.controlledThrowForce = false;
        automaticThrowForceButton.buttonImage.sprite = automaticThrowForceButton.spriteClicked;
        manualThrowForceButton.buttonImage.sprite = manualThrowForceButton.originalSprite;
    }
    public void ControlledThrowForce()
    {
        MouseAndDartManager.controlledThrowForce = true;
        MouseAndDartManager.automaticThrowForce = false;
        AutomaticThrowForceButton.controlledThrowForce = true;
        AutomaticThrowForceButton.automaticThrowForce = false;
        ControlledThrowForceButton.controlledThrowForce = true;
        ControlledThrowForceButton.automaticThrowForce = false;
        manualThrowForceButton.buttonImage.sprite = manualThrowForceButton.spriteClicked;
        automaticThrowForceButton.buttonImage.sprite = automaticThrowForceButton.originalSprite;
    }
}