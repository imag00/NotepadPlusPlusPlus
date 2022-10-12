﻿using System.Diagnostics;

namespace NotepadPlusPlusPlus.ViewModel.Commands.Edit
{
    public class CommandSearchBing : CommandBase
    {
        public override void Execute(object? parameter)
        {
            string link = "https://www.google.com/search?q=" + MainViewModel.MainWindow.SelectedText;
            Process.Start(new ProcessStartInfo(link) { UseShellExecute = true });
        }

        public override bool CanExecute(object? parameter) =>
            MainViewModel.MainWindow.SelectionLength > 0;
    }
}
