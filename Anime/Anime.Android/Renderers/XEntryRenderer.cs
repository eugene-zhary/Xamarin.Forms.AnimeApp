using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Widget;
using Anime.Controls;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(XEntry), typeof(Anime.Droid.Renderers.XEntryRenderer))]
namespace Anime.Droid.Renderers
{
    class XEntryRenderer : EntryRenderer
    {
        public XEntryRenderer(Context context) : base(context)
        {

        }


        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (sender is XEntry customEntry) {

                switch (e.PropertyName) {

                    case nameof(customEntry.XHighlightColor):
                        SetXHighlightColor(customEntry);
                        break;

                    case nameof(customEntry.XHandleColor):
                        SetXHandleColor(customEntry);
                        break;

                    case nameof(customEntry.XTintColor):
                    case nameof(customEntry.XBorderThickness):
                    case nameof(customEntry.XCornerRadius):
                        SetBackground(customEntry);
                        break;

                    case nameof(customEntry.XPadding):
                        SetXPadding(customEntry);
                        break;
                }
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            if (e.NewElement is XEntry customEntry) {

                SetXHighlightColor(customEntry);
                SetXHandleColor(customEntry);
                SetBackground(customEntry);
                SetXPadding(customEntry);
            }
        }

        void SetXHighlightColor(in XEntry customEntry)
        {
            //set highlight color
            Control.SetHighlightColor(customEntry.XHighlightColor.ToAndroid());

        }

        void SetXHandleColor(in XEntry customEntry)
        {
            //set handle color
            JNIEnv.SetField(Control.Handle, JNIEnv.GetFieldID(JNIEnv.FindClass(typeof(TextView)), "mCursorDrawableRes", "I"), 0);
            TextView textViewTemplate = new TextView(Control.Context);

            var field = textViewTemplate.Class.GetDeclaredField("mEditor");
            field.Accessible = true;
            var editor = field.Get(Control);

            string[] fieldsNames = { "mTextSelectHandleLeftRes", "mTextSelectHandleRightRes", "mTextSelectHandleRes" };
            string[] drawablesNames = { "mSelectHandleLeft", "mSelectHandleRight", "mSelectHandleCenter" };

            for (int index = 0; index < fieldsNames.Length && index < drawablesNames.Length; index++) {

                field = textViewTemplate.Class.GetDeclaredField(fieldsNames[index]);
                field.Accessible = true;
                Drawable handleDrawable = ContextCompat.GetDrawable(Context, field.GetInt(Control));

                handleDrawable.SetColorFilter(new PorterDuffColorFilter(customEntry.XHandleColor.ToAndroid(), PorterDuff.Mode.SrcIn));

                field = editor.Class.GetDeclaredField(drawablesNames[index]);
                field.Accessible = true;
                field.Set(editor, handleDrawable);
            }
        }

        void SetBackground(in XEntry customEntry)
        {
            if (customEntry == null) return;

            var gd = new GradientDrawable();
            gd.SetColor(Element.BackgroundColor.ToAndroid());
            gd.SetCornerRadius(Context.ToPixels(customEntry.XCornerRadius));
            gd.SetStroke((int)Context.ToPixels(customEntry.XBorderThickness), customEntry.XTintColor.ToAndroid());
            
            Control.SetBackground(gd);
        }

        void SetXPadding(in XEntry customEntry)
        {
            if (customEntry == null) return;

            var padTop = (int)Context.ToPixels(customEntry.XPadding.Top);
            var padBottom = (int)Context.ToPixels(customEntry.XPadding.Bottom);
            var padLeft = (int)Context.ToPixels(customEntry.XPadding.Left);
            var padRight = (int)Context.ToPixels(customEntry.XPadding.Right);

            Control.SetPadding(padLeft, padTop, padRight, padBottom);
        }
    }
}