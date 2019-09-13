﻿using MVVMApp.Commands;
using MVVMApp.Enums;
using MVVMApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MVVMApp.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        //Dúvidas
        //================================================================
        //   1. O meu modelo (Person) possui 3 propriedades, aqui na VM eu posso criar uma full propertie e fazer 
        // o binding na view como {Person.Nome}, ou eu posso criar três propriedades e fazer o binding
        // utilizando somente essa propriedade {Binding Name}.
        //   Para eu poder utilizar o data binding na forma {Person.Nome} seria preciso implementar INotifyPropertyChanged
        // também no meu modelo, porém sempre entendi que a VM é responsável por disparar esse evento.
        //   Por outro lado, se eu tenho 30 propriedades em um Model a minha VM ficaria muito poluida. Eu preciso analisar cada caso
        // ou é melhor deixar a interface sempre na VM?

        #region Private Members

        private Person _person;
        private string _name;
        private Genders _gender;
        private int? _age;

        #endregion

        #region Public Properties
        public Person SelectedPerson { get; set; }

        public Person Person
        {
            get => _person;
            set
            {
                if (_person == value)
                    return;

                _person = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                    return;

                _name = value;
                OnPropertyChanged();
            }
        }

        public int? Age
        {
            get => _age;
            set
            {
                if (_age == value)
                    return;

                _age = value;
                OnPropertyChanged();
            }
        }

        public Genders Gender
        {
            get => _gender;
            set
            {
                if (_gender == value)
                    return;

                _gender = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Person> Persons { get; set; }

        #endregion

        #region Commands

        public ICommand SaveOrUpdateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand PersonChangedCommand { get; set; }

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            SaveOrUpdateCommand = new RelayCommand(() => SaveOrUpdate());
            DeleteCommand = new RelayCommand(() => Delete());
            PersonChangedCommand = new RelayCommandWithParameter((parameter) => PersonChanged(parameter));
            Persons = new ObservableCollection<Person>();
        }

        #endregion

        #region Private Helpers

        private void PersonChanged(object parameter)
        {
            if (parameter == null)
                return;

            SelectedPerson = new Person(name: ((Person)parameter).Name,
                                        age: ((Person)parameter).Age,
                                        gender: ((Person)parameter).Gender);

            UpdateViewWithSelectedPerson(SelectedPerson);
        }

        private void UpdateViewWithSelectedPerson(Person person)
        {
            if (person == null)
                return;

            Name = person.Name;
            Age = person.Age;
            Gender = person.Gender;
        }

        private void SaveOrUpdate()
        {
            var newPerson = new Person(name: Name, 
                                    age: Age, 
                                    gender: Gender);

            if (newPerson.CanSave())
            {
                Persons.Add(newPerson);
                // TODO: Salvar no banco de dados
            }
        }

        private void Delete()
        {
            if (SelectedPerson == null)
                return;

            // Para remover eu teria que utilizar uma chave primária para identificar apenas um registro
            // TODO: Localizar pelo ID
            Persons.Remove(Persons.Where(person => person.Name == SelectedPerson.Name).FirstOrDefault());
           //TODO: Deletar do banco de dados
        }

        #endregion

    }
}
