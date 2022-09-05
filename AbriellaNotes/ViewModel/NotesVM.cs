using AbriellaNotes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbriellaNotes.ViewModel
{
    public class NotesVM
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }
		
		private Notebook selecteNotebook;
		public Notebook SelectedNotebook
		{
			get { return selecteNotebook; }
			set 
			{ 
				selecteNotebook = value; 
				//TODO: get notes
			}
		}

		public ObservableCollection<Note> Notes { get; set; }

	}
}
