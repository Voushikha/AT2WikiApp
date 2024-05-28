
using System;
using System.ComponentModel;

namespace AT2
{
    public class Information : IComparable<Information>, INotifyPropertyChanged
    {
        #region Private Attributes

        private string name;
        private string category;
        private string structure;
        private string definition;

        #endregion

        #region Public Properties

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Category
        {
            get => category;
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }

        public string Structure
        {
            get => structure;
            set
            {
                if (structure != value)
                {
                    structure = value;
                    OnPropertyChanged(nameof(Structure));
                }
            }
        }

        public string Definition
        {
            get => definition;
            set
            {
                if (definition != value)
                {
                    definition = value;
                    OnPropertyChanged(nameof(Definition));
                }
            }
        }

        #endregion

        #region Constructor

        // Default constructor
        public Information() { }

        // Constructor with name parameter
        public Information(string newName)
        {
            name = newName;
        }

        // Constructor with name and category parameters
        public Information(string newName, string newCategory)
        {
            name = newName;
            category = newCategory;
        }

        #endregion

        #region Assessor Methods

        public string GetName() => name;

        public void SetName(string InfoName) => Name = InfoName;

        public string GetCategory() => category;

        public void SetCategory(string InfoCategory) => Category = InfoCategory;

        public string GetStructure() => structure;

        public void SetStructure(string InfoStructure) => Structure = InfoStructure;

        public string GetDefinition() => definition;

        public void SetDefinition(string InfoDefinition) => Definition = InfoDefinition;

        #endregion

        #region Overloaded CompareTo for the search and sort

        public int CompareTo(Information other)
        {
            return string.Compare(name, other.name, StringComparison.OrdinalIgnoreCase);
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
