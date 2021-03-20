#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall.Graphics;
using FlatRedBall.Math;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
namespace Slotmachine.Entities
{
    public partial class Slot1 : FlatRedBall.PositionedObject, FlatRedBall.Graphics.IDestroyable
    {
        // This is made static so that static lazy-loaded content can access it.
        public static string ContentManagerName { get; set; }
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        public class VariableState
        {
            public string Name;
            public static VariableState abariguessshowing = new VariableState()
            {
                Name = "abariguessshowing",
            }
            ;
            public static VariableState adiamondshowing = new VariableState()
            {
                Name = "adiamondshowing",
            }
            ;
            public static VariableState FRB_iconshowing = new VariableState()
            {
                Name = "FRB_iconshowing",
            }
            ;
            public static VariableState somethingshowing = new VariableState()
            {
                Name = "somethingshowing",
            }
            ;
            public static VariableState Veilstone_Corner_Moon_StoneShowing = new VariableState()
            {
                Name = "Veilstone_Corner_Moon_StoneShowing",
            }
            ;
            public static VariableState ROLLING = new VariableState()
            {
                Name = "ROLLING",
            }
            ;
            public static Dictionary<string, VariableState> AllStates = new Dictionary<string, VariableState>
            {
                {"abariguessshowing", abariguessshowing},
                {"adiamondshowing", adiamondshowing},
                {"FRB_iconshowing", FRB_iconshowing},
                {"somethingshowing", somethingshowing},
                {"Veilstone_Corner_Moon_StoneShowing", Veilstone_Corner_Moon_StoneShowing},
                {"ROLLING", ROLLING},
            }
            ;
        }
        private VariableState mCurrentState = null;
        public Entities.Slot1.VariableState CurrentState
        {
            get
            {
                return mCurrentState;
            }
            set
            {
                mCurrentState = value;
                if (CurrentState == VariableState.abariguessshowing)
                {
                    SpriteInstanceTexture = Bariguess;
                }
                else if (CurrentState == VariableState.adiamondshowing)
                {
                    SpriteInstanceTexture = adiamond;
                }
                else if (CurrentState == VariableState.FRB_iconshowing)
                {
                    SpriteInstanceTexture = adiamond;
                }
                else if (CurrentState == VariableState.somethingshowing)
                {
                    SpriteInstanceTexture = something;
                }
                else if (CurrentState == VariableState.Veilstone_Corner_Moon_StoneShowing)
                {
                    SpriteInstanceTexture = Veilstone_Corner_Moon_Stone;
                }
                else if (CurrentState == VariableState.ROLLING)
                {
                    SpriteInstanceTexture = null;
                    SpriteInstanceAnimationChains = RollingSlotsforall;
                    SpriteInstanceCurrentChainName = "RollingSlots";
                }
            }
        }
        static object mLockObject = new object();
        static System.Collections.Generic.List<string> mRegisteredUnloads = new System.Collections.Generic.List<string>();
        static System.Collections.Generic.List<string> LoadedContentManagers = new System.Collections.Generic.List<string>();
        protected static Microsoft.Xna.Framework.Graphics.Texture2D FRB_icon;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D Veilstone_Corner_Moon_Stone;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D something;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D Bariguess;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D adiamond;
        protected static FlatRedBall.Graphics.Animation.AnimationChainList RollingSlotsforall;
        
        private FlatRedBall.Sprite SpriteInstance;
        public Microsoft.Xna.Framework.Graphics.Texture2D SpriteInstanceTexture
        {
            get
            {
                return SpriteInstance.Texture;
            }
            set
            {
                SpriteInstance.Texture = value;
            }
        }
        public FlatRedBall.Graphics.Animation.AnimationChainList SpriteInstanceAnimationChains
        {
            get
            {
                return SpriteInstance.AnimationChains;
            }
            set
            {
                SpriteInstance.AnimationChains = value;
            }
        }
        public string SpriteInstanceCurrentChainName
        {
            get
            {
                return SpriteInstance.CurrentChainName;
            }
            set
            {
                SpriteInstance.CurrentChainName = value;
            }
        }
        protected FlatRedBall.Graphics.Layer LayerProvidedByContainer = null;
        public Slot1 () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public Slot1 (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public Slot1 (string contentManagerName, bool addToManagers) 
        	: base()
        {
            ContentManagerName = contentManagerName;
            InitializeEntity(addToManagers);
        }
        protected virtual void InitializeEntity (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            SpriteInstance = new FlatRedBall.Sprite();
            SpriteInstance.Name = "SpriteInstance";
            
            PostInitialize();
            if (addToManagers)
            {
                AddToManagers(null);
            }
        }
        public virtual void ReAddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
        }
        public virtual void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            AddToManagersBottomUp(layerToAddTo);
            CustomInitialize();
        }
        public virtual void Activity () 
        {
            
            CustomActivity();
        }
        public virtual void Destroy () 
        {
            FlatRedBall.SpriteManager.RemovePositionedObject(this);
            
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSprite(SpriteInstance);
            }
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.CopyAbsoluteToRelative();
                SpriteInstance.AttachTo(this, false);
            }
            SpriteInstance.Texture = FRB_icon;
            SpriteInstance.Width = 50f;
            SpriteInstance.Height = 50f;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(SpriteInstance);
            }
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
            SpriteInstance.Texture = FRB_icon;
            SpriteInstance.Width = 50f;
            SpriteInstance.Height = 50f;
            SpriteInstanceTexture = FRB_icon;
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            this.ForceUpdateDependenciesDeep();
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(SpriteInstance);
        }
        public static void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            ContentManagerName = contentManagerName;
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
            bool registerUnload = false;
            if (LoadedContentManagers.Contains(contentManagerName) == false)
            {
                LoadedContentManagers.Add(contentManagerName);
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("Slot1StaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/slot1/frb_icon.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                FRB_icon = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/slot1/frb_icon.png", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/slot1/veilstone_corner_moon_stone.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                Veilstone_Corner_Moon_Stone = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/slot1/veilstone_corner_moon_stone.png", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/slot1/something.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                something = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/slot1/something.png", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/slot1/bariguess.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                Bariguess = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/slot1/bariguess.png", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/slot1/adiamond.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                adiamond = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/slot1/adiamond.png", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/entities/slot1/rollingslotsforall.achx", ContentManagerName))
                {
                    registerUnload = true;
                }
                RollingSlotsforall = FlatRedBall.FlatRedBallServices.Load<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/entities/slot1/rollingslotsforall.achx", ContentManagerName);
            }
            if (registerUnload && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("Slot1StaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
            }
            CustomLoadStaticContent(contentManagerName);
        }
        public static void UnloadStaticContent () 
        {
            if (LoadedContentManagers.Count != 0)
            {
                LoadedContentManagers.RemoveAt(0);
                mRegisteredUnloads.RemoveAt(0);
            }
            if (LoadedContentManagers.Count == 0)
            {
                if (FRB_icon != null)
                {
                    FRB_icon= null;
                }
                if (Veilstone_Corner_Moon_Stone != null)
                {
                    Veilstone_Corner_Moon_Stone= null;
                }
                if (something != null)
                {
                    something= null;
                }
                if (Bariguess != null)
                {
                    Bariguess= null;
                }
                if (adiamond != null)
                {
                    adiamond= null;
                }
                if (RollingSlotsforall != null)
                {
                    RollingSlotsforall= null;
                }
            }
        }
        static VariableState mLoadingState = null;
        public static VariableState LoadingState
        {
            get
            {
                return mLoadingState;
            }
            set
            {
                mLoadingState = value;
            }
        }
        public FlatRedBall.Instructions.Instruction InterpolateToState (VariableState stateToInterpolateTo, double secondsToTake) 
        {
            if (stateToInterpolateTo == VariableState.abariguessshowing)
            {
            }
            else if (stateToInterpolateTo == VariableState.adiamondshowing)
            {
            }
            else if (stateToInterpolateTo == VariableState.FRB_iconshowing)
            {
            }
            else if (stateToInterpolateTo == VariableState.somethingshowing)
            {
            }
            else if (stateToInterpolateTo == VariableState.Veilstone_Corner_Moon_StoneShowing)
            {
            }
            else if (stateToInterpolateTo == VariableState.ROLLING)
            {
            }
            var instruction = new FlatRedBall.Instructions.DelegateInstruction<VariableState>(StopStateInterpolation, stateToInterpolateTo);
            instruction.TimeToExecute = FlatRedBall.TimeManager.CurrentTime + secondsToTake;
            this.Instructions.Add(instruction);
            return instruction;
        }
        public void StopStateInterpolation (VariableState stateToStop) 
        {
            if (stateToStop == VariableState.abariguessshowing)
            {
            }
            else if (stateToStop == VariableState.adiamondshowing)
            {
            }
            else if (stateToStop == VariableState.FRB_iconshowing)
            {
            }
            else if (stateToStop == VariableState.somethingshowing)
            {
            }
            else if (stateToStop == VariableState.Veilstone_Corner_Moon_StoneShowing)
            {
            }
            else if (stateToStop == VariableState.ROLLING)
            {
            }
            CurrentState = stateToStop;
        }
        public void InterpolateBetween (VariableState firstState, VariableState secondState, float interpolationValue) 
        {
            #if DEBUG
            if (float.IsNaN(interpolationValue))
            {
                throw new System.Exception("interpolationValue cannot be NaN");
            }
            #endif
            if (firstState == VariableState.abariguessshowing)
            {
                if (interpolationValue < 1)
                {
                    this.SpriteInstanceTexture = Bariguess;
                }
            }
            else if (firstState == VariableState.adiamondshowing)
            {
                if (interpolationValue < 1)
                {
                    this.SpriteInstanceTexture = adiamond;
                }
            }
            else if (firstState == VariableState.FRB_iconshowing)
            {
                if (interpolationValue < 1)
                {
                    this.SpriteInstanceTexture = adiamond;
                }
            }
            else if (firstState == VariableState.somethingshowing)
            {
                if (interpolationValue < 1)
                {
                    this.SpriteInstanceTexture = something;
                }
            }
            else if (firstState == VariableState.Veilstone_Corner_Moon_StoneShowing)
            {
                if (interpolationValue < 1)
                {
                    this.SpriteInstanceTexture = Veilstone_Corner_Moon_Stone;
                }
            }
            else if (firstState == VariableState.ROLLING)
            {
                if (interpolationValue < 1)
                {
                    this.SpriteInstanceTexture = null;
                }
                if (interpolationValue < 1)
                {
                    this.SpriteInstanceAnimationChains = RollingSlotsforall;
                }
                if (interpolationValue < 1)
                {
                    this.SpriteInstanceCurrentChainName = "RollingSlots";
                }
            }
            if (secondState == VariableState.abariguessshowing)
            {
                if (interpolationValue >= 1)
                {
                    this.SpriteInstanceTexture = Bariguess;
                }
            }
            else if (secondState == VariableState.adiamondshowing)
            {
                if (interpolationValue >= 1)
                {
                    this.SpriteInstanceTexture = adiamond;
                }
            }
            else if (secondState == VariableState.FRB_iconshowing)
            {
                if (interpolationValue >= 1)
                {
                    this.SpriteInstanceTexture = adiamond;
                }
            }
            else if (secondState == VariableState.somethingshowing)
            {
                if (interpolationValue >= 1)
                {
                    this.SpriteInstanceTexture = something;
                }
            }
            else if (secondState == VariableState.Veilstone_Corner_Moon_StoneShowing)
            {
                if (interpolationValue >= 1)
                {
                    this.SpriteInstanceTexture = Veilstone_Corner_Moon_Stone;
                }
            }
            else if (secondState == VariableState.ROLLING)
            {
                if (interpolationValue >= 1)
                {
                    this.SpriteInstanceTexture = null;
                }
                if (interpolationValue >= 1)
                {
                    this.SpriteInstanceAnimationChains = RollingSlotsforall;
                }
                if (interpolationValue >= 1)
                {
                    this.SpriteInstanceCurrentChainName = "RollingSlots";
                }
            }
            if (interpolationValue < 1)
            {
                mCurrentState = firstState;
            }
            else
            {
                mCurrentState = secondState;
            }
        }
        public static void PreloadStateContent (VariableState state, string contentManagerName) 
        {
            ContentManagerName = contentManagerName;
            if (state == VariableState.abariguessshowing)
            {
                {
                    object throwaway = Bariguess;
                }
            }
            else if (state == VariableState.adiamondshowing)
            {
                {
                    object throwaway = adiamond;
                }
            }
            else if (state == VariableState.FRB_iconshowing)
            {
                {
                    object throwaway = adiamond;
                }
            }
            else if (state == VariableState.somethingshowing)
            {
                {
                    object throwaway = something;
                }
            }
            else if (state == VariableState.Veilstone_Corner_Moon_StoneShowing)
            {
                {
                    object throwaway = Veilstone_Corner_Moon_Stone;
                }
            }
            else if (state == VariableState.ROLLING)
            {
                {
                    object throwaway = null;
                }
                {
                    object throwaway = RollingSlotsforall;
                }
                {
                    object throwaway = "RollingSlots";
                }
            }
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "FRB_icon":
                    return FRB_icon;
                case  "Veilstone_Corner_Moon_Stone":
                    return Veilstone_Corner_Moon_Stone;
                case  "something":
                    return something;
                case  "Bariguess":
                    return Bariguess;
                case  "adiamond":
                    return adiamond;
                case  "RollingSlotsforall":
                    return RollingSlotsforall;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "FRB_icon":
                    return FRB_icon;
                case  "Veilstone_Corner_Moon_Stone":
                    return Veilstone_Corner_Moon_Stone;
                case  "something":
                    return something;
                case  "Bariguess":
                    return Bariguess;
                case  "adiamond":
                    return adiamond;
                case  "RollingSlotsforall":
                    return RollingSlotsforall;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "FRB_icon":
                    return FRB_icon;
                case  "Veilstone_Corner_Moon_Stone":
                    return Veilstone_Corner_Moon_Stone;
                case  "something":
                    return something;
                case  "Bariguess":
                    return Bariguess;
                case  "adiamond":
                    return adiamond;
                case  "RollingSlotsforall":
                    return RollingSlotsforall;
            }
            return null;
        }
        protected bool mIsPaused;
        public override void Pause (FlatRedBall.Instructions.InstructionList instructions) 
        {
            base.Pause(instructions);
            mIsPaused = true;
        }
        public virtual void SetToIgnorePausing () 
        {
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(this);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(SpriteInstance);
        }
        public virtual void MoveToLayer (FlatRedBall.Graphics.Layer layerToMoveTo) 
        {
            var layerToRemoveFrom = LayerProvidedByContainer;
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(SpriteInstance);
            }
            if (layerToMoveTo != null || !SpriteManager.AutomaticallyUpdatedSprites.Contains(SpriteInstance))
            {
                FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, layerToMoveTo);
            }
            LayerProvidedByContainer = layerToMoveTo;
        }
    }
}
