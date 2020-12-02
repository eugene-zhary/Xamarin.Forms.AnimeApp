using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Anime.Controls;
using Anime.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;



[assembly: ExportRenderer(typeof(XFrame), typeof(XFrameRenderer))]
namespace Anime.Droid.Renderers
{
    public class XFrameRenderer : FrameRenderer
    {
        public XFrameRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null) {
                UpdateCornerRadius();
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(XFrame.CornerRadius) || e.PropertyName == nameof(XFrame)) {
                UpdateCornerRadius();
            }
        }

        private void UpdateCornerRadius()
        {
            GradientDrawable backgroundGradient = new GradientDrawable();

            var element = (Element as XFrame);
            var cornerRadius = element?.MultiCornerRadius;

            if (!cornerRadius.HasValue) {
                return;
            }

            var topLeftCorner = Context.ToPixels(cornerRadius.Value.TopLeft);
            var topRightCorner = Context.ToPixels(cornerRadius.Value.TopRight);
            var bottomLeftCorner = Context.ToPixels(cornerRadius.Value.BottomLeft);
            var bottomRightCorner = Context.ToPixels(cornerRadius.Value.BottomRight);

            var cornerRadii = new[] {
                topLeftCorner,
                topLeftCorner,

                topRightCorner,
                topRightCorner,

                bottomLeftCorner,
                bottomLeftCorner,

                bottomRightCorner,
                bottomRightCorner,
            };

            backgroundGradient.SetCornerRadii(cornerRadii);
            backgroundGradient.SetColor(element.BackgroundColor.ToAndroid());

            this.SetBackground(backgroundGradient);
        }
    }
}