<script setup>
import { defineProps, defineEmits } from "vue";
import DeleteContactButton from "./DeleteContactButton.vue";

const props = defineProps({
  contacts: {
    type: Array,
    default: () => [],
  },
});

const emit = defineEmits(["edit", "deleted"]);

const handleEdit = (contact) => emit("edit", contact);
const handleDeleted = () => emit("deleted");

const formatPhone = (phone) => {
  if (!phone) return "";

  const cleaned = phone.replace(/\D/g, "");

  return cleaned.replace(/(\d{2})(\d{5})(\d{4})/, "($1) $2-$3");
};
</script>

<template>
  <div v-if="contacts.length === 0" class="text-gray-500 text-center py-8">
    Nenhum contato encontrado
  </div>

  <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6 mt-4">
    <div
      v-for="contact in contacts"
      :key="contact.id"
      class="bg-[#e3e3e3] shadow-lg rounded-xl p-5 flex flex-col justify-between"
    >
      <div>
        <h2 class="text-lg font-semibold text-gray-900">
          {{ contact.name }}
        </h2>
        <p class="text-gray-700 text-sm mt-1">
          <span class="font-medium">Email:</span> {{ contact.email }}
        </p>
        <p class="text-gray-700 text-sm">
          <span class="font-medium">Telefone:</span> {{ formatPhone(contact.phone) }}
        </p>
      </div>

      <div class="flex justify-between mt-4">
        <button
          @click="handleEdit(contact)"
          class="flex items-center px-3 py-1 bg-blue-600 text-white rounded hover:bg-blue-700 text-sm transition"
        >
          Editar
        </button>

        <DeleteContactButton
          :contactId="contact.id"
          @deleted="handleDeleted"
        />
      </div>
    </div>
  </div>
</template>
