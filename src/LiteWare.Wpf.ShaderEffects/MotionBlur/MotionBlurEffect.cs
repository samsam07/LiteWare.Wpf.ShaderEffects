// MIT License
//
// Copyright (c) 2020 Hisham Maudarbocus
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LiteWare.Wpf.ShaderEffects
{
    /// <summary>
    /// A bitmap effect that applies a directional motion blur on the target texture.
    /// </summary>
    public class MotionBlurEffect : ShaderEffect
    {
        /// <summary>
        /// The <see cref="Input"/> brush dependency property.
        /// </summary>
        /// <remarks>S0</remarks>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty(nameof(Input), typeof(MotionBlurEffect), 0);

        /// <summary>
        /// The <see cref="BlurAngle"/> brush dependency property. Default value is 0.
        /// </summary>
        /// <remarks>C0</remarks>
        public static readonly DependencyProperty BlurAngleProperty = DependencyProperty.Register
        (
            nameof(BlurAngle),
            typeof(double),
            typeof(MotionBlurEffect),
            new UIPropertyMetadata(0d, PixelShaderConstantCallback(0))
        );

        /// <summary>
        /// The <see cref="BlurMagnitude"/> brush dependency property. Default value is 10.
        /// </summary>
        /// <remarks>C1</remarks>
        public static readonly DependencyProperty BlurMagnitudeProperty = DependencyProperty.Register
        (
            nameof(BlurMagnitude),
            typeof(double),
            typeof(MotionBlurEffect),
            new UIPropertyMetadata(10d, PixelShaderConstantCallback(1))
        );

        /// <summary>
        /// Gets or sets the input brush.
        /// </summary>
        public Brush Input
        {
            get => (Brush)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }

        /// <summary>
        /// Gets or sets an angle at which motion blur is applied.
        /// </summary>
        public double BlurAngle
        {
            get => (double)GetValue(BlurAngleProperty);
            set => SetValue(BlurAngleProperty, value);
        }

        /// <summary>
        /// Gets or sets the magnitude of the motion blur.
        /// </summary>
        public double BlurMagnitude
        {
            get => (double)GetValue(BlurMagnitudeProperty);
            set => SetValue(BlurMagnitudeProperty, value);
        }

        /// <summary>
        /// Initializes a default instance of the <see cref="MotionBlurEffect"/> class.
        /// </summary>
        public MotionBlurEffect()
        {
            PixelShader = PixelShaderUtility.LoadPixelShader("MotionBlur/MotionBlurEffect.ps");

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(BlurAngleProperty);
            UpdateShaderValue(BlurMagnitudeProperty);
        }
    }
}