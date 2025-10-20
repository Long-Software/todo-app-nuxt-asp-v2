<template>
  <div class="max-w-md mx-auto p-4 border rounded shadow">
    <h2 class="text-xl font-bold mb-4">Edit Note</h2>

    <form class="flex flex-col gap-3">
      <div>
        <label class="block text-sm font-medium mb-1">Title</label>
        <el-input
          v-model="title"
          :placeholder="title"
          class="text-primary-500 placeholder:text-slate-500 text-slate-900"
        />

        <!-- <input
          v-model="title"
          :placeholder="title"
          type="text"
          class="w-full border px-3 py-2 rounded placeholder:text-slate-500 text-slate-900 focus:outline-none focus:ring focus:border-blue-300"
          required
        /> -->
      </div>

      <div>
        <label class="block text-sm font-medium mb-1">Content</label>
        <el-input
          v-model="content"
          autosize
          type="textarea"
          placeholder="Please input"
          :rows="4"
        />
      </div>

      <div class="flex justify-end gap-2">
        <el-button type="info" @click="$emit('cancel')">Cancel</el-button>
        <el-button type="primary" :onclick="saveNote">Save</el-button>
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
const { showAlert } = useAlert();

const title = ref(props.note?.Title);
const content = ref(props.note?.Content);

const saveNote = async () => {
  try {
    if (title.value?.trim().length == 0 || content.value?.trim().length == 0) {
      throw new Error("Title and content must not be empty");
    }
    await store.editNote(
      store.selectedId,
      title.value ?? "",
      content.value ?? ""
    );
    showAlert("Note has been saved");
  } catch (error: unknown) {
    if (error instanceof Error) {
      showAlert(error.message);
      return;
    }
    showAlert("Unexpected Error");
  }
};
</script>
