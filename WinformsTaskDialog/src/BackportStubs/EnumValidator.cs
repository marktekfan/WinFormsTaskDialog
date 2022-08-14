using System.ComponentModel;
using System.Windows.Forms;

//BP
namespace SourceGenerated
{
    internal static partial class EnumValidator
    {
        public static void Validate(TaskDialogExpanderPosition value)
        {
            if (!ClientUtils.IsEnumValid(
                    value,
                    (int)value,
                    (int)TaskDialogExpanderPosition.AfterText,
                    (int)TaskDialogExpanderPosition.AfterFootnote))
            {
                throw new InvalidEnumArgumentException(
                    nameof(value),
                    (int)value,
                    typeof(TaskDialogExpanderPosition));
            }
        }

        public static void Validate(TaskDialogProgressBarState value)
        {
            if (!ClientUtils.IsEnumValid(
                value,
                (int)value,
                (int)TaskDialogProgressBarState.Normal,
                (int)TaskDialogProgressBarState.None))
            {
                throw new InvalidEnumArgumentException(
                    nameof(value),
                    (int)value,
                    typeof(TaskDialogProgressBarState));
            }
        }
    }
}
