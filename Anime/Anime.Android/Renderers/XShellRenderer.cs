using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.BottomNavigation;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Anime.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Shell), typeof(XShellRenderer))]
namespace Anime.Droid.Renderers
{
    public class XShellRenderer : ShellRenderer
    {
        public XShellRenderer(Context context) : base(context)
        {

        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
        {
            return new XShellItemRenderer(this);
        }

    }

    public class XShellItemRenderer : ShellItemRenderer
    {
        BottomNavigationView bottomView;

        public XShellItemRenderer(IShellContext context) : base(context)
        {

        }

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var outerlayout = base.OnCreateView(inflater, container, savedInstanceState);
            bottomView = outerlayout.FindViewById<BottomNavigationView>(Resource.Id.bottomtab_tabbar);

            //без текста
            bottomView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityUnlabeled;

            //высота пенли, размер иконок
            var parameters = bottomView.LayoutParameters;
            parameters.Height = 150;
            bottomView.ItemIconSize = Convert.ToInt32(parameters.Height * 0.5d);

            //убирает анимации для элементов нижней панели
            bottomView.ItemBackground = null;

            return outerlayout;
        }

    }
}