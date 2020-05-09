using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HelloWorld
{
    public partial class RelativePage : ContentPage
    {
        public RelativePage()
        {
            InitializeComponent();

            var layout = new RelativeLayout();
            Content = layout;

            var aquaBox = new BoxView { Color = Color.Aqua };
            layout.Children.Add(aquaBox,
                widthConstraint: Constraint.RelativeToParent(parent => parent.Width),
                heightConstraint: Constraint.RelativeToParent(parent => parent.Height));

            var silverBox = new BoxView { Color = Color.Silver };
            layout.Children.Add(silverBox,
               yConstraint: Constraint.RelativeToView(aquaBox, (RelativeLayout, element) => element.Height + 20));


        }
    }
}
