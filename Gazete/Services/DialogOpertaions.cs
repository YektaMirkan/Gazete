using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;

namespace Gazete.Services
{
    public static class DialogOperations
    {
        public async static Task DisplayWarningMessage(string message)
        {
            var warningView = new Dialogs.WarningMessageDialog(message);
            await DialogHost.Show(warningView, "RootDialog");
        }

        public async static Task DisplayWarningMessage(string message, string dialogIdentifier)
        {
            var warningView = new Dialogs.WarningMessageDialog(message);
            await DialogHost.Show(warningView, dialogIdentifier);
        }

        public async static Task DisplayInformationMessage(string message)
        {
            var informationView = new Dialogs.InformationMessageDialog(message);
            await DialogHost.Show(informationView, "RootDialog");
        }

        public async static Task DisplayInformationMessage(string message, string dialogIdentifier)
        {
            var informationView = new Dialogs.InformationMessageDialog(message);
            await DialogHost.Show(informationView, dialogIdentifier);
        }

        public async static Task<bool> DisplayQuestionDialog(string message, string title)
        {
            var questionDialog = new Dialogs.QuestionMessageDialog(message, title);
            var dialog = await DialogHost.Show(questionDialog, "RootDialog");
            return Convert.ToBoolean(dialog);
        }

        public async static Task<bool> DisplayQuestionDialog(string message, string title, string dialogIdentifier)
        {
            var questionDialog = new Dialogs.QuestionMessageDialog(message, title);
            var dialog = await DialogHost.Show(questionDialog, dialogIdentifier);
            return Convert.ToBoolean(dialog);
        }
    }
}
