    namespace Slotmachine.GumRuntimes
    {
        #region State Enums
        public enum ButtonBehaviorButtonCategory
        {
            Enabled,
            Disabled,
            Highlighted,
            Pushed,
            HighlightedFocused,
            Focused
        }
        #endregion
        public interface IButtonBehavior
        {
            ButtonBehaviorButtonCategory CurrentButtonBehaviorButtonCategoryState {set;}
        }
    }
