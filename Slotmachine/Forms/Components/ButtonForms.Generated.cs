    namespace Slotmachine.FormsControls.Components
    {
        public partial class ButtonForms : FlatRedBall.Forms.Controls.UserControl
        {
            public FlatRedBall.Forms.Controls.Button ButtonInstance { get; set; }
            public ButtonForms () 
            	: base()
            {
                CustomInitialize();
            }
            public ButtonForms (Gum.Wireframe.GraphicalUiElement visual) 
            	: base(visual)
            {
                CustomInitialize();
            }
            protected override void ReactToVisualChanged () 
            {
                ButtonInstance = (FlatRedBall.Forms.Controls.Button)Visual.GetGraphicalUiElementByName("ButtonInstance").FormsControlAsObject;
                base.ReactToVisualChanged();
            }
            partial void CustomInitialize();
        }
    }
