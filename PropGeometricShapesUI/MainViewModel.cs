using PropertiesGeometricShapes.CustomAttributes;
using PropertiesGeometricShapes.Factorys;
using PropertiesGeometricShapes.Interfaces;
using PropertiesGeometricShapes.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace PropGeometricShapesUI
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        #region Properties

        private List<Type> _shapes;

        public List<Type> Shapes => _shapes ??= GetShapesWithDisplayName();

        private Type _selectedShape;

        public Type SelectedShape
        {
            get => _selectedShape;
            set
            {
                if (_selectedShape == value)
                    return;

                _selectedShape = value;
                RequiredProperties = GetRequiredProperties(value);
                OnPropertyChanged(nameof(RequiredProperties));
            }
        }

        private Dictionary<Type, IShapeFactory> _factories;

        private Dictionary<Type, IShapeFactory> Factories => _factories ??= new Dictionary<Type, IShapeFactory>
        {
            { typeof(Triangle), new TriangleFactory() },
            { typeof(Circle), new CircleFactory() }
        };

        public List<RequiredPropertiesInfo> RequiredProperties { get; set; }

        private Dictionary<string, object> _resultProperties;

        public Dictionary<string, object> ResultProperties
        {
            get => _resultProperties;
            set
            {
                if (_resultProperties == value)
                    return;

                _resultProperties = value;
                OnPropertyChanged(nameof(ResultProperties));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get classes implementing IShape with DisplayNameAttribute
        /// </summary>
        /// <returns></returns>
        private List<Type> GetShapesWithDisplayName()
        {
            var assembly = Assembly.GetAssembly(typeof(IShape));
            var displayShapeTypes = assembly?.GetTypes()
                                             .Where(type => type.IsAssignableTo(typeof(IShape)) && type.GetCustomAttribute(typeof(DisplayNameAttribute)) is not null)
                                             .ToList();

            return displayShapeTypes;
        }

        /// <summary>
        /// Get a wrapper over the necessary properties of the selected shape
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        private List<RequiredPropertiesInfo> GetRequiredProperties(Type shapeType)
        {
            var displayRequiredProperties = shapeType.GetCustomAttribute<ShapeParamAttribute>()
                                                     .TypeParam.GetProperties()
                                                     .Select(prop => new RequiredPropertiesInfo(prop))
                                                     .ToList();

            return displayRequiredProperties;
        }

        #endregion

        #region Commands

        #region GetResultPropertiesCommand

        private Command _getResultPropertiesCommand;

        public Command GetResultPropertiesCommand
        {
            get
            {
                return _getResultPropertiesCommand ??= new Command(GetResultProperties, GetResultPropertiesCanExecute);
            }
        }

        private void GetResultProperties(object obj)
        {
            try
            {
                var shapeParamType = SelectedShape.GetCustomAttribute<ShapeParamAttribute>().TypeParam;

                var valueParams = RequiredProperties.Select(prop => prop.Value as object)
                                                    .ToArray();

                var shapeParam = Activator.CreateInstance(shapeParamType, valueParams, null) as IShapeParam;

                ResultProperties = Factories[SelectedShape].CreateShape(shapeParam).GetProperties();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool GetResultPropertiesCanExecute(object obj)
        {
            return SelectedShape is not null;
        }

        #endregion

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }

    public class Command : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
