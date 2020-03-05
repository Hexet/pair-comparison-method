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
        private readonly ImatrixInputForm _matrixForm;
        private readonly IMatrixManager _manager;
        private readonly IMessageService _messageService;
        private readonly ISelfAssesForm _selfAsses;
        private string _currentFilePath;

        public MainPresenter(ImodeSelectionForm selectForm, IMatrixManager manager, IMessageService service, ImatrixInputForm matrixForm, ISelfAssesForm selfAsses)
        {
            _selectForm = selectForm;
            _manager = manager;
            _messageService = service;
            _matrixForm = matrixForm;
            _selfAsses = selfAsses;

            _selectForm.FinishMatrixClick += _selectForm_FinishMatrixClick;
            _selectForm.SelfAssesClick += _selectForm_SelfAssesClick;
            _matrixForm.FileOpenClick += _matrixForm_FileOpenClick;
        }

        private void _selectForm_SelfAssesClick(object sender, EventArgs e)
        {
            _selfAsses.ShowForm();
        }

        private void _matrixForm_FileOpenClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = _matrixForm.FilePath;
                bool isExist = _manager.isExist(filePath);
                if (!isExist)
                {
                    _messageService.ShowExclamation("Выбранный файл не существует");
                    return;
                }

                _currentFilePath = filePath;
                _matrixForm.Content = _manager.GetContent(filePath);

            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        private void _selectForm_FinishMatrixClick(object sender, EventArgs e)
        {
            _matrixForm.ShowForm();
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
            matrixInputForm matrixForm = new matrixInputForm();
            MatrixManager manager = new MatrixManager();
            MessageService service = new MessageService();
            SelfAssesForm selfAsses = new SelfAssesForm();

            MainPresenter presenter = new MainPresenter(selectForm, manager, service, matrixForm, selfAsses);

            Application.Run(selectForm);
        }
    }
}
