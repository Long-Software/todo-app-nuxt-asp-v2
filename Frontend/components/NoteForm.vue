<template>
  <form @submit.prevent="submitNote" class="mb-4 flex flex-row">
    <el-input
      v-model="title"
      class="text-primary-500 placeholder:text-slate-500 text-slate-900"
      placeholder="Please input"
    />

    <el-button type="primary" @click="submitNote"> Add Note</el-button>
  </form>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { useNotesStore } from "~/store/note";

const title = ref("");

const notesStore = useNotesStore();
const { showAlert } = useAlert();

const submitNote = () => {
  notesStore.addNote(title.value);
  title.value = "";
  showAlert("Note has been created");
};
</script>
