<template>
  <form @submit.prevent="submitNote" class="mb-4 flex flex-row">
    <input
      v-model="title"
      type="text"
      placeholder="Note Title"
      class="border text-primary-500 placeholder:text-slate-500 text-slate-900 rounded w-full py-3 px-1 mx-1"
      required
    />
    <button type="submit" class="bg-blue-500 px-2 min-w-fit text-white rounded hover:bg-blue-600">
      Add Note
    </button>
  </form>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useNotesStore } from '~/store/note'

const title = ref('')

const notesStore = useNotesStore()

const submitNote = () => {
  notesStore.addNote(title.value)
  title.value = ''
}
</script>
