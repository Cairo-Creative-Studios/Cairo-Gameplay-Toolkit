﻿//Script Developed for The Cairo Engine, by Richy Mackro (Chad Wolfe), on behalf of Cairo Creative Studios

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDT.AssetScripting;
using NaughtyAttributes;

namespace UDT.Drivers
{
    /// <summary>
    /// You can extend the Damage Instegator to create new kinds of Damage, but most kinds of Damage can and should be made by creating 
    /// a new Damage Type Info and modifying it's values. 
    /// </summary>
    public class DamageInstegator : ScriptableObject
    {
        /// <summary>
        /// The Name of this Damage, to identify what kind of Damage is to be dealt to Entities (Damage is calculated differently per-entity based on certain conditions).
        /// </summary>
        [Tooltip("The Name of this Damage, to identify what kind of Damage is to be dealt to Entities (Damage is calculated differently per-entity based on certain conditions).")]
        [Foldout("Properties")]
        public string type = "Default Damage";
        /// <summary>
        /// The radius of Damage to be dealt. 0 means that the Damage doesn't check for Entities outside of the Damage Source,\nlarger that 0 checks all objects within this Radius to see if they're Entities that can be Damaged by this Damage Type
        /// </summary>
        [Tooltip("The radius of Damage to be dealt. 0 means that the Damage doesn't check for Entities outside of the Damage Source,\nlarger that 0 checks all objects within this Radius to see if they're Entities that can be Damaged by this Damage Type")]
        [Foldout("Properties")]
        public float radius = 0.0f;
        /// <summary>
        /// Multiply to the amount of Damage by the distance from the Center of the Damage Source to the Damage Target.\n Useful cases would be explosions, where the amount of damage decreases the further you are from the center of the burst.
        /// </summary>
        [Tooltip("Multiply to the amount of Damage by the distance from the Center of the Damage Source to the Damage Target.\n Useful cases would be explosions, where the amount of damage decreases the further you are from the center of the burst.")]
        [Foldout("Properties")]
        public float distanceFraction = 1.0f;
        /// <summary>
        /// The amount of Damage to use for the Damage Instegator.
        /// </summary>
        [Tooltip("The amount of Damage to use for the Damage Instegator.")]
        [Foldout("Properties")]
        public float damage = 1.0f;
        /// <summary>
        /// The ID of the Team that owns this Damage Instegator
        /// </summary>
        [Tooltip("The ID of the Team that owns this Damage Instegator")]
        [Foldout("Properties")]
        public int team;

        /// <summary>
        /// The position at which the object that caused Damage to the Entity is when the Damage Calculation occurs.
        /// </summary>
        [Tooltip("The position at which the object that caused Damage to the Entity is when the Damage Calculation occurs.")]
        [Foldout("Components")]
        public Vector3 damageSource;
        /// <summary>
        /// The Entity that created this Damage Instegator
        /// </summary>
        [Tooltip("The Entity that created this Damage Instegator")]
        [Foldout("Components")]
        public object spawnedFrom;

        public static void Instantiate(DamageInstegator instegator, Vector3 position, DriverCore spawnedFrom, int team)
        {
            DamageInstegator instancedInstegator = ScriptableObject.Instantiate(instegator);
            instancedInstegator.damageSource = position;
            instancedInstegator.spawnedFrom = spawnedFrom;
            instancedInstegator.team = team;
            instancedInstegator.Instegate();
        }

        /// <summary>
        /// The actual trigger of Damage Calculation. Finds the Entities that should be Damaged, and then passes Damage information off to them.
        /// </summary>
        private void Instegate()
        {
            Collider[] hitColliders = Physics.OverlapSphere(damageSource, radius);
            foreach (Collider collider in hitColliders)
            {
                DriverCore damageReciever = collider.GetComponent<DriverCore>();
                if (damageReciever != null)
                    damageReciever.scope.properties["health"] = (float)damageReciever.scope.properties["health"] - damage;
            }
        }
    }

}
