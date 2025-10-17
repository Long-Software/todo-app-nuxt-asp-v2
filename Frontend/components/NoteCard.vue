<template>
  <div class="border-l-4 border-s-emerald-200 rounded-md p-2 flex flex-row">
    <div class="w-full" @click="selectNote">
      <h2 class="font-bold text-lg mb-2">{{ note.Title }}</h2>
      <p class="text-xs text-gray-400">
        Updated: {{ formatDate(note.UpdatedAt) }}
      </p>
    </div>
    <button
      @click="deleteNote"
      class="mt-2 bg-red-500 w-fit text-white px-3 py-1 rounded-xl hover:bg-red-600"
    >
      Delete
    </button>
  </div>
</template>

<script setup lang="ts">
import type { Note } from "~/models/note";

const props = defineProps<{
  note: Note;
}>();

const emit = defineEmits<{
  (e: "delete", id: number): void;
  (e: "select", id: number): void;
}>();

const deleteNote = () => {
  emit("delete", props.note.Id);
};

const selectNote = () => {
  emit("select", props.note.Id);
};
const formatDate = (raw: string) => {
  const date = new Date(raw);

  const formatted = `${date.getFullYear()}-${String(
    date.getMonth() + 1
  ).padStart(2, "0")}-${String(date.getDate()).padStart(2, "0")} ${String(
    date.getHours()
  ).padStart(2, "0")}:${String(date.getMinutes()).padStart(2, "0")}:${String(
    date.getSeconds()
  ).padStart(2, "0")}`;
  return formatted;
};
</script>
