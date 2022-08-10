using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DndCharacterCreation_DAL.DomainModels;
using DndCharacterCreation_WPF.Views;
using DndCharacterCreation_Model;

namespace DndCharacterCreation_WPF.ViewModels
{
    public class RaceViewModel : BaseViewModel
    {
        public RaceViewModel()
        {
        }
        public override string this[string columnName] => throw new NotImplementedException();
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
               
            }
        }
    }
}
