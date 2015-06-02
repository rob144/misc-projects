using System;
using System.Windows;
using System.Windows.Input;

namespace WpfGraphicsApp1
{
    public static class RDCustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
        (
                "Exit",
                "Exit",
                typeof(RDCustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.F4, ModifierKeys.Alt)
                }
        );
    }
}
