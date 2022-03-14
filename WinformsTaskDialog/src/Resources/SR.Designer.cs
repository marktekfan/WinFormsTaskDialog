﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinformsTaskDialog.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SR {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SR() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("System.Windows.Forms.src.Resources.SR", typeof(SR).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cross-thread operation not valid: Control &apos;{0}&apos; accessed from a thread other than the thread it was created on..
        /// </summary>
        internal static string IllegalCrossThreadCall {
            get {
                return ResourceManager.GetString("IllegalCrossThreadCall", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The text of a custom button must not be null or an empty string..
        /// </summary>
        internal static string TaskDialogButtonTextMustNotBeNull {
            get {
                return ResourceManager.GetString("TaskDialogButtonTextMustNotBeNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot navigate the dialog when it has already closed..
        /// </summary>
        internal static string TaskDialogCannotNavigateClosedDialog {
            get {
                return ResourceManager.GetString("TaskDialogCannotNavigateClosedDialog", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot navigate the dialog from an event handler that is called from within navigation..
        /// </summary>
        internal static string TaskDialogCannotNavigateWithinNavigationEventHandler {
            get {
                return ResourceManager.GetString("TaskDialogCannotNavigateWithinNavigationEventHandler", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot navigate the dialog from within the {0} event of one of the radio buttons of the current task dialog..
        /// </summary>
        internal static string TaskDialogCannotNavigateWithinRadioButtonCheckedChanged {
            get {
                return ResourceManager.GetString("TaskDialogCannotNavigateWithinRadioButtonCheckedChanged", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot navigate from a page not bound to a dialog..
        /// </summary>
        internal static string TaskDialogCannotNavigateWithoutDialog {
            get {
                return ResourceManager.GetString("TaskDialogCannotNavigateWithoutDialog", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot remove the progress bar while the task dialog is shown..
        /// </summary>
        internal static string TaskDialogCannotRemoveProgressBarWhileDialogIsShown {
            get {
                return ResourceManager.GetString("TaskDialogCannotRemoveProgressBarWhileDialogIsShown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot set this property or call this method while the page is bound to a task dialog..
        /// </summary>
        internal static string TaskDialogCannotSetPropertyOfBoundPage {
            get {
                return ResourceManager.GetString("TaskDialogCannotSetPropertyOfBoundPage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot set this property while the task dialog is shown..
        /// </summary>
        internal static string TaskDialogCannotSetPropertyOfShownDialog {
            get {
                return ResourceManager.GetString("TaskDialogCannotSetPropertyOfShownDialog", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot set the {0} property from within the {1} event of one of the radio buttons of the current task dialog..
        /// </summary>
        internal static string TaskDialogCannotSetRadioButtonCheckedWithinCheckedChangedEvent {
            get {
                return ResourceManager.GetString("TaskDialogCannotSetRadioButtonCheckedWithinCheckedChangedEvent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot set the text for a standard button..
        /// </summary>
        internal static string TaskDialogCannotSetTextForStandardButton {
            get {
                return ResourceManager.GetString("TaskDialogCannotSetTextForStandardButton", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot show both custom buttons and command links at the same time..
        /// </summary>
        internal static string TaskDialogCannotShowCustomButtonsAndCommandLinks {
            get {
                return ResourceManager.GetString("TaskDialogCannotShowCustomButtonsAndCommandLinks", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot uncheck a radio button while it is bound to a task dialog..
        /// </summary>
        internal static string TaskDialogCannotUncheckRadioButtonWhileBound {
            get {
                return ResourceManager.GetString("TaskDialogCannotUncheckRadioButtonWhileBound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot manipulate the task dialog immediately after navigating it. Please wait for the {0} event of the next page to occur..
        /// </summary>
        internal static string TaskDialogCannotUpdateAfterNavigation {
            get {
                return ResourceManager.GetString("TaskDialogCannotUpdateAfterNavigation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot update the icon from a handle icon type to a non-handle icon type, and vice versa..
        /// </summary>
        internal static string TaskDialogCannotUpdateIconType {
            get {
                return ResourceManager.GetString("TaskDialogCannotUpdateIconType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can only update the state of a task dialog while it is shown..
        /// </summary>
        internal static string TaskDialogCanUpdateStateOnlyWhenShown {
            get {
                return ResourceManager.GetString("TaskDialogCanUpdateStateOnlyWhenShown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One of the collections of this {0} is already bound to a {1} instance..
        /// </summary>
        internal static string TaskDialogCollectionAlreadyBound {
            get {
                return ResourceManager.GetString("TaskDialogCollectionAlreadyBound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This control has already been added to the collection..
        /// </summary>
        internal static string TaskDialogControlAlreadyAddedToCollection {
            get {
                return ResourceManager.GetString("TaskDialogControlAlreadyAddedToCollection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One of the controls of this {0} is already bound to a {1} instance..
        /// </summary>
        internal static string TaskDialogControlAlreadyBound {
            get {
                return ResourceManager.GetString("TaskDialogControlAlreadyBound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This control is already part of a different collection..
        /// </summary>
        internal static string TaskDialogControlIsPartOfOtherCollection {
            get {
                return ResourceManager.GetString("TaskDialogControlIsPartOfOtherCollection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This control is not currently bound to a task dialog..
        /// </summary>
        internal static string TaskDialogControlNotBound {
            get {
                return ResourceManager.GetString("TaskDialogControlNotBound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The control has not been created..
        /// </summary>
        internal static string TaskDialogControlNotCreated {
            get {
                return ResourceManager.GetString("TaskDialogControlNotCreated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The default button must exist in the buttons collection..
        /// </summary>
        internal static string TaskDialogDefaultButtonMustExistInCollection {
            get {
                return ResourceManager.GetString("TaskDialogDefaultButtonMustExistInCollection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This {0} instance is already being shown..
        /// </summary>
        internal static string TaskDialogInstanceAlreadyShown {
            get {
                return ResourceManager.GetString("TaskDialogInstanceAlreadyShown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Navigation of the task dialog did not complete yet. Please wait for the {0} event to occur..
        /// </summary>
        internal static string TaskDialogNavigationNotCompleted {
            get {
                return ResourceManager.GetString("TaskDialogNavigationNotCompleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only a single radio button can be set as checked..
        /// </summary>
        internal static string TaskDialogOnlySingleRadioButtonCanBeChecked {
            get {
                return ResourceManager.GetString("TaskDialogOnlySingleRadioButtonCanBeChecked", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This {0} instance is already bound to a {1} instance..
        /// </summary>
        internal static string TaskDialogPageIsAlreadyBound {
            get {
                return ResourceManager.GetString("TaskDialogPageIsAlreadyBound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The text of a radio button must not be null or an empty string..
        /// </summary>
        internal static string TaskDialogRadioButtonTextMustNotBeNull {
            get {
                return ResourceManager.GetString("TaskDialogRadioButtonTextMustNotBeNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Too many custom buttons or radio buttons have been added..
        /// </summary>
        internal static string TaskDialogTooManyButtonsAdded {
            get {
                return ResourceManager.GetString("TaskDialogTooManyButtonsAdded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Visual styles are not enabled. Please call {0} before showing the task dialog..
        /// </summary>
        internal static string TaskDialogVisualStylesNotEnabled {
            get {
                return ResourceManager.GetString("TaskDialogVisualStylesNotEnabled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The current window procedure is not the expected one..
        /// </summary>
        internal static string WindowSubclassHandlerWndProcIsNotExceptedOne {
            get {
                return ResourceManager.GetString("WindowSubclassHandlerWndProcIsNotExceptedOne", resourceCulture);
            }
        }
    }
}
