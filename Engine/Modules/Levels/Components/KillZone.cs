﻿//Script Developed for The Cairo Engine, by Richy Mackro (Chad Wolfe), on behalf of Cairo Creative Studios

using System;
using System.Collections.Generic;
using UnityEngine;
using UDT.Drivers;

namespace UDT
{
    /// <summary>
    /// A Kill Zone will Kill Entities within it, unless Entities have been excluding from it's Killing Properties.
    /// </summary>
    public class KillZone : MonoBehaviour
    {
        /// <summary>
        /// The Type of Damage to Apply to Entities within this Kill Zone.
        /// </summary>
        public DamageInstegator instegator;

    }
}
