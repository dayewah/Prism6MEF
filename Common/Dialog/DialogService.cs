using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Common.Dialog
{
    [Export(typeof(IDialogService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class DialogService : Common.Dialog.IDialogService
    {
        public string GetOpenFileDialog(string title, string filter)
        {
            var dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.Multiselect = false;
            dialog.Title = title;
            dialog.Filter = filter;
            if ((bool)dialog.ShowDialog())
                return dialog.FileName;

            return "";

        }

        public string GetSaveFileDialog(string title, string filter)
        {
            var dialog = new SaveFileDialog();
            dialog.Title = title;
            dialog.Filter = filter;
            if ((bool)dialog.ShowDialog())
            {

                return dialog.FileName;
            }
            else
            {
                return "";
            }
        }

    }
}
