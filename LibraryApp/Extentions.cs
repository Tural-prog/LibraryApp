using LibraryApp.Common;

namespace LibraryApp
{
    public static class Extentions
    {
        public static int AsInt(this object obj)
        {
            var sub = obj as IdName;
            return sub.Id ;
        }
    }
}
