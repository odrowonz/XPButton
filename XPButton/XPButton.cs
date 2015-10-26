﻿#region License
//   Copyright 2015 Brook Shi
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 
#endregion

using System;
using System.Collections.Generic;
using System.Numerics;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.Foundation;
using System.Diagnostics;

namespace XP
{
    public sealed class XPButton : Button
    {
        private ContentControl _symbol;
        private Viewbox _symbolView;
        private RelativePanel _visualPanel;
        private ContentPresenter _contentPresenter;

        #region property

        public IconElement Icon
        {
            get { return (IconElement)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(IconElement), typeof(XPButton), null);

        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }
        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register("IconSize", typeof(double), typeof(XPButton), new PropertyMetadata(20));

        public Thickness IconMargin
        {
            get { return (Thickness)GetValue(IconMarginProperty); }
            set { SetValue(IconMarginProperty, value); }
        }
        public static readonly DependencyProperty IconMarginProperty =
            DependencyProperty.Register("IconMargin", typeof(Thickness), typeof(XPButton), new PropertyMetadata(new Thickness(3, 0, 3, 0)));

        public IconPosition IconPosition
        {
            get { return (IconPosition)GetValue(IconPositionProperty); }
            set { SetValue(IconPositionProperty, value); }
        }
        public static readonly DependencyProperty IconPositionProperty =
            DependencyProperty.Register("IconPosition", typeof(IconPosition), typeof(XPButton), new PropertyMetadata(IconPosition.Left));

        public Brush IconForeground
        {
            get { return (Brush)GetValue(IconForegroundProperty); }
            set { SetValue(IconForegroundProperty, value); }
        }
        public static readonly DependencyProperty IconForegroundProperty =
            DependencyProperty.Register("IconForeground", typeof(Brush), typeof(XPButton), null);

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(XPButton), new PropertyMetadata(new CornerRadius(0)));

        public Thickness ContentMargin
        {
            get { return (Thickness)GetValue(ContentMarginProperty); }
            set { SetValue(ContentMarginProperty, value); }
        }
        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register("ContentMargin", typeof(Thickness), typeof(XPButton), new PropertyMetadata(new Thickness(0)));

        public Brush PointerOverBackground
        {
            get { return (Brush)GetValue(PointerOverBackgroundProperty); }
            set { SetValue(PointerOverBackgroundProperty, value); }
        }
        public static readonly DependencyProperty PointerOverBackgroundProperty =
            DependencyProperty.Register("PointerOverBackground", typeof(Brush), typeof(XPButton), null);

        public Brush PointerOverTextForeground
        {
            get { return (Brush)GetValue(PointerOverTextForegroundProperty); }
            set { SetValue(PointerOverTextForegroundProperty, value); }
        }
        public static readonly DependencyProperty PointerOverTextForegroundProperty =
            DependencyProperty.Register("PointerOverTextForeground", typeof(Brush), typeof(XPButton), null);

        public Brush PointerOverIconForeground
        {
            get { return (Brush)GetValue(PointerOverIconForegroundProperty); }
            set { SetValue(PointerOverIconForegroundProperty, value); }
        }
        public static readonly DependencyProperty PointerOverIconForegroundProperty =
            DependencyProperty.Register("PointerOverIconForeground", typeof(Brush), typeof(XPButton), null);

        public Brush PointerOverBorderBrush
        {
            get { return (Brush)GetValue(PointerOverBorderBrushProperty); }
            set { SetValue(PointerOverBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty PointerOverBorderBrushProperty =
            DependencyProperty.Register("PointerOverBorderBrush", typeof(Brush), typeof(XPButton), null);

        public Brush PressedBackground
        {
            get { return (Brush)GetValue(PressedBackgroundProperty); }
            set { SetValue(PressedBackgroundProperty, value); }
        }
        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(XPButton), null);

        public Brush PressedTextForeground
        {
            get { return (Brush)GetValue(PressedTextForegroundProperty); }
            set { SetValue(PressedTextForegroundProperty, value); }
        }
        public static readonly DependencyProperty PressedTextForegroundProperty =
            DependencyProperty.Register("PressedTextForeground", typeof(Brush), typeof(XPButton), null);

        public Brush PressedIconForeground
        {
            get { return (Brush)GetValue(PressedIconForegroundProperty); }
            set { SetValue(PressedIconForegroundProperty, value); }
        }
        public static readonly DependencyProperty PressedIconForegroundProperty =
            DependencyProperty.Register("PressedIconForeground", typeof(Brush), typeof(XPButton), null);

        public Brush PressedBorderBrush
        {
            get { return (Brush)GetValue(PressedBorderBrushProperty); }
            set { SetValue(PressedBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty PressedBorderBrushProperty =
            DependencyProperty.Register("PresseddBorderBrush", typeof(Brush), typeof(XPButton), null);

        public Brush DisabledBackground
        {
            get { return (Brush)GetValue(DisabledBackgroundProperty); }
            set { SetValue(DisabledBackgroundProperty, value); }
        }
        public static readonly DependencyProperty DisabledBackgroundProperty =
            DependencyProperty.Register("DisabledBackground", typeof(Brush), typeof(XPButton), null);

        public Brush DisabledTextForeground
        {
            get { return (Brush)GetValue(DisabledTextForegroundProperty); }
            set { SetValue(DisabledTextForegroundProperty, value); }
        }
        public static readonly DependencyProperty DisabledTextForegroundProperty =
            DependencyProperty.Register("DisabledTextForeground", typeof(Brush), typeof(XPButton), null);

        public Brush DisabledIconForeground
        {
            get { return (Brush)GetValue(DisabledIconForegroundProperty); }
            set { SetValue(DisabledIconForegroundProperty, value); }
        }
        public static readonly DependencyProperty DisabledIconForegroundProperty =
            DependencyProperty.Register("DisabledIconForeground", typeof(Brush), typeof(XPButton), null);

        public Brush DisabledBorderBrush
        {
            get { return (Brush)GetValue(DisabledBorderBrushProperty); }
            set { SetValue(DisabledBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty DisabledBorderBrushProperty =
            DependencyProperty.Register("DisabledBorderBrush", typeof(Brush), typeof(XPButton), null);

        #endregion

        #region adjust content

        void AdjustContentPresenter(double width)
        {
            switch (IconPosition)
            {
                case IconPosition.Left:
                    AdjustContentPresenterForLeft(width);
                    break;
                case IconPosition.Right:
                    AdjustContentPresenterForRight(width);
                    break;
            }
        }

        void AdjustContentPresenterForLeft(double width)
        {
            var buttonPaddingWidth = Padding.Left + Padding.Right;
            var iconMarginWidth = IconMargin.Right;

            var left = (width - _symbolView.DesiredSize.Width - _contentPresenter.DesiredSize.Width
                - iconMarginWidth - buttonPaddingWidth) / 2;

            _symbolView.Margin = new Thickness(left, 0, 0, 0);
        }

        void AdjustContentPresenterForRight(double width)
        {
            var buttonPaddingWidth = Padding.Left + Padding.Right;
            var iconMarginWidth = IconMargin.Right;

            var right = (width - _symbolView.DesiredSize.Width - _contentPresenter.DesiredSize.Width
                - iconMarginWidth - buttonPaddingWidth) / 2;

            _symbolView.Margin = new Thickness(0, 0, right, 0);
        }

        double GetDesiredWidth()
        {
            var buttonPaddingWidth = Padding.Left + Padding.Right;
            var iconMarginWidth = IconMargin.Left + IconMargin.Right;

            return buttonPaddingWidth + iconMarginWidth + _symbolView.DesiredSize.Width * 2 + _contentPresenter.DesiredSize.Width;
        }

        #endregion

        public XPButton()
        {
            this.DefaultStyleKey = typeof(XPButton);
            Loaded += XPButton_Loaded;
        }

        private void XPButton_Loaded(object sender, RoutedEventArgs e)
        {
            InitProperty();
            AdjustContentPresenter(ActualWidth);
        }

        private void InitProperty()
        {
            if (IconForeground == null) IconForeground = Foreground;

            if (PointerOverBackground == null) PointerOverBackground = Background;
            if (PointerOverTextForeground == null) PointerOverTextForeground = Foreground;
            if (PointerOverIconForeground == null) PointerOverIconForeground = Foreground;
            if (PointerOverBorderBrush == null) PointerOverBorderBrush = BorderBrush;

            if (PressedBackground == null) PressedBackground = Background;
            if (PressedTextForeground == null) PressedTextForeground = Foreground;
            if (PressedIconForeground == null) PressedIconForeground = Foreground;
            if (PressedBorderBrush == null) PressedBorderBrush = BorderBrush;

            if (DisabledBackground == null) DisabledBackground = Background;
            if (DisabledTextForeground == null) DisabledTextForeground = Foreground;
            if (DisabledIconForeground == null) DisabledIconForeground = Foreground;
            if (DisabledBorderBrush == null) DisabledBorderBrush = BorderBrush;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _visualPanel = (RelativePanel)GetTemplateChild("VisualPanel");
            _symbol = (ContentControl)GetTemplateChild("Symbol");
            _symbolView = (Viewbox)GetTemplateChild("SymbolView");
            _contentPresenter = (ContentPresenter)GetTemplateChild("ContentPresenter");
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            //AdjustContentPresenter(finalSize);
            return base.ArrangeOverride(finalSize);
        }
    }
}
