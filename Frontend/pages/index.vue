<template>
  <div class="w-1/2 flex mx-auto gap-10">
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
import { useNotes } from "~/composables/useNote";
const { notesStore, onCancel, removeNote, selectNote, selectedNote } =
  useNotes();
</script>
