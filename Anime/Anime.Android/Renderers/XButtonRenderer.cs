using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Anime.Droid.Renderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(XButtonRenderer))]
namespace Anime.Droid.Renderers
{
    public class XButtonRenderer : ButtonRenderer
	{
		private GradientDrawable normal;
		private GradientDrawable pressed;


		public XButtonRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e) 
        { 
            base.OnElementChanged(e);

			if (Control != null) {
				//параметры текущей кнопки
				var density = Math.Max(1, Resources.DisplayMetrics.Density);
				var button = (Button)e.NewElement;
				var borderRadius = button.CornerRadius * density;
				var borderWidth = button.BorderWidth * density;

				//обычное состояние кнопки
				normal = new GradientDrawable();
				normal.SetColor(button.BackgroundColor.ToAndroid());
				normal.SetStroke((int)borderWidth, button.BorderColor.ToAndroid());
				normal.SetCornerRadius(borderRadius);

				//повышаем яркости BackgroundColor кнопки на 5 процентов
				var highlight = button.BackgroundColor.AddLuminosity(0.05).ToAndroid();
				
				//нажатое состояние кнопки
				pressed = new GradientDrawable();
				pressed.SetColor(highlight);
				pressed.SetStroke((int)borderWidth, button.BorderColor.ToAndroid());
				pressed.SetCornerRadius(borderRadius);

				//лист состояний
				var sld = new StateListDrawable();
				sld.AddState(new int[] { Android.Resource.Attribute.StatePressed }, pressed);
				sld.AddState(new int[] { }, normal);

				Control.SetBackground(sld);
				Control.SetTextColor(Element.TextColor.ToAndroid());
			}
		}
    }
}