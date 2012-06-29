using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWP7Updater.Helper
{
    public static class ErrorHandling
    {
        public static void HandleError(Exception ex)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
#else
            Forms.ErrorForm error = new Forms.ErrorForm(ex);
            error.Show();
#endif
        }
    }
}
