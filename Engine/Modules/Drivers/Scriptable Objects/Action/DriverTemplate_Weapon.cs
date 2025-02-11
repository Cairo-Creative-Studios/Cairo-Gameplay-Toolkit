﻿using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace UDT.Drivers
{
    [CreateAssetMenu(menuName = "Drivers/Action/AWeapon", fileName = "[DRIVER] Weapon")]
    public class DriverTemplate_Weapon : DriverTemplate
    {
        [Header("")]
        [Header(" -- Weapon -- ")]
        /// <summary>
        /// Whether to block the Player from being able to weild this weapon.
        /// </summary>
        [Tooltip("Whether to block the Player from being able to weild this weapon.")]
        [Foldout("Properties")]
        public bool blockPlayer = false;
        /// <summary>
        /// What Level the Player must be at to weild the Weapon.
        /// </summary>
        [Tooltip("What Level the Player must be at to weild the Weapon.")]
        [Foldout("Properties")]
        public int weildLevel = 0;
        /// <summary>
        /// The amount of Ammo in the weapon when it's created
        /// </summary>
        [Tooltip("The amount of Ammo in the weapon when it's created")]
        [Foldout("Properties")]
        public int startingAmmo = 1;
        /// <summary>
        /// The Max Amount of Ammo in a Clip
        /// </summary>
        [Tooltip("The Max Amount of Ammo in a Clip")]
        [Foldout("Properties")]
        public int ammoMax = 1;
        /// <summary>
        /// The Amount of Ammo Clips
        /// </summary>
        [Tooltip("The Amount of Ammo Clips")]
        [Foldout("Properties")]
        public int clipCount = 0;

        /// <summary>
        /// The Projectile that is fired by the weapon, ignored if the Attached
        /// </summary>
        [Tooltip("The Projectile that is fired by the weapon, ignored if the Attached")]
        [Foldout("Projectile")]
        public GameObject projectile;
        /// <summary>
        /// Whether the Projectile Game Object is attached to the Weapon
        /// </summary>
        [Tooltip("Whether the Projectile Game Object is attached to the Weapon")]
        [Foldout("Projectile")]
        public bool attached = false;
        /// <summary>
        /// The Path to the attached Projectile.
        /// </summary>
        [Tooltip("The Path to the attached Projectile.")]
        [Foldout("Projectile")]
        public string attachedPath = "";
        /// <summary>
        /// The Amount of Seconds between each shot
        /// </summary>
        [Tooltip("The Amount of Seconds between each shot")]
        [Foldout("Projectile")]
        public float fireRate = 0.5f;
        /// <summary>
        /// Only allows fire if an outside Script sets canFire to true
        /// </summary>
        [Tooltip("Only allows fire if an outside Script sets canFire to true")]
        [Foldout("Projectile")]
        public bool customFireState = false;

        /// <summary>
        /// The Muzzle Flash Particle System Prefab to Play when the Weapon shoots
        /// </summary>
        [Tooltip("The Muzzle Flash Particle System Prefab to Play when the Weapon shoots")]
        [Foldout("Effects")]
        public GameObject muzzleFlash;
        /// <summary>
        /// The Path in the Root Object to the Transform where the Muzzle Flash should be Created
        /// </summary>
        [Tooltip("The Path in the Root Object to the Transform where the Muzzle Flash should be Created")]
        [Foldout("Effects")]
        public string muzzlePath;

        //Initialize the driver Class for this driver
        private void OnEnable()
        {
            //Set Default Class
            this.driverProperties.main.driverClass = "UDT.Drivers.Weapon";

            //Set Default Input
            SetInputTranslation(new string[] { "Shoot" }, new string[] { "Shoot" });

            SetAnimationParameters("Equip, Charge, Fire, PutAway, Melee".TokenArray());

            SetScriptingEvents("Shot,Pickup,Putdown".TokenArray());
        }
    }
}
