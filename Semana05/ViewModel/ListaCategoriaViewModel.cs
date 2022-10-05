using Business;
using Entity;
using Semana05.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Semana05.ViewModel
{
    public class ListaCategoriaViewModel : ViewModelBase
    {
        public ObservableCollection<Categoria> Categorias { get; set; }
        public ICommand NuevoCommand { set; get; }
        public ICommand ConsultarCommand { set; get; }
        public ListaCategoriaViewModel()
        {
            Categorias = new Model.CategoriaModel().Categorias;

            NuevoCommand = new RelayCommand<Window>(
                param => Abrir()
                );

            ConsultarCommand = new RelayCommand<object>(
                o => { Categorias = (new Model.CategoriaModel()).Categorias; }
                );

            void Abrir()
            {
                View.ManCategoria window = new View.ManCategoria();
                window.ShowDialog();
                //Categorias = (new Model.CategoriaModel()).Categorias;
            }
        }
    }
}