import { computed, onMounted } from "vue";
import { useNotesStore } from "~/store/note";

export const useNotes = () => {
  const notesStore = useNotesStore();

  onMounted(() => {
    notesStore.loadNotes();
  });

  const removeNote = (id: number) => {
    notesStore.removeNote(id);
  };

  const selectNote = (id: number) => {
    notesStore.selectNote(id);
  };

  const onCancel = () => {
    notesStore.selectNote(0);
  };

  const selectedNote = computed(() => {
    return notesStore.notes.find((n) => n.Id === notesStore.selectedId);
  });

  return {
    notesStore,
    removeNote,
    selectNote,
    onCancel,
    selectedNote,
  };
};
