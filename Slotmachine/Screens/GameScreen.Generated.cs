#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
namespace Slotmachine.Screens
{
    public partial class GameScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static Slotmachine.GumRuntimes.GameScreenGumRuntime GameScreenGum;
        
        private Slotmachine.Entities.Slot1 Slot1Instance;
        private Slotmachine.Entities.Slot2 Slot2Instance;
        private Slotmachine.Entities.Slot3 Slot3Instance;
        Slotmachine.FormsControls.Screens.GameScreenGumForms Forms;
        public GameScreen () 
        	: base ("GameScreen")
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            Slot1Instance = new Slotmachine.Entities.Slot1(ContentManagerName, false);
            Slot1Instance.Name = "Slot1Instance";
            Slot2Instance = new Slotmachine.Entities.Slot2(ContentManagerName, false);
            Slot2Instance.Name = "Slot2Instance";
            Slot3Instance = new Slotmachine.Entities.Slot3(ContentManagerName, false);
            Slot3Instance.Name = "Slot3Instance";
            Forms = new Slotmachine.FormsControls.Screens.GameScreenGumForms(GameScreenGum);
            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            GameScreenGum.AddToManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += RefreshLayoutInternal;
            Slot1Instance.AddToManagers(mLayer);
            Slot2Instance.AddToManagers(mLayer);
            Slot3Instance.AddToManagers(mLayer);
            base.AddToManagers();
            AddToManagersBottomUp();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                Slot1Instance.Activity();
                Slot2Instance.Activity();
                Slot3Instance.Activity();
            }
            else
            {
            }
            base.Activity(firstTimeCalled);
            if (!IsActivityFinished)
            {
                CustomActivity(firstTimeCalled);
            }
        }
        public override void Destroy () 
        {
            base.Destroy();
            GameScreenGum.RemoveFromManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged -= RefreshLayoutInternal;
            GameScreenGum = null;
            
            if (Slot1Instance != null)
            {
                Slot1Instance.Destroy();
                Slot1Instance.Detach();
            }
            if (Slot2Instance != null)
            {
                Slot2Instance.Destroy();
                Slot2Instance.Detach();
            }
            if (Slot3Instance != null)
            {
                Slot3Instance.Destroy();
                Slot3Instance.Detach();
            }
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (Slot1Instance.Parent == null)
            {
                Slot1Instance.X = -75f;
            }
            else
            {
                Slot1Instance.RelativeX = -75f;
            }
            if (Slot1Instance.Parent == null)
            {
                Slot1Instance.Y = 25f;
            }
            else
            {
                Slot1Instance.RelativeY = 25f;
            }
            if (Slot2Instance.Parent == null)
            {
                Slot2Instance.X = 0f;
            }
            else
            {
                Slot2Instance.RelativeX = 0f;
            }
            if (Slot2Instance.Parent == null)
            {
                Slot2Instance.Y = 25f;
            }
            else
            {
                Slot2Instance.RelativeY = 25f;
            }
            if (Slot3Instance.Parent == null)
            {
                Slot3Instance.X = 75f;
            }
            else
            {
                Slot3Instance.RelativeX = 75f;
            }
            if (Slot3Instance.Parent == null)
            {
                Slot3Instance.Y = 25f;
            }
            else
            {
                Slot3Instance.RelativeY = 25f;
            }
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp () 
        {
            CameraSetup.ResetCamera(SpriteManager.Camera);
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            GameScreenGum.RemoveFromManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged -= RefreshLayoutInternal;
            Slot1Instance.RemoveFromManagers();
            Slot2Instance.RemoveFromManagers();
            Slot3Instance.RemoveFromManagers();
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
                Slot1Instance.AssignCustomVariables(true);
                Slot2Instance.AssignCustomVariables(true);
                Slot3Instance.AssignCustomVariables(true);
            }
            if (Slot1Instance.Parent == null)
            {
                Slot1Instance.X = -75f;
            }
            else
            {
                Slot1Instance.RelativeX = -75f;
            }
            if (Slot1Instance.Parent == null)
            {
                Slot1Instance.Y = 25f;
            }
            else
            {
                Slot1Instance.RelativeY = 25f;
            }
            if (Slot2Instance.Parent == null)
            {
                Slot2Instance.X = 0f;
            }
            else
            {
                Slot2Instance.RelativeX = 0f;
            }
            if (Slot2Instance.Parent == null)
            {
                Slot2Instance.Y = 25f;
            }
            else
            {
                Slot2Instance.RelativeY = 25f;
            }
            if (Slot3Instance.Parent == null)
            {
                Slot3Instance.X = 75f;
            }
            else
            {
                Slot3Instance.RelativeX = 75f;
            }
            if (Slot3Instance.Parent == null)
            {
                Slot3Instance.Y = 25f;
            }
            else
            {
                Slot3Instance.RelativeY = 25f;
            }
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            Slot1Instance.ConvertToManuallyUpdated();
            Slot2Instance.ConvertToManuallyUpdated();
            Slot3Instance.ConvertToManuallyUpdated();
        }
        public static void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            // Set the content manager for Gum
            var contentManagerWrapper = new FlatRedBall.Gum.ContentManagerWrapper();
            contentManagerWrapper.ContentManagerName = contentManagerName;
            RenderingLibrary.Content.LoaderManager.Self.ContentLoader = contentManagerWrapper;
            // Access the GumProject just in case it's async loaded
            var throwaway = GlobalContent.GumProject;
            #if DEBUG
            if (contentManagerName == FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                HasBeenLoadedWithGlobalContentManager = true;
            }
            else if (HasBeenLoadedWithGlobalContentManager)
            {
                throw new System.Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
            }
            #endif
            if(GameScreenGum == null) GameScreenGum = (Slotmachine.GumRuntimes.GameScreenGumRuntime)GumRuntime.ElementSaveExtensions.CreateGueForElement(Gum.Managers.ObjectFinder.Self.GetScreen("GameScreenGum"), true);
            Slotmachine.Entities.Slot1.LoadStaticContent(contentManagerName);
            Slotmachine.Entities.Slot2.LoadStaticContent(contentManagerName);
            Slotmachine.Entities.Slot3.LoadStaticContent(contentManagerName);
            CustomLoadStaticContent(contentManagerName);
        }
        public override void PauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Pause();
            base.PauseThisScreen();
        }
        public override void UnpauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Unpause();
            base.UnpauseThisScreen();
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "GameScreenGum":
                    return GameScreenGum;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "GameScreenGum":
                    return GameScreenGum;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "GameScreenGum":
                    return GameScreenGum;
            }
            return null;
        }
        private void RefreshLayoutInternal (object sender, EventArgs e) 
        {
            GameScreenGum.UpdateLayout();
        }
    }
}
