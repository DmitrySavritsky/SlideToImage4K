using System;

namespace Slide_to_Image_4K
{
    public static class Utils
    {
        public static string GetPathToDesktop()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }
    }
}
