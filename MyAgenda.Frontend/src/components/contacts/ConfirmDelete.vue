<script setup>
import { defineProps, defineEmits } from "vue";

const props = defineProps({
  visible: Boolean,
  contactName: String, // opcional, para mostrar o nome do contato
});

const emit = defineEmits(["confirm", "cancel"]);
</script>

<template>
  <div v-if="visible" class="fixed inset-0 flex items-center justify-center z-50 bg-white/10 backdrop-blur-md">
    <div class="bg-white p-6 rounded-lg w-80 shadow-lg text-center">
      <h2 class="text-lg font-semibold text-gray-800 mb-4">Confirmar exclusão</h2>
      <p class="text-gray-700 mb-6">
        Tem certeza que deseja deletar
        <span class="font-medium">{{ contactName }}</span>?
      </p>
      <div class="flex justify-center gap-4">
        <button
          @click="$emit('confirm')"
          class="px-4 py-2 bg-red-600 text-white rounded hover:bg-red-700 transition"
        >
          Sim
        </button>
        <button
          @click="$emit('cancel')"
          class="px-4 py-2 bg-gray-300 text-gray-800 rounded hover:bg-gray-400 transition"
        >
          Cancelar
        </button>
      </div>
    </div>
  </div>
</template>