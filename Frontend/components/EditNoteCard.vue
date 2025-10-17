<template>
  <div class="max-w-md mx-auto p-4 border rounded shadow">
    <h2 class="text-xl font-bold mb-4">Edit Note</h2>

    <form @submit.prevent="saveNote" class="flex flex-col gap-3">
      <div>
        <label class="block text-sm font-medium mb-1">Title</label>
        <input
          v-model="title"
          :placeholder="title"
          type="text"
          class="w-full border px-3 py-2 rounded placeholder:text-slate-500 text-slate-900 focus:outline-none focus:ring focus:border-blue-300"
          required
        />
      </div>

      <div>
        <label class="block text-sm font-medium mb-1">Content</label>
        <textarea
          v-model="content"
          placeholder="Write your note"
          rows="4"
          class="w-full border px-3 py-2 rounded placeholder:text-slate-500 text-slate-900 focus:outline-none focus:ring focus:border-blue-300"
        ></textarea>
      </div>

      <div class="flex justify-end gap-2">
        <button
          type="button"
          @click="$emit('cancel')"
          class="px-4 py-2 bg-gray-500 rounded hover:bg-gray-400"
        >
          Cancel
        </button>
        <button
          type="submit"
          class="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
        >
          Save
        </button>
      </div>
    </form>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import type { Note } from "~/models/note";
import { useNotesStore } from "~/store/note";

const props = defineProps<{
  note?: Note;
}>();

const emit = defineEmits<{
  (e: "cancel"): void;
}>();

const store = useNotesStore();

const title = ref(props.note?.Title);
const content = ref(props.note?.Content);

const saveNote = async () => {
  await store.editNote(
    store.selectedId,
    title.value ?? "",
    content.value ?? ""
  );
};
</script>
