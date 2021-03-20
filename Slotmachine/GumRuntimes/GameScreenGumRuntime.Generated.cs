    using System.Linq;
    namespace Slotmachine.GumRuntimes
    {
        public partial class GameScreenGumRuntime : Gum.Wireframe.GraphicalUiElement
        {
            #region State Enums
            public enum VariableState
            {
                Default,
                Click
            }
            #endregion
            #region State Fields
            VariableState mCurrentVariableState;
            #endregion
            #region State Properties
            public VariableState CurrentVariableState
            {
                get
                {
                    return mCurrentVariableState;
                }
                set
                {
                    mCurrentVariableState = value;
                    switch(mCurrentVariableState)
                    {
                        case  VariableState.Default:
                            ButtonInstance.Height = 28f;
                            ButtonInstance.Text = "ROLL\n";
                            ButtonInstance.Width = 131f;
                            ButtonInstance.X = 33f;
                            ButtonInstance.Y = 66f;
                            break;
                        case  VariableState.Click:
                            ButtonInstance.Rotation = 2f;
                            break;
                    }
                }
            }
            #endregion
            #region State Interpolation
            public void InterpolateBetween (VariableState firstState, VariableState secondState, float interpolationValue) 
            {
                #if DEBUG
                if (float.IsNaN(interpolationValue))
                {
                    throw new System.Exception("interpolationValue cannot be NaN");
                }
                #endif
                bool setButtonInstanceHeightFirstValue = false;
                bool setButtonInstanceHeightSecondValue = false;
                float ButtonInstanceHeightFirstValue= 0;
                float ButtonInstanceHeightSecondValue= 0;
                bool setButtonInstanceWidthFirstValue = false;
                bool setButtonInstanceWidthSecondValue = false;
                float ButtonInstanceWidthFirstValue= 0;
                float ButtonInstanceWidthSecondValue= 0;
                bool setButtonInstanceXFirstValue = false;
                bool setButtonInstanceXSecondValue = false;
                float ButtonInstanceXFirstValue= 0;
                float ButtonInstanceXSecondValue= 0;
                bool setButtonInstanceYFirstValue = false;
                bool setButtonInstanceYSecondValue = false;
                float ButtonInstanceYFirstValue= 0;
                float ButtonInstanceYSecondValue= 0;
                bool setButtonInstanceRotationFirstValue = false;
                bool setButtonInstanceRotationSecondValue = false;
                float ButtonInstanceRotationFirstValue= 0;
                float ButtonInstanceRotationSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        setButtonInstanceHeightFirstValue = true;
                        ButtonInstanceHeightFirstValue = 28f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonInstance.Text = "ROLL\n";
                        }
                        setButtonInstanceWidthFirstValue = true;
                        ButtonInstanceWidthFirstValue = 131f;
                        setButtonInstanceXFirstValue = true;
                        ButtonInstanceXFirstValue = 33f;
                        setButtonInstanceYFirstValue = true;
                        ButtonInstanceYFirstValue = 66f;
                        break;
                    case  VariableState.Click:
                        setButtonInstanceRotationFirstValue = true;
                        ButtonInstanceRotationFirstValue = 2f;
                        break;
                }
                switch(secondState)
                {
                    case  VariableState.Default:
                        setButtonInstanceHeightSecondValue = true;
                        ButtonInstanceHeightSecondValue = 28f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonInstance.Text = "ROLL\n";
                        }
                        setButtonInstanceWidthSecondValue = true;
                        ButtonInstanceWidthSecondValue = 131f;
                        setButtonInstanceXSecondValue = true;
                        ButtonInstanceXSecondValue = 33f;
                        setButtonInstanceYSecondValue = true;
                        ButtonInstanceYSecondValue = 66f;
                        break;
                    case  VariableState.Click:
                        setButtonInstanceRotationSecondValue = true;
                        ButtonInstanceRotationSecondValue = 2f;
                        break;
                }
                var wasSuppressed = mIsLayoutSuspended;
                if (wasSuppressed == false)
                {
                    SuspendLayout(true);
                }
                if (setButtonInstanceHeightFirstValue && setButtonInstanceHeightSecondValue)
                {
                    ButtonInstance.Height = ButtonInstanceHeightFirstValue * (1 - interpolationValue) + ButtonInstanceHeightSecondValue * interpolationValue;
                }
                if (setButtonInstanceWidthFirstValue && setButtonInstanceWidthSecondValue)
                {
                    ButtonInstance.Width = ButtonInstanceWidthFirstValue * (1 - interpolationValue) + ButtonInstanceWidthSecondValue * interpolationValue;
                }
                if (setButtonInstanceXFirstValue && setButtonInstanceXSecondValue)
                {
                    ButtonInstance.X = ButtonInstanceXFirstValue * (1 - interpolationValue) + ButtonInstanceXSecondValue * interpolationValue;
                }
                if (setButtonInstanceYFirstValue && setButtonInstanceYSecondValue)
                {
                    ButtonInstance.Y = ButtonInstanceYFirstValue * (1 - interpolationValue) + ButtonInstanceYSecondValue * interpolationValue;
                }
                if (setButtonInstanceRotationFirstValue && setButtonInstanceRotationSecondValue)
                {
                    ButtonInstance.Rotation = ButtonInstanceRotationFirstValue * (1 - interpolationValue) + ButtonInstanceRotationSecondValue * interpolationValue;
                }
                if (interpolationValue < 1)
                {
                    mCurrentVariableState = firstState;
                }
                else
                {
                    mCurrentVariableState = secondState;
                }
                if (!wasSuppressed)
                {
                    ResumeLayout(true);
                }
            }
            #endregion
            #region State Interpolate To
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (Slotmachine.GumRuntimes.GameScreenGumRuntime.VariableState fromState,Slotmachine.GumRuntimes.GameScreenGumRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
            {
                FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from:0, to:1, duration:(float)secondsToTake, type:interpolationType, easing:easing );
                if (owner == null)
                {
                    tweener.Owner = this;
                }
                else
                {
                    tweener.Owner = owner;
                }
                tweener.PositionChanged = newPosition => this.InterpolateBetween(fromState, toState, newPosition);
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
            {
                Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
                Gum.DataTypes.Variables.StateSave toAsStateSave = this.ElementSave.States.First(item => item.Name == toState.ToString());
                FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from: 0, to: 1, duration: (float)secondsToTake, type: interpolationType, easing: easing);
                if (owner == null)
                {
                    tweener.Owner = this;
                }
                else
                {
                    tweener.Owner = owner;
                }
                tweener.PositionChanged = newPosition => this.InterpolateBetween(current, toAsStateSave, newPosition);
                tweener.Ended += ()=> this.CurrentVariableState = toState;
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateToRelative (VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
            {
                Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
                Gum.DataTypes.Variables.StateSave toAsStateSave = AddToCurrentValuesWithState(toState);
                FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from: 0, to: 1, duration: (float)secondsToTake, type: interpolationType, easing: easing);
                if (owner == null)
                {
                    tweener.Owner = this;
                }
                else
                {
                    tweener.Owner = owner;
                }
                tweener.PositionChanged = newPosition => this.InterpolateBetween(current, toAsStateSave, newPosition);
                tweener.Ended += ()=> this.CurrentVariableState = toState;
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            #endregion
            #region State Animations
            #endregion
            public override void StopAnimations () 
            {
                base.StopAnimations();
                ButtonInstance.StopAnimations();
            }
            public override FlatRedBall.Gum.Animation.GumAnimation GetAnimation (string animationName) 
            {
                return base.GetAnimation(animationName);
            }
            #region Get Current Values on State
            private Gum.DataTypes.Variables.StateSave GetCurrentValuesOnState (VariableState state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  VariableState.Default:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonInstance.Height",
                            Type = "float",
                            Value = ButtonInstance.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonInstance.Text",
                            Type = "string",
                            Value = ButtonInstance.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonInstance.Width",
                            Type = "float",
                            Value = ButtonInstance.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonInstance.X",
                            Type = "float",
                            Value = ButtonInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonInstance.Y",
                            Type = "float",
                            Value = ButtonInstance.Y
                        }
                        );
                        break;
                    case  VariableState.Click:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonInstance.Rotation",
                            Type = "float",
                            Value = ButtonInstance.Rotation
                        }
                        );
                        break;
                }
                return newState;
            }
            private Gum.DataTypes.Variables.StateSave AddToCurrentValuesWithState (VariableState state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  VariableState.Default:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonInstance.Height",
                            Type = "float",
                            Value = ButtonInstance.Height + 28f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonInstance.Text",
                            Type = "string",
                            Value = ButtonInstance.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonInstance.Width",
                            Type = "float",
                            Value = ButtonInstance.Width + 131f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonInstance.X",
                            Type = "float",
                            Value = ButtonInstance.X + 33f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonInstance.Y",
                            Type = "float",
                            Value = ButtonInstance.Y + 66f
                        }
                        );
                        break;
                    case  VariableState.Click:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonInstance.Rotation",
                            Type = "float",
                            Value = ButtonInstance.Rotation + 2f
                        }
                        );
                        break;
                }
                return newState;
            }
            #endregion
            public override void ApplyState (Gum.DataTypes.Variables.StateSave state) 
            {
                bool matches = this.ElementSave.AllStates.Contains(state);
                if (matches)
                {
                    var category = this.ElementSave.Categories.FirstOrDefault(item => item.States.Contains(state));
                    if (category == null)
                    {
                        if (state.Name == "Default") this.mCurrentVariableState = VariableState.Default;
                        if (state.Name == "Click") this.mCurrentVariableState = VariableState.Click;
                    }
                }
                base.ApplyState(state);
            }
            private bool tryCreateFormsObject;
            public Slotmachine.GumRuntimes.DefaultForms.ButtonRuntime ButtonInstance { get; set; }
            public GameScreenGumRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            {
                this.tryCreateFormsObject = tryCreateFormsObject;
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Screens.First(item => item.Name == "GameScreenGum");
                    this.ElementSave = elementSave;
                    string oldDirectory = FlatRedBall.IO.FileManager.RelativeDirectory;
                    FlatRedBall.IO.FileManager.RelativeDirectory = FlatRedBall.IO.FileManager.GetDirectory(Gum.Managers.ObjectFinder.Self.GumProjectSave.FullFileName);
                    GumRuntime.ElementSaveExtensions.SetGraphicalUiElement(elementSave, this, RenderingLibrary.SystemManagers.Default);
                    FlatRedBall.IO.FileManager.RelativeDirectory = oldDirectory;
                }
            }
            public override void SetInitialState () 
            {
                base.SetInitialState();
                this.CurrentVariableState = VariableState.Default;
                CallCustomInitialize();
            }
            public override void CreateChildrenRecursively (Gum.DataTypes.ElementSave elementSave, RenderingLibrary.SystemManagers systemManagers) 
            {
                base.CreateChildrenRecursively(elementSave, systemManagers);
                this.AssignReferences();
            }
            private void AssignReferences () 
            {
                ButtonInstance = this.GetGraphicalUiElementByName("ButtonInstance") as Slotmachine.GumRuntimes.DefaultForms.ButtonRuntime;
                if (tryCreateFormsObject)
                {
                    FormsControlAsObject = new Slotmachine.FormsControls.Screens.GameScreenGumForms(this);
                }
            }
            public override void AddToManagers (RenderingLibrary.SystemManagers managers, RenderingLibrary.Graphics.Layer layer) 
            {
                base.AddToManagers(managers, layer);
            }
            private void CallCustomInitialize () 
            {
                CustomInitialize();
            }
            partial void CustomInitialize();
            public Slotmachine.FormsControls.Screens.GameScreenGumForms FormsControl {get => (Slotmachine.FormsControls.Screens.GameScreenGumForms) FormsControlAsObject;}
        }
    }
