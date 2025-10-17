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
    },
    async addNote(Title: string) {
      await createNote({ Title });
      await this.loadNotes();
    },
    async editNote(id: number, Title: string, Content: string) {
      await updateNote(id, { Title, Content });
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
