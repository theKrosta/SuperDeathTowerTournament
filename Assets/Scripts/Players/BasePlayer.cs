using Assets.Scripts;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    private float _appliedForce = 0;

    private bool _canSmash = false;

    private PlayerStatus _currentStatus = PlayerStatus.Nothing;

    private bool _isCharging = false;

    private bool _isFaceRight = false;

    private bool _isFalling = false;

    private bool _isJumping = false;

    private bool _isOutOfControl = false;

    //[HideInInspector]
    private float _smashForce = 0.0f;

    private bool _specialAbilityIsReady = true;

    public float AbilityCooldown = 3.0f;

    public float BaseSmashForce = 300;

    public float DeadZoneDown = -0.4f;

    public float DeadZoneUp = 0.4f;

    public float FallingTimeRate = 1.0f;

    public float MaxSmashForce = 450;

    public float SmashChargeSpeed = 20;

    public float SmashForceLevel = 350;

    private void Start()
    {
        _currentStatus = PlayerStatus.Idle;
    }

    private void Update()
    {
    }

    protected void LoseControl()
    {
    }

    protected void ChargeSmash()
    {
    }

    protected void Suicide()
    {
    }

    protected void ReceiveShot()
    {
    }

    protected void ThrowSmash()
    {
    }

    protected virtual void SpecialAbility()
    {
    }
}