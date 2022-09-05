using AbriellaNotes.Model;
using AbriellaNotes.ViewModel.Commands;
using AbriellaNotes.ViewModel.Helpers;
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
		public NewNotebookCommand NewNotebookCommand { get; set; }
		public NewNoteCommand NewNoteCommand { get; set; }

		public NotesVM()
		{
			NewNotebookCommand = new NewNotebookCommand(this);
			NewNoteCommand = new NewNoteCommand(this);
		}

		public void CreateNewNotebook()
		{
			Notebook newNotebook = new Notebook()
			{
				Name = "New notebook"
			};

            DatabaseHelper.Insert(newNotebook);
        }

		public void CreateNote(int notebookId)
		{
			Note newNote = new Note()
			{
				NotebookId = notebookId,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				Title = "New Note"

			};

			DatabaseHelper.Insert(newNote);

		}

	}
}
