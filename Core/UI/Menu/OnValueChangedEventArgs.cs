﻿using System;
using LeagueSharp.CommonEx.Core.UI.Abstracts;

namespace LeagueSharp.CommonEx.Core.UI
{
    /// <summary>
    ///     Arguements for the OnValueChanged event.
    /// </summary>
    public class OnValueChangedEventArgs<T> : EventArgs where T:AMenuValue
    {
        /// <summary>
        ///  The new Value.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the OnValueChangedEventArgs class.
        /// </summary>
        /// <param name="value">The value.</param>
        public OnValueChangedEventArgs(T value)
        {
            Value = value;
        }
    }
}