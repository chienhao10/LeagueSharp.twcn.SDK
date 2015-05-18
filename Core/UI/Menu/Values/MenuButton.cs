﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuButton.cs" company="LeagueSharp">
//   Copyright (C) 2015 LeagueSharp
//   
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//   
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
//   
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
// </copyright>
// <summary>
//   A Button designed to perform an action when clicked
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace LeagueSharp.SDK.Core.UI.Values
{
    using LeagueSharp.SDK.Core.Enumerations;
    using LeagueSharp.SDK.Core.Extensions.SharpDX;
    using LeagueSharp.SDK.Core.UI.Abstracts;
    using LeagueSharp.SDK.Core.UI.Skins;
    using LeagueSharp.SDK.Core.Utils;

    using SharpDX;

    /// <summary>
    ///     A Button designed to perform an action when clicked
    /// </summary>
    public class MenuButton : AMenuValue
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MenuButton" /> class, with a specified button text.
        /// </summary>
        /// <param name="buttonText">
        ///     The button text
        /// </param>
        public MenuButton(string buttonText)
        {
            this.ButtonText = buttonText;
        }

        #endregion

        #region Delegates

        /// <summary>
        ///     The action
        /// </summary>
        public delegate void ButtonAction();

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the action to be performed when the button is clicked
        /// </summary>
        public ButtonAction Action { get; set; }

        /// <summary>
        ///     Gets or sets the text on the button
        /// </summary>
        public string ButtonText { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the item is being hovered on.
        /// </summary>
        public bool Hovering { get; set; }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        public override Vector2 Position { get; set; }

        /// <summary>
        ///     Gets the width.
        /// </summary>
        public override int Width
        {
            get
            {
                return ThemeManager.Current.Button.Width(this);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Extracts the component.
        /// </summary>
        /// <param name="component">
        ///     The component.
        /// </param>
        public override void Extract(AMenuValue component)
        {
            // Do nothing.
        }

        /// <summary>
        ///     On Draw event.
        /// </summary>
        /// <param name="component">
        ///     The component.
        /// </param>
        /// <param name="position">
        ///     The position.
        /// </param>
        /// <param name="index">
        ///     The index.
        /// </param>
        public override void OnDraw(AMenuComponent component, Vector2 position, int index)
        {
            ThemeManager.Current.Button.OnDraw(component, position, index);
        }

        /// <summary>
        ///     On Windows Process Message event.
        /// </summary>
        /// <param name="args">
        ///     The event data.
        /// </param>
        public override void OnWndProc(WindowsKeys args)
        {
            if (!this.Container.Visible)
            {
                return;
            }

            var rect = ThemeManager.Current.Button.ButtonBoundaries(this.Position, this.Container);

            if (args.Cursor.IsUnderRectangle(rect.X, rect.Y, rect.Width, rect.Height))
            {
                this.Hovering = true;
                if (args.Msg == WindowsMessages.LBUTTONDOWN && this.Action != null)
                {
                    this.Action();
                }
            }
            else
            {
                this.Hovering = false;
            }
        }

        #endregion
    }
}