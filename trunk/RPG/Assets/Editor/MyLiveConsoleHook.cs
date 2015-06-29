using CielaSpike.Unity.LiveConsole;
using UnityEngine;

[assembly: LiveConsoleHook(typeof(RPG.Editor.MyLiveConsoleHook))]
namespace RPG.Editor
{
	class MyLiveConsoleHook : LiveConsoleHook
    {
        protected override bool IsEnabled()
        {
            // >>>>> Change to true to enable this hook! <<<<<
            return true;
        }

//        protected override HookResult OnColoringLogEntry(EntryInfo entry, out Color color)
//        {
//            color = default(Color);
//
//            // make even row green
//            if (entry.RowNumber % 2 == 0)
//            {
//                color = Color.green;
//
//                // notify color is hooked.
//                return HookResult.Hooked;
//            }
//
//            // use default behaviour;
//            return HookResult.Default;
//        }

//        protected override HookResult OnTaggingLogEntry(EntryInfo entry, out string tag, out TagColor tagColor)
//        {
//			tag = null;
//            tagColor = TagColor.Cyan;
//
//			// tag even odd row orange and change tag text.
//            if (entry.RowNumber % 2 == 1)
//            {
//                tag = "Odd!";
//                tagColor = TagColor.Orange;
//
//                return HookResult.Hooked;
//            }
//
//            return HookResult.Default;
//        }

//        protected override HookResult OnDrawLogEntry(EntryInfo entry)
//        {
//            return HookResult.Default;
//        }

        protected override HookResult OnOpenExternalEditor(EntryInfo entry)
        {
//            if (Application.platform == RuntimePlatform.WindowsEditor)
//            {
//				UnityEditor.EditorUtility.OpenWithDefaultApp( entry.FileName );
//			}
//            else if (Application.platform == RuntimePlatform.OSXEditor)
//            {
//				UnityEditor.EditorUtility.OpenWithDefaultApp( entry.FileName );
//            }
//            else
//            {
//                return HookResult.Default;
//            }
//
            return HookResult.Hooked;
        }
    }
}
