using System;
namespace Common.Dialog
{
    public interface IDialogService
    {
        string GetOpenFileDialog(string title, string filter);
        string GetSaveFileDialog(string title, string filter);
    }
}
