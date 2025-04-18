using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Avalonia.Win32.Automation.Interop
{
    [Guid("d8e55844-7043-4edc-979d-593cc6b4775e")]
    internal enum AsyncContentLoadedState
    {
        Beginning,
        Progress,
        Completed,
    }

    [Guid("e4cfef41-071d-472c-a65c-c14f59ea81eb")]
    internal enum StructureChangeType
    {
        ChildAdded,
        ChildRemoved,
        ChildrenInvalidated,
        ChildrenBulkAdded,
        ChildrenBulkRemoved,
        ChildrenReordered,
    }

    internal enum UiaEventId
    {
        ToolTipOpened = 20000,
        ToolTipClosed,
        StructureChanged,
        MenuOpened,
        AutomationPropertyChanged,
        AutomationFocusChanged,
        AsyncContentLoaded,
        MenuClosed,
        LayoutInvalidated,
        Invoke_Invoked,
        SelectionItem_ElementAddedToSelection,
        SelectionItem_ElementRemovedFromSelection,
        SelectionItem_ElementSelected,
        Selection_Invalidated,
        Text_TextSelectionChanged,
        Text_TextChanged,
        Window_WindowOpened,
        Window_WindowClosed,
        MenuModeStart,
        MenuModeEnd,
        InputReachedTarget,
        InputReachedOtherElement,
        InputDiscarded,
        SystemAlert,
        LiveRegionChanged,
        HostedFragmentRootsInvalidated,
        Drag_DragStart,
        Drag_DragCancel,
        Drag_DragComplete,
        DropTarget_DragEnter,
        DropTarget_DragLeave,
        DropTarget_Dropped,
        TextEdit_TextChanged,
        TextEdit_ConversionTargetChanged,
        Changes
    };

    internal static partial class UiaCoreProviderApi
    {
        public const int UIA_E_ELEMENTNOTENABLED = unchecked((int)0x80040200);

#if NET7_0_OR_GREATER
        [LibraryImport("UIAutomationCore.dll", StringMarshalling = StringMarshalling.Utf8)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool UiaClientsAreListening();
        
        [LibraryImport("UIAutomationCore.dll", StringMarshalling = StringMarshalling.Utf8)]
        public static partial IntPtr UiaReturnRawElementProvider(IntPtr hwnd, IntPtr wParam, IntPtr lParam, IRawElementProviderSimple? el);

        [LibraryImport("UIAutomationCore.dll", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int UiaHostProviderFromHwnd(IntPtr hwnd, [MarshalAs(UnmanagedType.Interface)] out IRawElementProviderSimple provider);

        [LibraryImport("UIAutomationCore.dll", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int UiaRaiseAutomationEvent(IRawElementProviderSimple? provider, int id);

        [LibraryImport("UIAutomationCore.dll", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int UiaRaiseAutomationPropertyChangedEvent(IRawElementProviderSimple? provider, int id, [MarshalUsing(typeof(ComVariantMarshaller))] object? oldValue, [MarshalUsing(typeof(ComVariantMarshaller))] object? newValue);

        [LibraryImport("UIAutomationCore.dll", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int UiaRaiseStructureChangedEvent(IRawElementProviderSimple? provider, StructureChangeType structureChangeType, int[]? runtimeId, int runtimeIdLen);

        [LibraryImport("UIAutomationCore.dll", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int UiaDisconnectProvider(IRawElementProviderSimple? provider);
#else
        [DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
        public static extern bool UiaClientsAreListening();

        [DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr UiaReturnRawElementProvider(IntPtr hwnd, IntPtr wParam, IntPtr lParam,
            IRawElementProviderSimple? el);

        [DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
        public static extern int UiaHostProviderFromHwnd(IntPtr hwnd,
            [MarshalAs(UnmanagedType.Interface)] out IRawElementProviderSimple provider);

        [DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
        public static extern int UiaRaiseAutomationEvent(IRawElementProviderSimple? provider, int id);

        [DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
        public static extern int UiaRaiseAutomationPropertyChangedEvent(IRawElementProviderSimple? provider, int id,
            object? oldValue, object? newValue);

        [DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
        public static extern int UiaRaiseStructureChangedEvent(IRawElementProviderSimple? provider,
            StructureChangeType structureChangeType, int[]? runtimeId, int runtimeIdLen);

        [DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
        public static extern int UiaDisconnectProvider(IRawElementProviderSimple? provider);
#endif
    }
}
