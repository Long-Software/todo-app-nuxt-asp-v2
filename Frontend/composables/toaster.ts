import { defineStore } from 'pinia'

export const useToastStore = defineStore('toast', {
  state: () => ({
    messages: [] as { id: number; text: string; type: 'success' | 'error' }[],
    counter: 0,
  }),
  actions: {
    show(text: string, type: 'success' | 'error') {
      const id = ++this.counter
      this.messages.push({ id, text, type })
      setTimeout(() => this.remove(id), 3000) // auto remove after 3s
    },
    remove(id: number) {
      this.messages = this.messages.filter((m) => m.id !== id)
    },
  },
})
