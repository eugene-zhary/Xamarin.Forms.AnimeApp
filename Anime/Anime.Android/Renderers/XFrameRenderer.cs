using Android.App;
using Android.Content;
using Android.Graphics;
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
            base.OnElementPropertyChanged(sender, e);
            UpdateCornerRadius();
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            var view = (XFrame)Element;
            if (view.BorderWidth > 0) {

                using Paint strokePaint = new Paint();
                using RectF rect = new RectF(0, 0, canvas.Width, canvas.Height);

                strokePaint.SetStyle(Paint.Style.Stroke);
                strokePaint.Color = view.BorderColor.ToAndroid();
                strokePaint.StrokeWidth = view.BorderWidth;
                canvas.DrawRoundRect(rect, Element.CornerRadius * 2, Element.CornerRadius * 2, strokePaint);
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