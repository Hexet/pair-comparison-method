using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace WinFormInterface
{
    public class MainPresenter
    {
        private readonly ImodeSelectionForm _selectForm;
        private IInputForm _inputForm;
        private readonly IFileManager _manager;
        private readonly IMessageService _messageService;
        private readonly ISelfAssesForm _selfAsses;

        public MainPresenter(ImodeSelectionForm selectForm, IFileManager manager,
            IMessageService service, ISelfAssesForm selfAsses, IInputForm inputForm)
        {
            _selectForm = selectForm;
            _manager = manager;
            _messageService = service;
            _inputForm = inputForm;
            _selfAsses = selfAsses;

            _selectForm.FinishMatrixClick += _selectForm_FinishMatrixClick;
            _selectForm.SelfAssesClick += _selectForm_SelfAssesClick;
            _selectForm.AlterChangeClick += _selectForm_AlterChangeClick;
            _inputForm.FileOpenClick += _matrixForm_FileOpenClick;
            _inputForm.FileSaveClick += _inputForm_FileSaveClick;
            _inputForm.ButAlterChangeClick += _inputForm_WriteAlternatives;
            _inputForm.ButProcessingClick += _inputForm_ProcessingMatrixClick;
        }

        private void _selectForm_AlterChangeClick(object sender, EventArgs e)
        {
            _manager.FilePath = "alternative.txt";
            _inputForm.Content = _manager.Content;
            _inputForm.ShowButAlterChange();
            _inputForm.ShowForm();
        }

        private void _inputForm_WriteAlternatives(object sender, EventArgs e)
        {
            _manager.SaveContent(_inputForm.Content);
            _manager.WriteAlternatives();
            _messageService.ShowMessage("lol");
        }

        private void _selectForm_FinishMatrixClick(object sender, EventArgs e)
        {
            _manager.FilePath = "matrix.txt";
            _inputForm.Content = _manager.Content;
            _inputForm.ShowButProcessing();
            _inputForm.ShowForm();
        }

        private void _inputForm_ProcessingMatrixClick(object sender, EventArgs e)
        {
            _messageService.ShowMessage("ok");
        }


        private void _inputForm_FileSaveClick(object sender, EventArgs e)
        {
            try
            {
                _manager.SaveContent(_inputForm.Content);
                //_messageService.ShowMessage("Файл успешно сохранен.");
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        private void _selectForm_SelfAssesClick(object sender, EventArgs e)
        {
            _selfAsses.ShowForm();
        }

        private void _matrixForm_FileOpenClick(object sender, EventArgs e)
        {
            try
            {
                _manager.FilePath = _inputForm.FilePath;
                if (!_manager.isExist())
                {
                    _messageService.ShowExclamation("Выбранный файл не существует");
                    return;
                }

                _inputForm.Content = _manager.Content;

            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }
    }
        static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            modeSelectionForm selectForm = new modeSelectionForm();
            InputForm inputForm = new InputForm();
            FileManager manager = new FileManager();
            MessageService service = new MessageService();
            SelfAssesForm selfAsses = new SelfAssesForm();

            MainPresenter presenter = new MainPresenter(selectForm, manager,
                service, selfAsses, inputForm);

            Application.Run(selectForm);
        }
    }
}
