//BP
namespace System.Windows.Forms
{
    public class NativeWindowStub
    {
        [ThreadStatic]
        private static bool? t_wndProcShouldBeDebuggable = null;

        internal static bool WndProcShouldBeDebuggable
        {
            get
            {
                if (!t_wndProcShouldBeDebuggable.HasValue)
                {
                    var assembly = typeof(System.Windows.Forms.NativeWindow).Assembly;
                    var type = assembly.GetType("System.Windows.Forms.NativeWindow");
                    var staticMethodInfo = type.GetProperty("WndProcShouldBeDebuggable", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
                    t_wndProcShouldBeDebuggable = (bool)staticMethodInfo.GetValue(null, null);
                }
                return t_wndProcShouldBeDebuggable.Value;
            }
        }
    }
}
