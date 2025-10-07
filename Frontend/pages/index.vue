<template>
  <div class="dark w-1/2 h-[75vh] flex mx-auto gap-10">
    <div class="w-full">
      <EditNoteCard
        v-if="notesStore.notes.length > 0 && notesStore.selectedId != 0"
        :key="notesStore.selectedId"
        :note="selectedNote"
        @cancel="onCancel"
      />
      <div
        v-else
        class="flex items-center justify-center h-full text-gray-500 italic"
      >
        No note selected
      </div>
    </div>
    <div class="flex h-full w-[450px] flex-col bg-muted px-2 py-2">
      <h1 class="text-xl font-bold mb-4">My Notes</h1>
      <div className="flex w-full flex-row justify-between">
        <NoteForm />
      </div>
      <div class="overflow-y-auto">
        <div v-if="notesStore.notes.length > 0" class="flex flex-col gap-4">
          <NoteCard
            v-for="note in notesStore.notes"
            :key="note.Id"
            :note="note"
            @select="selectNote"
            @delete="removeNote"
          />
        </div>
        <div
          v-else
          class="flex items-center justify-center h-full text-gray-500 italic"
        >
          No notes yet.
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed } from "vue";
import { useNotesStore } from "~/store/note";

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

const selectedNote = computed(() => {
  return (
    notesStore.notes.find((n) => n.Id === notesStore.selectedId) || undefined
  );
});

const onCancel = () => {
  notesStore.selectNote(0);
};
</script>
