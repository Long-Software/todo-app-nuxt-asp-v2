import { defineStore } from "pinia";
import type { Note } from "~/models/note";
import {
  createNote,
  deleteNote,
  fetchNotes,
  updateNote,
} from "~/services/notes";

export const useNotesStore = defineStore("notes", {
  state: () => ({
    notes: [] as Note[],
    selectedId: 0,
  }),
  actions: {
    async loadNotes() {
      this.notes = await fetchNotes();
      console.log(this.notes);
    },
    async addNote(title: string) {
      const newNote = await createNote({ title });
      await this.loadNotes();
    },
    async editNote(id: number, title: string, content: string) {
      await updateNote(id, { title, content });
      await this.loadNotes();
    },
    async removeNote(id: number) {
      await deleteNote(id);
      this.notes = this.notes.filter((n) => n.Id !== id);
    },
    selectNote(id: number) {
      this.selectedId = id;
    },
  },
});
