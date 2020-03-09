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
        private readonly IResultForm _resultForm;
        private int i, j, x, y;
        PreferenceMatrix matrix;
        int[] orderedIndexAlternatives;

        public MainPresenter(ImodeSelectionForm selectForm, IFileManager manager,
            IMessageService service, ISelfAssesForm selfAsses, IInputForm inputForm,
            IResultForm resultForm)
        {
            _selectForm = selectForm;
            _manager = manager;
            _messageService = service;
            _inputForm = inputForm;
            _selfAsses = selfAsses;
            _resultForm = resultForm;

            _selectForm.FinishMatrixClick += _selectForm_FinishMatrixClick;
            _selectForm.SelfAssesClick += _selectForm_SelfAssesClick;
            _selectForm.AlterChangeClick += _selectForm_AlterChangeClick;
            _inputForm.FileOpenClick += _matrixForm_FileOpenClick;
            _inputForm.FileSaveClick += _inputForm_FileSaveClick;
            _inputForm.ButAlterChangeClick += _inputForm_WriteAlternatives;
            _inputForm.ButProcessingClick += _inputForm_ProcessingMatrixClick;
            _selfAsses.ChoiceClick += _selfAsses_ChoiceClick;
            matrix = new PreferenceMatrix(manager.Alternatives.Length);
        }

        private void _selfAsses_ChoiceClick(object sender, EventArgs e)
        {
            x = i; y = j;
            if (i < _manager.Alternatives.Length)
                j++;
            if (j >= _manager.Alternatives.Length) { i++; j = 0; }
            if (i == j)
            {
                j++;
                if (j >= _manager.Alternatives.Length) { i++; j = 0; }
            }
            if (i < _manager.Alternatives.Length)
            {
                _selfAsses.Alternative1 = _manager.Alternatives[i];
                _selfAsses.Alternative2 = _manager.Alternatives[j];
                matrix[x, y] = _selfAsses.ButValue;
            }
            else
            {
                if (x < _manager.Alternatives.Length)
                    matrix[x, y] = _selfAsses.ButValue;
                orderedIndexAlternatives = matrix.PreferenceMatrixProcessing();
                _resultForm.PrintResult(orderedIndexAlternatives, _manager.Alternatives);
                _selfAsses.HideForm();
                _resultForm.ShowForm();
            }
        }

        private void _selectForm_AlterChangeClick(object sender, EventArgs e)
        {
            _manager.FilePath = "alternative.txt";
            _inputForm.NameForm = "Изменение альтернатив";
            _inputForm.Content = _manager.Content;
            _inputForm.ShowButAlterChange();
            _inputForm.ShowForm();
        }

        private void _inputForm_WriteAlternatives(object sender, EventArgs e)
        {
            _manager.SaveContent(_inputForm.Content);
            _manager.WriteAlternatives();
            matrix = new PreferenceMatrix(_manager.Alternatives.Length);
        }

        private void _selectForm_FinishMatrixClick(object sender, EventArgs e)
        {
            _manager.FilePath = "matrix.txt";
            _inputForm.NameForm = "Ввод готовой матрицы предпочтений";
            _inputForm.Content = _manager.Content;
            _inputForm.ShowButProcessing();
            _inputForm.ShowForm();
        }

        private void _inputForm_ProcessingMatrixClick(object sender, EventArgs e)
        {
            _manager.SaveContent(_inputForm.Content);
            _manager.WriteStringMatrix();
            if (_manager.Alternatives.Length < 2)
            {
                _messageService.ShowError("Недостаточно альтернатив");
                return;
            }
            if (_manager.StringMatrix.Length != matrix.size)
            {
                _messageService.ShowError("Неверный формат ввода данных");
                return;
            }
            string[] str;
            for (int a = 0; a < _manager.StringMatrix.Length; a++)
            {
                str = _manager.StringMatrix[a].Split(new char[] { ' ' });
                if (str.Length != matrix.size && str.Length != matrix.size - 1)
                {
                    _messageService.ShowError("Неверный формат ввода данных");
                    return;
                }
                if (str.Length == matrix.size)
                {
                    Array.Copy(str, 1, str, 0, str.Length - 1);
                }
                for (int b = 0, c = 0; b < matrix.size - 1; b++, c++)
                {
                    if (a == b)
                        c++;
                    if (String.Compare(str[b], "0") == 0)
                    {
                        matrix[a, c] = 0;
                    }
                    else if (String.Compare(str[b], "1") == 0)
                    {
                        matrix[a, c] = 1;
                    }
                    else if (String.Compare(str[b], "1/2") == 0)
                    {
                        matrix[a, c] = 0.5f;
                    }
                    else
                    {
                        _messageService.ShowError("Неверный формат ввода данных");
                        return;
                    }
                }
            }

            orderedIndexAlternatives = matrix.PreferenceMatrixProcessing();
            _resultForm.PrintResult(orderedIndexAlternatives, _manager.Alternatives);
            _inputForm.HideForm();
            _resultForm.ShowForm();
        }


        private void _inputForm_FileSaveClick(object sender, EventArgs e)
        {
            try
            {
                _manager.SaveContent(_inputForm.Content);
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        private void _selectForm_SelfAssesClick(object sender, EventArgs e)
        {
            if (_manager.Alternatives.Length < 2)
            {
                _messageService.ShowError("Недостаточно альтернатив");
                return;
            }
            i = 0; j = 1;
            _selfAsses.Alternative1 = _manager.Alternatives[i];
            _selfAsses.Alternative2 = _manager.Alternatives[j];
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
            ResultForm resultForm = new ResultForm();

            MainPresenter presenter = new MainPresenter(selectForm, manager,
                service, selfAsses, inputForm, resultForm);

            Application.Run(selectForm);
        }
    }
}
