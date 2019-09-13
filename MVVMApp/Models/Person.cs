using MVVMApp.Enums;

namespace MVVMApp.Models
{
    public class Person
    {
        private string _name;
        private int? _age;
        private Genders _gender;

        public string Name { get => _name; set => _name = value; }
        public int? Age { get => _age; set => _age = value; }
        public Genders Gender { get => _gender; set => _gender = value; }

        public Person(string name, int? age, Genders gender)
        {
            _name = name;
            _age = age;
            _gender = gender;

            //TODO: Validate erros
        }

        public bool CanSave() => true;
    }
}
