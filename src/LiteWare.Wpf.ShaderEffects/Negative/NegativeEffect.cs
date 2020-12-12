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
    /// A bitmap effect that paints the negative of the target texture.
    /// </summary>
    public class NegativeEffect : ShaderEffect
    {
        /// <summary>
        /// The <see cref="Input"/> brush dependency property.
        /// </summary>
        /// <remarks>S0</remarks>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty(nameof(Input), typeof(NegativeEffect), 0);

        /// <summary>
        /// Gets or sets the input brush.
        /// </summary>
        public Brush Input
        {
            get => (Brush)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }

        /// <summary>
        /// Initializes a default instance of the <see cref="NegativeEffect"/> class.
        /// </summary>
        public NegativeEffect()
        {
            PixelShader = PixelShaderUtility.LoadPixelShader("Negative/NegativeEffect.ps");
            UpdateShaderValue(InputProperty);
        }
    }
}