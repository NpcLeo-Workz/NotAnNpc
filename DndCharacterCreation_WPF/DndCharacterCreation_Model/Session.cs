using System.Windows;

namespace DndCharacterCreation_Model
{
    public static class Session
    {
        // Keeps the current login type (admin or user)
        public static string logintype;
        // keeps the sessions current window
        public static Window window;   
        //closes the current window
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
