using System.Windows;

namespace DndCharacterCreation_Model
{
    public static class Session
    {
        // houdt het logintype bij(user, employee en admin)
        public static string logintype;
        // houdt de current view bij
        public static Window window;   
        public static void ClosePreviousWindow(Window view)
        {
            if(window != null)
            {
                window.Close();
            }
            window = view;
        }
    }
}
