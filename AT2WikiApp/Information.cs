using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AT2WikiApp
{
  
        internal class Information : IComparable<Information>
        {
        #region Private Attributes

        private string name;
            private string category;
            private string structure;
            private string definition;

        public string Name { get; internal set; }
        public string Category { get; internal set; }
        public string Structure { get; internal set; }
        public string Definition { get; internal set; }

        #endregion
        #region Constructor 
        // Default constructor
        public Information()
            { }

            // Constructor with name parameter
            public Information(string newName)
            {
                name = newName;
            }
     //   Constructor with name and category parameters
        public Information(string newName, string newCategory)
            {
                name = newName;
                category = newCategory;
            }
        #endregion
        #region Assessor Methods
        public string GetName()
            {
                return name;
            }

            public void SetName(string InfoName)
            {
                name = InfoName;
            }

            public string GetCategory()
            {
                return category;
            }

            public void SetCategory(string InfoCategory)
            {
                category = InfoCategory;
            }

            public string GetStructure()
            {
                return structure;
            }

            public void SetStructure(string InfoStructure)
            {
                structure = InfoStructure;
            }

            public string GetDefinition()
            {
                return definition;
            }

            public void SetDefinition(string InfoDefinition)
            {
                definition = InfoDefinition;
            }


        #endregion
        #region Overloaded CompareTo for the search and sort.
        public int CompareTo(Information other)
            {
                return name.CompareTo(other.name);
            }
        #endregion
        public class UserDefinedFields : INotifyPropertyChanged
        {
            private string name;
            public string NAME
            {
                get => name;
                set
                {
                    if (name != value)
                    {
                        name = value;
                        OnPropertyChanged(nameof(NAME));
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}


